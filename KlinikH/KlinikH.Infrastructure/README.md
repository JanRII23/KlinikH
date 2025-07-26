# Klinik.Infrastructure Folder Structure Guidelines (EF, 3rd party integration)

## Should implement interfaces from Application or Domain (not the other way around)

## Purpose: Handles technical concerns — how the system persists data, sends emails, logs messages, etc.
    ### can contain EF Core DbContext, Repository implementations, API integrations (external services), File system, SMTP, cloud services, Logging, caching

	### does NOT contain UI rendering, actual database or email implementations

* Data
	* ApplicationDbContext.cs
    * Migrations

* Repositories
 	* EfCore
    * ExternalServices

* Email
 	* SmtpEmailSender.cs

* Logging
 	* CustomLogger.cs

* Config
 	* DependencyInjection.cs