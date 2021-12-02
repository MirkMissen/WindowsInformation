# WindowsInformation

Attempt to make general windows information available using REST API in C#.

Web API is available on default port: 8085

# Features list:
Get network files currently in use.

    http://{hostname:port}/api/file

Headers [Key: Value]:

1. FileName: Something.pdf
2. Path: c:/folder/Something.pdf

# System configuration

For files to be monitored, ensure **Maintain Objects List** is enabled.

Execute following command in CMD:

    openfiles.exe /local on

# Process arguments

Using TopShelf argument syntax: "-foobar:Test"

    -port:8085
