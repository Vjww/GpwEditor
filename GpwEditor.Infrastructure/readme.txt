
 Databases                   Direct
     |                          |
     |                          |
Repositories ------------- DataSources ---- Connections
     |                          |
     |                          |
  Entities ---- Mappers ---- Streams ------ Files
                   |
                   |
                Locators

Databases - contain repositories
Repositories - contain entities
Entities - contain game data

Direct - immediate access to files
DataSources - the editing context
Connections - the locations of files
Streams - loads/saves data from/to files
Files - contains game data

Mappers - imports/exports entities from/to streams
Locators - the locations of data in files

To add a new module:
- Add a new entity class that will hold the game data
- Add a new locator class that will locate the game data in the datasources
- Add a new mapper class that will move the game data between entities and datasources
- Add a new repository to the database class and integrate the module into the application