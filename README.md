# Pongtitlan — Unity Project

A 2D physics-based Pong game built in Unity, featuring two players, configurable match settings via ScriptableObjects, and a full menu system (Main Menu, Pause Menu, Settings, Win screen).

## Features

### Core Gameplay

* **Two players**, one on the left side and one on the right side of the field.

  * **Player 1** moves with `W` / `S`/ `D`/ `A`
* **Player 2** moves with the `Up Arrow` / `Down Arrow` / `Right Arrow`/ `Left Arrow` keys.
* Both players are always clamped to their own side of the field (center line and their respective goal).
* Each player has its own sprite/visual variant.
* All moving objects (players, ball) use **Rigidbody2D physics** (`AddForce`) instead of direct transform manipulation, and all movement is frame-rate independent (`Delta Time` / `Time.fixedDeltaTime`).
* The ball launches in a random direction at the start of each round and increases its speed over time and/or on impact with a paddle.
* Player position is clamped to the playable field (players cannot cross the center line or leave the screen bounds).

### Visual Feedback

* When a player's paddle hits one of the screen's boundary limits, its color changes to **black**.
* When a player's paddle hits the ball, its color changes **randomly**.

### Scenes \& Menus

* **Main Menu** scene, with access to Play, Settings, Credits, and Exit.
* **Pause Menu**, accessible mid-game with the scape Key, which pauses the game (`Time.timeScale = 0`).
* **Settings screen** (pauses the game while open), allowing configuration of:

  * Player movement speed.
  * Paddle size/height.
  * Player color.
* **Win screen**, displayed when a player reaches the required number of rounds to win, with options to return to the Main Menu or exit.

### Match Rules

* Matches can be configured as **Best of 3, 5, or 7** (rounds to win = 2, 3, or 4 respectively), configurable through a `GameSettings` ScriptableObject and in the Settings panel in runtime.
* A **time limit** (configurable, default 20 seconds) restricts how long the ball can remain on a player's side of the field. If the timer runs out, a goal is automatically awarded to the opposing player. This limit is also configurable through the `GameSettings` ScriptableObject and in the Settings panel in runtime.

### Architecture \& Code Quality

* **ScriptableObjects** are used for all initialization/configuration data, decoupling game data from scene-specific logic:

  * `PlayerDataSo`: movement keys, speed options, paddle/variant prefabs, and color options.
  * `GameSettingsSo`: rounds to win and max time per side.
  * `ScoreDataSo`: tracks and broadcasts score changes for both players.
* Code follows consistent naming conventions, readable structure, and separation of concerns across scripts (movement, visuals, UI, scoring, collisions).
* Marker components (e.g. `BallMarker`, `PaddleMarker`, `LimitMarker`) are used instead of string-based tags for collision/trigger identification, providing compile-time safety.

## Controls

|Action|Player 1|Player 2|
|-|-|-|
|Move Up|`W`|`↑`|
|Move Down|`S`|`↓`|
|Move Left|`A`|`←`|
|Move Right|`D`|`→`|

## Credits
* Game Dev Yeimy Rojas. 
* Pixel Artist Aurora Salazar.

 ## Notes
 Thanks to LuisCanary for his playlist on YouTube about the creation of a Pong: https://www.youtube.com/watch?v=Zro8IkFkXUc
 During the development of this project, artificial intelligence tools were used as support for resolving questions, understanding concepts, and reviewing code. AI was primarily used as a reference and learning resource, providing explanations of programming structures, syntax, and possible solutions to problems encountered during development. No code was directly copied from AI-generated responses; the code implemented in the project was written and developed by the author based on their own understanding and adapted to the specific needs of the project.
 

* Contact: 
* Yeimy Rojas The Midnight Baker.
* https://www.artstation.com/yeimy24401

