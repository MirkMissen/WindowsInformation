# WindowsInformation

Attempt to make general windows information available using RESAT API in C#.

Web API is available on port: 8085

Current features:
- Get network files currently in use.
  - <b>http://{hostname}/api/files</b>           retrieves all files.
  - <b>http://{hostname}/api/files?path=x</b>    retrieves information for path x.
