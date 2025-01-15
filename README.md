# Unity-3D-Maze-Game

Welcome to the "Unity 3D Maze Game" repository, an interactive 3D game created as a learning project for the course **Computer Graphics and Interaction Systems**. This project was developed to explore core concepts in game development using **Unity** and **C# scripting**. The final grade of the project was **93/100** (excluding the additional 50 bonus points).

## Game Overview
The game is a 3D maze-based adventure where players control a character, "Treasure Bob," to navigate through a maze, collect treasures, and avoid traps. The project focuses on gameplay mechanics, object interactions, and visual/audio enhancements to deliver an engaging experience.

## Key Features
- **Interactive Maze Navigation**: Players control "Treasure Bob" to move through the maze while avoiding walls.
- **Dynamic Treasure Spawning**: Randomly generated treasures with varying scores and visual effects.
- **Score System**: A live score tracker updates dynamically based on collected treasures.
- **Trap Mechanics**: Randomly spawning traps that end the game upon collision.
- **Camera Controls**: Free camera movement for exploring the maze environment.
- **Visual and Audio Enhancements**: Includes sound effects and visual cues for interactions.
- **Game Over Screen**: Provides clear feedback when the game ends.

## Implementation Details
### Environment
- **Floor**: A textured plane (100x100) using a `floor.jpg` texture.
- **Walls**: Blue cubes (10x10x10) arranged to form the maze structure.

### Character
- **Treasure Bob**: A spherical character (diameter 7) textured with `bob.jpg`. Bob is controlled with the keys `I`, `K`, `J`, and `L` for directional movement. Movement is constrained within the maze using collision detection.

### Treasures
- Spawned at random locations with textures such as cherries, lemons, and oranges.
- Each treasure type awards different points.
- Treasures shrink and disappear upon collection, accompanied by sound and visual effects.

### Traps
- Randomly spawning spheres textured with `death.jpg` that trigger the "Game Over" state upon collision.

### Camera
- Fully controllable camera for exploring the maze:
  - Movement: Arrow keys or `W`, `A`, `S`, `D`.
  - Vertical adjustment: `+` and `-`.
  - Rotation: `R`.

### Bonus Features
- Adjustable movement speed for Treasure Bob using number keys (`1–5`).
- Real-time score updates displayed on the UI.

## Scripts Overview
- **moveBob.cs**: Handles character movement and collision logic.
- **TreasureSpawner.cs**: Spawns treasures periodically at random positions.
- **CollectItems.cs**: Manages interactions between Treasure Bob and treasures, including scoring and effects.
- **DeathTrapSpawner.cs**: Spawns traps randomly and destroys them after a set time.
- **DeathTrapCollision.cs**: Ends the game when Treasure Bob interacts with traps.
- **ScoreManager.cs**: Tracks and updates the player's score.
- **CameraController.cs**: Enables camera movement and rotation.

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/SpanouMaria/Unity-3D-Maze-Game.git
   cd Unity-3D-Maze-Game
   ```
2. Open the project in Unity.
3. Run the game in the Unity Editor or build it for your target platform.

## Collaboration
This project was a collaborative effort. Special thanks to **** for their significant contributions to the development and improvement of the game. If you have any questions, feel free to reach out to us via our GitHub profiles.
