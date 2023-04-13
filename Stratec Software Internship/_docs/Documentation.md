# Documentation

## Stage One – Starting Off Slowly

Taking a look at **Input_One.txt**, one can observe that it has a consistent structure. Therefore, some classes can be made, which would help parse the file.

I have chosen to use the following keywords to describe the structure in the file:

- Empty (*purely empty line*)
- Comment (e.g. *"# This is a comment"*)
- Section (e.g. *"Available machines"*)
- Item (e.g. *"Machine One"*)
- ListItem (e.g. *" - capacity: one part at a time"*)

To further understand the file, the function `ReadAndParseFile` will read and process each line. The function `ParseLine` return the type of line (for instance if )
