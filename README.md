# :passenger_ship: Battleship :passenger_ship:

## About
This repository contains code to run the classic game; Battleship.<br>
The appplication was written in C#, using Visual Studio 2022.<br>

<img src="/Images/battleship1.png" alt="title screen" />

##

## Features
### Player Interface
At the beginning of the game, the user is prompted to select
a type of player.<br> Currently there are two different types of
players available: Human players or Computer players.<br>

<img src="/Images/battleship2.png" alt="selecting a player type" />

The user can play against another human, against a computer,
or even watch two computer players play against each other!
##

### Difficulty Modes

<img src="/Images/battleship3.png" alt="selecting a difficulty mode" />

If a computer player is selected, the user is prompted to select a difficulty level.<br>
The difficulty options are as follows:<br>
• Easy Mode: The computer fires a completely random shot.<br>
• Normal Mode: The computer scores a hit 30% of the time.<br>
• Hard Mode: The computer scores a hit 40% of the time.<br>
##

### :ship: Placing Ships :anchor:

<img src="/Images/battleship4.png" alt="placing a ship" />

After the play types are selected, the user will be prompted to place their ships.<br>
The order of ship placement is as follows:<br>
1. Aircraft Carrier (5 squares)<br>
2. Battleship (4 squares)<br>
3. Cruiser (3 squares)<br>
4. Submarine (3 squares)<br>
5. Destroyer (2 squares)<br>

Each ship placement will involve the user responding to two prompts:<br>
1. The starting coordinate: e.g. A1, D2, G3, etc.<br>
2. The placement direction: vertical or horizontal<br>
##

### :dart: Firing Shots

<img src="/Images/battleship5.png" alt="firing a shot" />

After the ships are placed, the user is prompted to select a coordinate to fire at.<br>

There are three results that can come from firing a shot:<br>
• Hit (A ship was hit)<br> 
• Miss (The shot missed)<br>
• Hit and Sunk (The last coordinate of a ship was hit. It is now sunk)<br>

If a player sinks an opponent's ship, they get one point added to their score<br>

<img src="/Images/battleship6.png" alt="scoring a point" />

The first player to five points wins the game.<br>
##

### :test_tube: Unit Tests

<img src="/Images/battleship7.png" alt="successful unit tests" />

This application is unit tested.<br>
Both the grid and the firing of shots have their own test classes.<br>
Check out the Battleship.Tests project above to see the code!<br>
##
