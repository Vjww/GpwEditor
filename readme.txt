To add a new module...

For the Data layer:
- add a data entity
- add a data locator
- add a data entity importer
- add a data entity exporter
- modify data service to include repository, importer and exporter

For the Domain layer:
- add a domain entity
- add a domain entity validator
- modify domain service to include repository and entity validator
- add methods to domain service to expose data to consumers

For the Infrastructure layer:
- add concrete repositories for data repositories
- add concrete repositories for domain repositories
- add object maps between data entities and domain entities

For the Console Presentation layer:
- add view model
- add view
- add/modify controller
- add object maps between domain entities and view models

For the Dependancy Injection layer:
- add singleton registrations for data entities, locators and domain entities
