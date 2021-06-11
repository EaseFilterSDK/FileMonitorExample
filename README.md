# FileMonitorExample
A C# File Monitor Example With File Monitor Filter Driver SDK
File Monitor Filter Driver SDK is a kernel-mode component that runs as part of the Windows executive above the file system. The file system filter driver can intercept requests targeted at a file system or another file system filter driver. By intercepting the request before it reaches its intended target, the filter driver can extend or replace functionality provided by the original target of the request. The EaseFilter file system filter driver can log, observe, modify, or even prevent the I/O operations for one or more file systems or file system volumes.

![File Monitor](https://www.easefilter.com/images/MonitorFilter.png)

This C# example creates a filter rule to watch the directory specified at run time. The component is set to watch for all file change in the directory. If a file was changed, the file name, file change type, user name, process name will be printed to the console. The component also is set to watch the file open and file read IO, the IO was triggered, the file open and file read information will be printed to the console.
