
 DbContext                   DirectContext
     |                             |
     |                             |
Repositories ---------------- DataSources
     |                             |
     |                             |
  Entities ---- Populators ---- Streams ----- Files
                    |
                    |
                 Mappers

//DbContext - collection of repositories

RepositoryManager - collection of repositories
Repositories - collection of entities

DataSources - data source for the editing context

Entities - objects to store game data
Populators - imports/exports entities from/to memory streams
Streams - imports/exports data from/to files

Mappers - where to find the values in the game files.

Services - largely memory stream and file services
