# Klinik.Application Folder Structure Guidelines (Business/Application Logic)

## Should only reference Domain implementations

## Purpose: defines what the system does - use cases, coordination, and workflows
	### can contain Use case handlers (CreateUser, GenerateReport), Application services (e.g., UserService), DTOs (input/output models), Interfaces (e.g., IEmailService), Validators

	### does NOT contain UI rendering, actual database or email implementations

* Interfaces
	*	IService interfaces

* Services
	*	Business logic implementation

* DTOs
	*	request/response models

* UseCases
	*	specific use-case implementations

* Validators
	*	centralized custom validators 