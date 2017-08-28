
  Database                      Direct
     |                             |
     |                             |
Repositories ---------------- DataSources
     |                             |
     |                             |
  Entities ---- Populators ---- Streams ----- Files
                    |
                    |
                 Mappers

Database - contains repositories
Repositories - contains entities
Entities - contains game data

Direct - access to memory streams
DataSources - data source for the editing context
Streams - loads/saves data from/to files
Files - contains game data

Populators - imports/exports entities from/to memory streams
Mappers - where to find the values in the game files
