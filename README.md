# WindowsInformation

Attempt to make general windows information available using REST API in C#.

Web API is available on port: 8085

Current features:
- Get network files currently in use.
  - <b>http://{hostname}/api/file</b>           retrieves information for all files.
  - <b>http://{hostname}/api/file?path=x</b>    retrieves information for path x.



# System configuration

For files to be monitored, ensure **Maintain Objects List** is enabled. 
Execute "openfiles /local on" to ensure this.
