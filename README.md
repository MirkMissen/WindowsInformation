# WindowsInformation

Attempt to make general windows information available using REST API in C#.

Web API is available on default port: 8085

# Current features:
Get network files currently in use.

    http://{hostname}/api/file

Headers [Key: Value]:

    FileName: Something.pdf
    Path: c:/folder/Something.pdf

# Arguments

Using TopShelf argument syntax: "-foobar:Test"

    -port:8085

# System configuration

For files to be monitored, ensure **Maintain Objects List** is enabled. 

    Execute "openfiles /local on" to ensure this.
