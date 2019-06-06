# SimpleHTTPServer .NET
.NET Core cross-platform application that works as python2 SimpleHTTPServer module, but published as single binary and support https. 

Only support pfx file as private key. 

Current working directory will be used as `webroot` directory. 

If `index.html` exists it will be hosted instead of directory listing.

## Usage

### HTTP

Open command prompt or terminal:

`shsn [port]`

Example: 

`shsn.exe 8080`

### HTTPS

`shsn [port] [pfx-file] [pfx-password]`

Example:

`shsn.exe 9000 "C:\Users\Admin\My Certs\localhost.pfx" 1234`

