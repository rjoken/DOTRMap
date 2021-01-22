# DOTRMap
A map editor for Yu-Gi-Oh! The Duelists of the Roses

## Install
You can download the latest version of DOTRMap from the [Releases Page](https://github.com/rjoken/DOTRMap/releases).

This tool is only available natively for Windows. I have not tested with Wine - your mileage may vary.

## Usage
You can create, save and load maps without any additional requirements, though adding the maps into the game obviously requires an ISO to patch.

### Editor

Clicking on the "Editor" tab provides a WYSIWYG editor for creating DotR maps. Under the "File" menu, you can save and load map files in the ".dor" format.

On the left is a palette. By clicking on a tile in the palette, it will become the selected tile. By left-clicking anywhere in the map, the tile in the map will be replaced with the selected tile. If you right-click anywhere inside the map, the entire map will be filled with that tile.

Creating and saving maps to a file isn't very useful, though, as they aren't changed in the game. You can load an ISO or SLUS file (which can be extracted from a DotR ISO) to edit. Please be aware that only the NTSC-U version of the game is supported. An ISO file may take longer to load than a SLUS file. Loading either of these will enable the *Injector* functions.

### Injector

Once an ISO/SLUS has been loaded, you can click on any of the maps in the game in the list on the left, and by clicking "Load Selected", you can see that map in the Editor. You can also export it to a .dor file.

If you select an in-game map from the list, clicking "Inject Map" will replace that map in the game with whatever is currently shown in the editor tab. It will then ask you if you want to save over the ISO, incase you want to inject several maps and then save over it all at once, rather than save multiple times for each map you want to edit.

Clicking "Reload File" will load the ISO again, reverting any unsaved changes.

If you elect not to save when the tool asks you to when clicking "Inject Map", remember to save the changes through the *File* context menu before exiting.

## Current Features
* Editing, saving, and loading maps to/from a file (".dor").
* Load an ISO/SLUS205.15 file and load/edit maps from the game.
* Export maps from the game to a file.
* Inject edited maps into an NTSC-U ISO/SLUS of DotR.

## Planned Features
* ISO/SLUS integrity checking.
* Better/faster/more efficient ISO loading (current implementation is very lazy)

## License
This project is licensed under the [MIT License](https://github.com/rjoken/DOTRMap/blob/master/LICENSE).

## Acknowledgements
* GenericMadScientist - For his extensive research and documentation of Yu-Gi-Oh! The Duelists of the Roses which made this tool possible.
* Clovis - For providing motivation for the completion of this tool in order to aid with the creation of the [DotR Redux Mod](https://www.youtube.com/watch?v=E_Aa2xC0Gig), which if you're interested in this tool, you should check out.
