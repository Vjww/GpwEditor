
THIS IS WELL OUT OF DATE!

DataContexts                     DirectAccess
     |                                |
     |                                |
Repositories ------------------ DataEndpoints ---- DataConnections
     |                                |
     |                                |
  Entities ---- Import/Export ---------
                      |               |
                      |               |------ Streams ------|
                DataLocators          |                     |----- Files
				                      |----- Catalogues ----|

Catalogues - These classes hold a structured representation of data retreived from a stream
DataConnections - These classes hold configuration values to connect to data files on disk
DataContexts - These classes hold in memory representation of the data structure
DataEndpoints - These classes hold references to catalogues/streams
DataLocators - These classes hold the locations of data stored in catalogues/streams
Entities - These classes make up each record in a repository
EntityExporters - These classes export entities to catalogues/streams
EntityImporters - These classes import entities from catalogues/streams
FileResources - These classes provide file input output capability
Repositories - These classes hold a list of entity records
Streams - These classes provide stream capability

To add a new module:
- Add a new Entity class that will hold the game data
- Add a new EntityExporter class that will export game data to a data endpoint
- Add a new EntityImporter class that will import game data from a data endpoint
- Add a new DataLocator class that will locate the game data in the data endpoint
- Add a new Repository to the DataContext class
