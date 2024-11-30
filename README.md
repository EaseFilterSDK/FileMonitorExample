# [File Monitor SDK](https://www.easefilter.com/Forums_Files/FileMonitor.htm)
The File Monitor Filter Driver SDK is a kernel-mode component that runs as part of the Windows executive above the file system. The file system filter driver can intercept requests targeted at a file system or another file system filter driver. By intercepting the request before it reaches its intended target, the filter driver can extend or replace functionality provided by the original target of the request. The EaseFilter file system filter driver can log, observe, modify, or even prevent the I/O operations for one or more file systems or file system volumes.

![File Monitor](https://www.easefilter.com/images/MonitorFilter.png)

## File I/O Monitor
The file I/O monitor can audit file access and change in Windows in Real-Time. With the file monitor you can monitor the file activities on file system level, capture file open, create, overwrite, read, write, query file information, set file information, query security information, set security information, file rename, file delete, directory browsing and file close I/O requests. You can create the file access log, you will know who, when, what files were accessed. You can get comprehensive control and visibility over users and data by tracking and monitoring all the user & file activities, permission changes, storage capacity and generate real-time audit reports.

### Monitor the file changed I/O by registering the file change events.

You can get the notification when the managed files were changed by registering the file change events:

-  **NotifyFileWasCreated**: Fires this event when the new file was created after the file handle closed.
-  **NotifyFileWasWritten**: Fires this event when the file was written after the file handle closed.
-  **NotifyFileWasRenamed**: Fires this event when the file was moved or renamed after the file handle closed.
-  **NotifyFileWasDeleted**: Fires this event when the file was deleted after the file handle closed.
-  **NotifyFileSecurityWasChanged**: Fires this event when the file's security was changed after the file handle closed.
-  **NotifyFileInfoWasChanged**: Fires this event when the file's information was changed after the file handle closed.

### Monitor all the file I/O by registering the I/O callback notification events.

You can register the file I/O events to monitor the file access I/O in the file filter rule. By registering the specific I/O events, you can get file I/O information in real time.

-  **OnPostFileCreate**: Fires this event after the file create IO was returned from the file system.
-  **OnPostFileRead**: Fires this event after the file read IO was returned from the file system.
-  **OnPostFileWrite**: Fires this event after the file write IO was returned from the file system.
-  **OnPostQueryFileSize**: Fires this event after the query file size IO was returned from the file system.
-  **OnPostQueryFileBasicInfo**: Fires this event after the query file basic info IO was returned from the file system.
-  **OnPostQueryFileStandardInfo**: Fires this event after the query file standard info IO was returned from the file system.
-  **OnPostQueryFileNetworkInfo**: Fires this event after the query file network info IO was returned from the file system.
-  **OnPostQueryFileId**: Fires this event after the query file Id IO was returned from the file system.
-  **OnPostQueryFileInfo**: Fires this event after the query file info IO was returned from the file system.
-  **OnPostSetFileSize**: Fires this event after the set file size IO was returned from the file system.
-  **OnPostSetFileBasicInfo**: Fires this event after the set file basic info IO was returned from the file system.
-  **OnPostSetFileStandardInfo**: Fires this event after the set file standard info IO was returned from the file system.
-  **OnPostSetFileNetworkInfo**: Fires this event after the set file network info was returned from the file system.
-  **OnPostMoveOrRenameFile**: Fires this event after the file move or rename IO was returned from the file system.
-  **OnPostDeleteFile**: Fires this event after the file delete IO was returned from the file system.
-  **OnPostSetFileInfo**: Fires this event after the set file info IO was returned from the file system.
-  **OnPostQueryDirectoryFile**: Fires this event after the query directory file info was returned from the file system.
-  **OnPostQueryFileSecurity**: Fires this event after the query file security IO was returned from the file system.
-  **OnPostSetFileSecurity**: Fires this event after the set file security IO was returned from the file system.
-  **OnPostFileHandleClose**: Fires this event after the file handle close IO was returned from the file system.
-  **OnPostFileClose**: Fires this event after the file close IO was returned from the file system.

## Create C# file monitor example with SDK
This C# example creates a filter rule to watch the directory specified at run time. The component is set to watch for all file change in the directory. If a file was changed, the file name, file change type, user name, process name will be printed to the console. The component also is set to watch the file open and file read IO, the IO was triggered, the file open and file read information will be printed to the console.

Here is the output from the file monitor example.

![File Monitor output](https://www.easefilter.com/Images/MonitorConsole.png)

[Read more about file monitor example](https://www.easefilter.com/Forums_Files/FileMonitor.htm)


## EaseFilter File System Filter Driver SDK Reference
| Product Name | Description |
| --- | --- |
| [File Monitor SDK](https://www.easefilter.com/kb/file-monitor-filter-driver-sdk.htm) | EaseFilter File Monitor Filter Driver SDK Introduction. |
| [File Control SDK](https://www.easefilter.com/kb/file-control-file-security-sdk.htm) | EaseFilter File Control Filter Driver SDK Introduction. |
| [File Encryption SDK](https://www.easefilter.com/kb/transparent-file-encryption-filter-driver-sdk.htm) | EaseFilter Transparent File Encryption Filter Driver SDK Introduction. |
| [Registry Filter SDK](https://www.easefilter.com/kb/registry-filter-drive-sdk.htm) | EaseFilter Registry Filter Driver SDK Introduction. |
| [Process Filter SDK](https://www.easefilter.com/kb/process-filter-driver-sdk.htm) | EaseFilter Process Filter Driver SDK Introduction. |
| [Storage Tiering SDK](https://www.easefilter.com/cloud/storage-tiering-sdk.htm) | EaseFilter Storage Tiering Filter Driver SDK Introduction. |
| [EaseFilter SDK Programming](https://www.easefilter.com/kb/programming.htm) | EaseFilter Filter Driver SDK Programming. |

## EaseFilter SDK Sample Projects
| Sample Project | Description |
| --- | --- |
| [Auto File DRM Encryption](https://www.easefilter.com/kb/auto-file-drm-encryption-tool.htm) | Auto file encryption with DRM data embedded. |
| [Transparent File Encrypt](https://www.easefilter.com/kb/AutoFileEncryption.htm) | Transparent on access file encryption. |
| [Secure File Sharing with DRM](https://www.easefilter.com/kb/DRM_Secure_File_Sharing.htm) | Secure encrypted file sharing with digital rights management. |
| [File Monitor Example](https://www.easefilter.com/kb/file-monitor-demo.htm) | Monitor file system I/O in real time, tracking file changes. |
| [File Protector Example](https://www.easefilter.com/kb/file-protector-demo.htm) | Prevent sensitive files from being accessed by unauthorized users or processes. |
| [FolderLocker Example](https://www.easefilter.com/kb/FolderLocker.htm) | Lock file automatically in a FolderLocker. |
| [Process Monitor](https://www.easefilter.com/kb/Process-Monitor.htm) | Monitor the process creation and termination, block unauthorized process running. |
| [Registry Monitor](https://www.easefilter.com/kb/RegMon.htm) | Monitor the Registry activities, block the modification of the Registry keys. |
| [Secure Sandbox Example](https://www.easefilter.com/kb/Secure-Sandbox.htm) |A secure sandbox example, block the processes accessing the files out of the box. |
| [FileSystemWatcher Example](https://www.easefilter.com/kb/FileSystemWatcher.htm) | File system watcher, logging the file I/O events. |

## Filter Driver Reference

* Understand MiniFilter Driver: https://www.easefilter.com/kb/understand-minifilter.htm
* Understand File I/O: https://www.easefilter.com/kb/File_IO.htm
* Understand I/O Request Packets(IRPs):https://www.easefilter.com/kb/understand-irps.htm
* Filter Driver Developer Guide: https://www.easefilter.com/kb/DeveloperGuide.htm
* MiniFilter Filter Driver Framework: https://www.easefilter.com/kb/minifilter-framework.htm
* Isolation Filter Driver: https://www.easefilter.com/kb/Isolation_Filter_Driver.htm

## Support
If you have questions or need help, please contact support@easefilter.com 

[Home](https://www.easefilter.com/) | [Solution](https://www.easefilter.com/solutions.htm) | [Download](https://www.easefilter.com/download.htm) | [Demos](https://www.easefilter.com/online-fileio-test.aspx) | [Blog](https://blog.easefilter.com/) | [Programming](https://www.easefilter.com/kb/programming.htm)
