# Klinik.Domain Folder Structure Guidelines (Core Domain Layer)

## Purpose: the core of the system, it defines what the system is not what it does
    ### can contain Entities (User, Order, etc.), Value Objects (Money, Email, etc.), Domain Services (pure business logic), Domain Interfaces (e.g., IUserRepository), Business rules and constraints

	### does NOT contain database access, HTTP requests, UI logic

* Entities
	* Core business entities (e.g. User, Order)

* ValueObjects
 	* Email, Money, etc...

* Enums
 	* Const, etc...

* Interfaces
 	* Domain-level contracts (e.g., IAggregate Root)

* Events
 	* Domain events

* Specifications
 	* Encapsulate queries
