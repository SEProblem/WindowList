# WindowList

A slightly more complex demo to show an inneficient solution to a problem solved in many different, better ways.

Is a debugger running?  If it's in the list then yeah.

### Features:
   * Scans every process title for a token in the word list.
   * Ever word is tokenized in a line unless the line starts with '~'
   * Every word is case-insensitive unless the first char is '!' in the string.  i.e. "!tEsT" will be checked as "tEsT"
   * allows for list to be added to or subtracted from while running, just make sure to edit the "programs.txt" that is found in the same directory as the ACTUAL executable, not source.
   
   That's it, a dumb solution to a dumb problem; but slightly more versatile.  You could actually use this for something useful if you think hard enough of that I am sure.
   
