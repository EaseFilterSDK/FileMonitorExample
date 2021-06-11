# FileMonitorExample
A C# File Monitor Example With File Monitor Filter Driver SDK
File Monitor Filter Driver SDK is a kernel-mode component that runs as part of the Windows executive above the file system. The file system filter driver can intercept requests targeted at a file system or another file system filter driver. By intercepting the request before it reaches its intended target, the filter driver can extend or replace functionality provided by the original target of the request. The EaseFilter file system filter driver can log, observe, modify, or even prevent the I/O operations for one or more file systems or file system volumes.

![File Monitor](https://www.easefilter.com/images/MonitorFilter.png)

The file I/O monitor can audit file access and change in Windows in Real-Time. With the file monitor you can monitor the file activities on file system level, capture file open, create, overwrite, read, write, query file information, set file information, query security information, set security information, file rename, file delete, directory browsing and file close I/O requests. You can create the file access log, you will know who, when, what files were accessed. You can get comprehensive control and visibility over users and data by tracking and monitoring all the user & file activities, permission changes, storage capacity and generate real-time audit reports.

This C# example creates a filter rule to watch the directory specified at run time. The component is set to watch for all file change in the directory. If a file was changed, the file name, file change type, user name, process name will be printed to the console. The component also is set to watch the file open and file read IO, the IO was triggered, the file open and file read information will be printed to the console.

Here is the output from the file monitor example.

![File Monitor output](https://www.easefilter.com/Images/MonitorConsole.png)
