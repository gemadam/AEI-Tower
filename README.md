# AEI Tower

## Description of the project

AEI Tower is a Icy Tower remake inspired by the day-to-day reality of students of the [Faculty Of Automatic Control, Electronics And Computer Science](https://www.polsl.pl/rau/en). 
The game consists in controlling a character representing a student of the AEI faculty as he/she makes his/her way to the top of the Mage Tower by jumping on successive stairs and advancing to successive floors of the faculty. The character is controlled with the keyboard. It is a platform game set in a tower, where the player's goal is to jump from one "floor" to the next and go as high as possible without falling and plunging off the screen.

Platforms are grouped to levels - each in distinct color according to the colors of the faculty floors.
On each platform there is randomly generated challenge which student faces in his day-to-day life (such as rejected report or unexpected quiz on the platform). Player has to collect 30 ECTS on each floor to level up. If player falls before collecting 26 ECTS on the level the game is over, otherwise he can use conditional pass, and collect missing points in order to complete level.

![AEI Tower concept](/Docs/Img/AEI-Tower-concept.png)

## Task analysis

### Theoretical basis of the problem

The movement of the character on the floor will be described by the sum of two vectors - horizontal and vertical. Sum of this two movements will be maginfied by some factor which will depend on the length of the period of pressing the space button.

![Sum of the vectors](/Docs/Img/400px-Perpendicular_Vector_Addition.jpg)

While in the air player will only be able to control horizontal movement.

### Computer graphics topics

Project mostly utilize the knowledge from laboratories about collision detection, computer animation and colors. Game is implemented in C# with use of Unity engine.


## Schedule

| Person             | 30-03-2022                          | 11-05-2022                 | 22-06-2022                  |
|--------------------|-------------------------------------|----------------------------|-----------------------------|
| Malika Uskembayeva | Theoretical analysis of the project | Beta version of game logic | Final version of game logic |
| Adam Gembala       | Theoretical analysis of the project | Beta version of game logic | Final version of game logic |
| Robert Lotawiec    | Theoretical analysis of the project | Beta version of assets     | Final version of assets     |


## Project organization

### Workflow

![Workflow of the project](/Docs/Img/ProjectWorkflow.png)



## Useful links

### Project organization

[Jira Project](https://aei-tower.atlassian.net)

### Resources

[Postacie Icy Tower](https://download.icy.pl/postacie1.php)

[Forum Icy Tower](https://forum.icy.pl)

[Wikipedia](https://pl.wikipedia.org/wiki/Icy_Tower)