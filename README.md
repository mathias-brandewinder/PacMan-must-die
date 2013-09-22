PacMan-must-die
===============

A WPF PacMan game, modified so that both PacMan and the Ghosts are driven by a simple AI code.
The goal was to create a playground to experiment with designing an AI. 

The solution is broken down into 3 projects:
* PacMan.XAML: the WPF game itself,
* PacMan.Core: definition of the core types used for the AI,
* PacMan.AI: concrete implementation of PacMan and the Ghosts.
A minimal implementation of 2 AIs is included; running PacMan.XAML should start a PacMan game.

The original code has been entirely lifted off existing work by the awesome Phil Trelford (@ptrelford),
whose blog can be found here: http://trelford.com/blog/
