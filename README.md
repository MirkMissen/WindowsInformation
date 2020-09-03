# WindowsInformation

Attempt to make general windows information available using RESAT API in C#.

Web API is available on port: 8085

Current features:
- Get network files currently in use.
  - http://{hostname}/api/files           retrieves all files.
  - http://{hostname}/api/files?path=x    retrieves information for path x.
