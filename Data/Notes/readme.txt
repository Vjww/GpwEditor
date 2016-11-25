Project notes
-------------
There are some inefficiencies in the way data is written to file.
These inefficiencies are done deliberately to simplify application architecture.
For example, files are constantly opened and closed between data reads and writes.
The language file, for every open and close, is copied to a string list, modified and then copied back to the language file.
The DataAccess layer retreives the file paths from the application properties/settings file.
The UI must ensure the file paths are set correctly prior to calling methods in the DataAccess layer.

The UI binds collections of GameObjects to the data grids on the form.
When importing, the DataAccess layer populates each GameObject, and the UI binds the collection of populated GameObjects. 
When exporting, the DataAccess layer uses each GameObject in the modified collection to populate the destination.

What values are randomly set on game start up?
* Department staff numbers and staff available for hire
* Technology ratings

Track length data are string values from language file
Track number of laps can be changed in the executable (limited by 2hr race mark).

Offsets for 2hr race limit (each hold a value of 7200000sss = 120m x 60000sss)
365473
378425 - seems to give the first driver over the line a second lap on the race results screen?
381542 - seems to invoke the actual cut off of the race once the cars cross the line after the time has elapsed
718660
722493
