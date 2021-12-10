# Happy_Quokka

Markus Holmström 

This game is about a Happy Quokka (a vallaby-look a like mammal living in Australia), 
located in a 3D-universe but it can only move in 2D. It has weapons, a chainsaw and a katana, to fight against weird looking
enemies who are armed with selfiesticks and stupid phones. My plan was to create a system for game designers to create a 
game where the player can go to different scenes depending on the player's choice without any need for coding skills. 
The documentation to help build up something with this project for a game designer is miniscule right now, I have 
focused on getting the patterns implemented instead.

Patterns:
- Singleton, StoryManager and StateManager (classes).
Created singleton-instances for these two classes for easy access.
- StateMachine, EnemyState, State and StateManager (classes).
Just a proof of concept, keeps some in-game values and updates them when they get changed.
- Pooling objects, CloudManager (class).
Handles the clouds in the background, instantiates and reuses them.
- Factory, MapCreator, CloudManager and GameFactory (classes).
Generic factory that uses enum to identify GameObjects and to create them. Deals with clouds and enemies.
Could use some extra implementation and its really not necessary for game play.
- Probably has some other pattern hidden somewhere I hadnt thought about, but that doesnt count, does it?
