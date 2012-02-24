import clr

clr.AddReference('IronPython')
clr.AddReference('uDir')

from System.IO import FileInfo
from System import Decimal
from System import String
from uDir import CommonFolder
from uDir import Torrent

def getFolderForTorrent(torrent, folders):
    #simple detection, based on torrent filename
    if torrent.FileName.find(".R5.") != -1:
        return getFolderByName(folders, "Filme")
        
    if torrent.FileName.find("House.S07") != -1:
        return getFolderByName(folders, "House")
    
    #decision based on most relevant extension
    ext = torrent.MostRelevantExtension
    if ext == "mkv" or ext == "avi":
        return getFolderByName(folders, "Movies")
    
    if ext == "mp3" or ext == "flac":
        return getFolderByName(folders, "Music")
    
    if ext == "pdf" or ext == "chm":
        return getFolderByName(folders, "Documents")
    
    return getFolderByName(folders, "Download")

def getFolderByName(folders, name):
    for fldr in folders:
        if fldr.Name == name:
            return fldr
    return None