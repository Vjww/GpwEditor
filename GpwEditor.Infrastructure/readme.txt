
 Databases                      Direct
     |                             |
     |                             |
Repositories ---------------- DataSources
     |                             |
     |                             |
  Entities ---- Populators ---- Streams ----- Files
                    |
                    |
               ValueMappers

Databases - contains repositories
Repositories - contains entities
Entities - contains game data

Direct - access to memory streams
DataSources - data source for the editing context
Streams - loads/saves data from/to files
Files - contains game data

Populators - imports/exports entities from/to memory streams
ValueMappers - where to find the values in the game files

To add a new module:
- Add a new entity class that will hold the game data
- Add a new value mapper class that will locate the game data
- Add a new populator class that will move the game data
- Add a new repository variable to the database class and integrate