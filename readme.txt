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
- add/modify domain service to include repository and entity validator
- add methods to domain service to expose data to consumers

For the Infrastructure layer:
- add concrete repositories for data repositories
- add concrete repositories for domain repositories

For the Application layer:
- add/modify domain model export service
- add/modify domain model import service
- add object maps between data entities and domain entities

For the Console Presentation layer:
- add a view model
- add a view
- add/modify a controller
- add object maps between domain entities and view models
- add controller to application class and invoke display method
