// Adrian Hamza - http://blogs.msdn.com/ahamza/archive/2006/02/04/FileSystemWatcher_Duplicate_Events.aspx
// DISCLAIMER: Use this code at your own risk. 
// No support is provided and this code has NOT been tested.

using System;
using System.IO;
using System.Timers;
using System.Collections;
using System.ComponentModel;

namespace uDir
{
    #region DelayedEvent class
    /// <summary>
    /// This class wraps FileSystemEventArgs and RenamedEventArgs
    /// objects and detection of duplicate events.
    /// </summary>
    internal class DelayedEvent
    {
        public DelayedEvent(FileSystemEventArgs args)
        {
            Args = args;
        }

        public readonly FileSystemEventArgs Args;

        public bool Delayed { get; set; }

        public virtual bool IsDuplicate(object obj)
        {
            DelayedEvent delayedEvent = obj as DelayedEvent;
            if (delayedEvent == null)
            {
                return false; // this is not null so they are different 
            }
            else
            {
                FileSystemEventArgs eO1 = Args;
                RenamedEventArgs reO1 = Args as RenamedEventArgs;
                FileSystemEventArgs eO2 = delayedEvent.Args;
                RenamedEventArgs reO2 = delayedEvent.Args as RenamedEventArgs;
                // The events are equal only if they are of the same type (reO1 and reO2
                // are both null or NOT NULL) and have all properties equal.         
                // We also eliminate Changed events that follow recent Created events
                // because many apps create new files by creating an empty file and then 
                // they update the file with the file content.
                return ((eO1 != null && eO2 != null && eO1.ChangeType == eO2.ChangeType
                    && eO1.FullPath == eO2.FullPath && eO1.Name == eO2.Name) &&
                    ((reO1 == null & reO2 == null) || (reO1 != null && reO2 != null &&
                    reO1.OldFullPath == reO2.OldFullPath && reO1.OldName == reO2.OldName))) ||
                    (eO1 != null && eO2 != null && eO1.ChangeType == WatcherChangeTypes.Created
                    && eO2.ChangeType == WatcherChangeTypes.Changed
                    && eO1.FullPath == eO2.FullPath && eO1.Name == eO2.Name);
            }
        }
    } 
    #endregion

    /// <summary>
    /// This class wraps a FileSystemWatcher object. The class is not derived
    /// from FileSystemWatcher because most of the FileSystemWatcher methods 
    /// are not virtual. The class was designed to resemble FileSystemWatcher class
    /// as much as possible so that you can use DelayedFileSystemWatcher instead 
    /// of FileSystemWatcher objects. 
    /// DelayedFileSystemWatcher will capture all events from the FileSystemWatcher object.
    /// The captured events will be delayed by at least ConsolidationInterval milliseconds in order
    /// to be able to eliminate duplicate events. When duplicate events are found, the last event
    /// is droped and the first event is fired (the reverse is not recomended because it could
    /// cause some events not be fired at all since the last event will become the first event and
    /// it won't fire a if a new similar event arrives imediately afterwards).
    /// </summary>
    public class DelayedFileSystemWatcher
    {
        private FileSystemWatcher watcher = null;
        
        // Lock order is _enterThread, events.SyncRoot
        private object _enterThread = new object(); // Only one timer event is processed at any given moment
        private ArrayList events = null;

        private System.Timers.Timer timer = null;
        private int _msConsolidationInterval = 1000; // milliseconds

        #region Delegate to FileSystemWatcher
        public DelayedFileSystemWatcher()
        {
            this.watcher = new FileSystemWatcher();
            this.Initialize();
        }
        
        public DelayedFileSystemWatcher(string path)
        {
            this.watcher = new FileSystemWatcher(path);
            this.Initialize();
        }
        
        public DelayedFileSystemWatcher(string path, string filter)
        {
            this.watcher = new FileSystemWatcher(path, filter);
            this.Initialize();
        }

        // Summary:
        //     Gets or sets a value indicating whether the component is enabled.
        //
        // Returns:
        //     true if the component is enabled; otherwise, false. The default is false.
        //     If you are using the component on a designer in Visual Studio 2005, the default
        //     is true.
        public bool EnableRaisingEvents 
        { 
            get
            {
                return this.watcher.EnableRaisingEvents;
            }
            set
            {
                this.watcher.EnableRaisingEvents = value;
                if (value)
                {
                    this.timer.Start();
                }
                else
                {
                    this.timer.Stop();
                    this.events.Clear();
                }
            }
        }
        //
        // Summary:
        //     Gets or sets the filter string, used to determine what files are monitored
        //     in a directory.
        //
        // Returns:
        //     The filter string. The default is "*.*" (Watches all files.)
        public string Filter 
        { 
            get
            {
                return this.watcher.Filter;
            }
            set
            {
                this.watcher.Filter = value;
            }
        }
        //
        // Summary:
        //     Gets or sets a value indicating whether subdirectories within the specified
        //     path should be monitored.
        //
        // Returns:
        //     true if you want to monitor subdirectories; otherwise, false. The default
        //     is false.
        public bool IncludeSubdirectories 
        {
            get
            {
                return this.watcher.IncludeSubdirectories;
            }
            set
            {
                this.watcher.IncludeSubdirectories = value;
            }
        }
        //
        // Summary:
        //     Gets or sets the size of the internal buffer.
        //
        // Returns:
        //     The internal buffer size. The default is 8192 (8K).
        public int InternalBufferSize 
        {
            get
            {
                return this.watcher.InternalBufferSize;
            }
            set
            {
                this.watcher.InternalBufferSize = value;
            }
        }
        //
        // Summary:
        //     Gets or sets the type of changes to watch for.
        //
        // Returns:
        //     One of the System.IO.NotifyFilters values. The default is the bitwise OR
        //     combination of LastWrite, FileName, and DirectoryName.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The value is not a valid bitwise OR combination of the System.IO.NotifyFilters
        //     values.
        public NotifyFilters NotifyFilter 
        {
            get
            {
                return this.watcher.NotifyFilter;
            }
            set
            {
                this.watcher.NotifyFilter = value;
            }
        }
        //
        // Summary:
        //     Gets or sets the path of the directory to watch.
        //
        // Returns:
        //     The path to monitor. The default is an empty string ("").
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The specified path contains wildcard characters.-or- The specified path contains
        //     invalid path characters.
        public string Path 
        {
            get
            {
                return this.watcher.Path;
            }
            set
            {
                this.watcher.Path = value;
            }
        }
        //
        // Summary:
        //     Gets or sets the object used to marshal the event handler calls issued as
        //     a result of a directory change.
        //
        // Returns:
        //     The System.ComponentModel.ISynchronizeInvoke that represents the object used
        //     to marshal the event handler calls issued as a result of a directory change.
        //     The default is null.
        public ISynchronizeInvoke SynchronizingObject 
        {
            get
            {
                return this.watcher.SynchronizingObject;
            }
            set
            {
                this.watcher.SynchronizingObject = value;
            }
        }

        // Summary:
        //     Occurs when a file or directory in the specified System.IO.FileSystemWatcher.Path
        //     is changed.
        public event FileSystemEventHandler Changed;
        //
        // Summary:
        //     Occurs when a file or directory in the specified System.IO.FileSystemWatcher.Path
        //     is created.
        public event FileSystemEventHandler Created;
        //
        // Summary:
        //     Occurs when a file or directory in the specified System.IO.FileSystemWatcher.Path
        //     is deleted.
        public event FileSystemEventHandler Deleted;

        //
        // Summary:
        //     Occurs when the internal buffer overflows.
        public event ErrorEventHandler Error;

        //
        // Summary:
        //     Occurs when a file or directory in the specified System.IO.FileSystemWatcher.Path
        //     is renamed.
        public event RenamedEventHandler Renamed;

        // Summary:
        //     Begins the initialization of a System.IO.FileSystemWatcher used on a form
        //     or used by another component. The initialization occurs at run time.
        public void BeginInit()
        {
            this.watcher.BeginInit();
        }
        //
        // Summary:
        //     Releases the unmanaged resources used by the System.IO.FileSystemWatcher
        //     and optionally releases the managed resources.
        //
        // Parameters:
        //   disposing:
        //     true to release both managed and unmanaged resources; false to release only
        //     unmanaged resources.
        public void Dispose()
        {
            this.Uninitialize();
        }
        //
        // Summary:
        //     Ends the initialization of a System.IO.FileSystemWatcher used on a form or
        //     used by another component. The initialization occurs at run time.
        public void EndInit()
        {
            this.watcher.EndInit();
        }

        //
        // Summary:
        //     Raises the System.IO.FileSystemWatcher.Changed event.
        //
        // Parameters:
        //   e:
        //     A System.IO.FileSystemEventArgs that contains the event data.
        protected void OnChanged(FileSystemEventArgs e)
        {
            if (this.Changed != null)
            {
                this.Changed(this, e);
            }
        }

        //
        // Summary:
        //     Raises the System.IO.FileSystemWatcher.Created event.
        //
        // Parameters:
        //   e:
        //     A System.IO.FileSystemEventArgs that contains the event data.
        protected void OnCreated(FileSystemEventArgs e)
        {
            if (this.Created != null)
            {
                this.Created(this, e);
            }
        }
        //
        // Summary:
        //     Raises the System.IO.FileSystemWatcher.Deleted event.
        //
        // Parameters:
        //   e:
        //     A System.IO.FileSystemEventArgs that contains the event data.
        protected void OnDeleted(FileSystemEventArgs e)
        {
            if (this.Deleted != null)
            {
                this.Deleted(this, e);
            }
        }
        //
        // Summary:
        //     Raises the System.IO.FileSystemWatcher.Error event.
        //
        // Parameters:
        //   e:
        //     An System.IO.ErrorEventArgs that contains the event data.
        protected void OnError(ErrorEventArgs e)
        {
            if (this.Error != null)
            {
                this.Error(this, e);
            }
        }

        //
        // Summary:
        //     Raises the System.IO.FileSystemWatcher.Renamed event.
        //
        // Parameters:
        //   e:
        //     A System.IO.RenamedEventArgs that contains the event data.
        protected void OnRenamed(RenamedEventArgs e)
        {
            if (this.Renamed != null)
            {
                this.Renamed(this, e);
            }
        }
        //
        // Summary:
        //     A synchronous method that returns a structure that contains specific information
        //     on the change that occurred, given the type of change you want to monitor.
        //
        // Parameters:
        //   changeType:
        //     The System.IO.WatcherChangeTypes to watch for.
        //
        // Returns:
        //     A System.IO.WaitForChangedResult that contains specific information on the
        //     change that occurred.
        public WaitForChangedResult WaitForChanged(WatcherChangeTypes changeType)
        {
            //TODO
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     A synchronous method that returns a structure that contains specific information
        //     on the change that occurred, given the type of change you want to monitor
        //     and the time (in milliseconds) to wait before timing out.
        //
        // Parameters:
        //   timeout:
        //     The time (in milliseconds) to wait before timing out.
        //
        //   changeType:
        //     The System.IO.WatcherChangeTypes to watch for.
        //
        // Returns:
        //     A System.IO.WaitForChangedResult that contains specific information on the
        //     change that occurred.
        public WaitForChangedResult WaitForChanged(WatcherChangeTypes changeType, int timeout)
        {
            //TODO
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation
        private void Initialize()
        {
            this.events = ArrayList.Synchronized(new ArrayList(32));
            this.watcher.Changed += new FileSystemEventHandler(this.FileSystemEventHandler);
            this.watcher.Created += new FileSystemEventHandler(this.FileSystemEventHandler);
            this.watcher.Deleted += new FileSystemEventHandler(this.FileSystemEventHandler);
            this.watcher.Error += new ErrorEventHandler(this.ErrorEventHandler);
            this.watcher.Renamed += new RenamedEventHandler(this.RenamedEventHandler);
            this.timer = new Timer(this._msConsolidationInterval);
            this.timer.Elapsed += new ElapsedEventHandler(this.ElapsedEventHandler);
            this.timer.AutoReset = true;
            this.timer.Enabled = this.watcher.EnableRaisingEvents;
        }
        private void Uninitialize()
        {
            if (this.watcher != null)
            {
                this.watcher.Dispose();
            }
            if (this.timer != null)
            {
                this.timer.Dispose();
            }
        }
        private void FileSystemEventHandler(object sender, FileSystemEventArgs e)
        {
            this.events.Add(new DelayedEvent(e));
        }

        private void ErrorEventHandler(object sender, ErrorEventArgs e)
        {
            this.OnError(e);
        }

        private void RenamedEventHandler(object sender, RenamedEventArgs e)
        {
            this.events.Add(new DelayedEvent(e));
        }
        
        private void ElapsedEventHandler(Object sender, ElapsedEventArgs e)
        {
            // We don't fire the events inside the lock. We will queue them here until
            // the code exits the locks.
            Queue eventsToBeFired = null;
            if (System.Threading.Monitor.TryEnter(this._enterThread))
            {
                // Only one thread at a time is processing the events                
                try
                {
                    eventsToBeFired = new Queue(32);
                    // Lock the collection while processing the events
                    lock (this.events.SyncRoot)
                    {
                        DelayedEvent current = null;
                        for(int i=0; i<this.events.Count; i++)
                        {
                            current = this.events[i] as DelayedEvent;
                            if (current.Delayed)
                            {
                                // This event has been delayed already so we can fire it
                                // We just need to remove any duplicates
                                for (int j = i + 1; j < this.events.Count; j++)
                                {
                                    if (current.IsDuplicate(this.events[j]))
                                    {
                                        // Removing later duplicates
                                        this.events.RemoveAt(j);
                                        j--; // Don't skip next event
                                    }
                                }
                                // Add the event to the list of events to be fired
                                eventsToBeFired.Enqueue(current);
                                // Remove it from the current list
                                this.events.RemoveAt(i);
                                i--; // Don't skip next event
                            }
                            else
                            {
                                // This event was not delayed yet, so we will delay processing
                                // this event for at least one timer interval
                                current.Delayed = true;
                            }
                        }
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(this._enterThread);
                }
            }
            // else - this timer event was skipped, processing will happen during the next timer event

            // Now fire all the events if any events are in eventsToBeFired
            this.RaiseEvents(eventsToBeFired);
        }
        
        public int ConsolidationInterval
        {
            get
            {
                return this._msConsolidationInterval;
            }
            set
            {
                this._msConsolidationInterval = value;
                this.timer.Interval = value;
            }
        }

        protected void RaiseEvents(Queue deQueue)
        {
            if ((deQueue != null) && (deQueue.Count > 0))
            {
                DelayedEvent de = null;
                while (deQueue.Count > 0)
                {
                    de = deQueue.Dequeue() as DelayedEvent;
                    switch (de.Args.ChangeType)
                    {
                        case WatcherChangeTypes.Changed:
                            this.OnChanged(de.Args);
                            break;
                        case WatcherChangeTypes.Created:
                            this.OnCreated(de.Args);
                            break;
                        case WatcherChangeTypes.Deleted:
                            this.OnDeleted(de.Args);
                            break;
                        case WatcherChangeTypes.Renamed:
                            this.OnRenamed(de.Args as RenamedEventArgs);
                            break;
                    }
                }
            }
        }
        #endregion
    }
}

