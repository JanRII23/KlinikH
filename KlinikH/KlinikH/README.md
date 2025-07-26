# Klinik.Web Folder Structure Guidelines (Presentation Layer)

## should only reference Application implementations

## Purpose: The entry point for users or clients — web UI, Web API, Blazor, etc.
    ### can contain Controllers, Views or Razor pages, UI-specific ViewModels, Swagger, routing, etc.

* Controllers
	* HomeControllers.cs
	* AccountController.cs 

* Views
	* Shared/
	* Home/
	* Account/

* wwwroot
	* static files (CSS, JS, images)

* Models
	* ViewModels, DTOs, and etc. in the web layer
	* leverage DTOs to prevent leaking domain models into the web layer

* Middleware
	* Custom middleware

* Filters
	* Custom Action filter

* appsettings.json

* programs.cs
