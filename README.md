# mail-library

Personal library for dotnet mailing


## Features

* Support multiple email providers
	- [ ] OAuth: Microsoft Graph
	- [ ] OAuth: GoogleApis
	- [ ] SMTP

- [ ] Send email
	- [ ] To, Cc and Bcc
	- [ ] Body templates
	- [ ] Support attachements
		- [ ] Mail attachements
		- [ ] In-body attachements
- [ ] Read mailbox
	- [ ] List all email
		- [ ] Filter by read status
		- [ ] Filter by sender
		- [ ] Filter by subject
		- [ ] Filter by date
	- [ ] Read specific email
		- [ ] Read content
		- [ ] Download attachements
- [ ] Util
	- [ ] Testing capabilities
		- [ ] Test authentication
		- [ ] Test network

## How to use

Create an authentication provider
```
provider.Build();
```

Send email
```
emailMessage.Send();
```

Read mailbox
```
mailbox.ReadAll();
```
