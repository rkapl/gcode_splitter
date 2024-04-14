# Splitter

This tools split a single g-code file on `M06` (tool change) lines int individual files.

It is tested & intented to be used as Estlcam "external preprocessor". It does not do any intelligent G-Code parsing
and assumes that each g-code section is standalone.

## Installation

Just download from the releases page, it is .NET executable.

## Syntax:

`gcode_splitter.exe g_code_file.nc`

Will produce files like `g_code_file_1.nc`.