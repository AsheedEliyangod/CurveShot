# ⛳ CurveShot - Hyper Casual Mini Golf Game

![Unity](https://img.shields.io/badge/Unity-6-black?logo=unity)
![Platform](https://img.shields.io/badge/Platform-Android-green)
![Language](https://img.shields.io/badge/C%23-Programming-blue)
![Pipeline](https://img.shields.io/badge/Render%20Pipeline-URP-orange)

A physics-based **hyper-casual mini golf game** developed using **Unity 6** for **Android**.

CurveShot was created as part of a **Unity Game Developer Technical Assignment**, showcasing mobile gameplay programming, physics simulation, touch controls, UI development, and Android deployment.

---

# 📥 Download APK

Download the latest Android APK:

📱 **APK Download**

https://drive.google.com/file/d/1bWBwjEjgaYTkwxxsdNVKn97pIeupkjDy/view?usp=sharing

---

# 🎮 Gameplay

The objective is simple but engaging:

- 🎯 Drag to aim the golf ball.
- 💪 Adjust the shot power.
- 🚀 Release to launch the ball.
- 🌀 Curve around obstacles.
- ⛳ Reach the hole to complete the level.

The game emphasizes precision, timing, and satisfying physics-based gameplay.

---

# ✨ Features

- 🎯 Drag-and-release aiming system
- ⛳ Physics-based golf ball movement
- 🌀 Curved shot mechanic
- 🌳 Stylized low-poly environment
- 🕳️ Hole completion detection
- 📱 Android support
- 📐 Landscape orientation
- 🎵 Main Menu UI
- ⚡ Mobile optimized

---

# 📱 Controls

| Action | Control |
|---------|----------|
| Aim | Drag on the screen |
| Adjust Power | Increase drag distance |
| Shoot | Release finger |

---

# 📸 Screenshots

<p align="center">
  <img src="Screenshots/Menu.jpeg" width="45%" alt="Main Menu">
  <img src="Screenshots/game.jpeg" width="45%" alt="Gameplay">
</p>

---

# 🎥 Gameplay Video

Watch the gameplay demonstration:

▶️ https://drive.google.com/file/d/1lc8FCdkJ8EAFvA9BaG4q9Md5GiZBenBk/view?usp=sharing

---

# 🛠 Built With

- Unity 6 (6000.4.7f1)
- C#
- Universal Render Pipeline (URP)
- Unity Physics
- Unity UI System
- Android Build Support

---

# ⚙️ Implementation Approach

The game uses Unity's Rigidbody physics system to create a realistic mini golf experience.

- Players drag on the screen to choose direction.
- Drag distance determines shot power.
- Releasing the touch applies force to the golf ball.
- Unity Physics handles movement, momentum, collisions, and rolling naturally.
- The hole uses a trigger collider to detect successful completion.

The project follows a modular structure with separate scripts handling input, gameplay, UI, and game flow.

---

# 🧩 Surface Interaction Logic

The golf ball interacts entirely through Unity Physics.

- Rigidbody controls movement.
- Colliders define the course boundaries.
- Gravity allows the ball to roll naturally.
- Surface angles influence ball direction.
- Correct shots follow the curved path toward the hole.
- Incorrect power or direction results in failure, encouraging precision.

No scripted movement is used after launch; the gameplay relies on physics simulation.

---

# 📂 Project Structure

```
Assets/
│
├── Audio/
├── GolfAssets/
├── Materials/
├── Models/
├── Particles/
├── Prefabs/
├── Scenes/
├── Scripts/
├── UI/
└── Screenshots/

Packages/

ProjectSettings/
```

---

# 🚀 Getting Started

## Requirements

- Unity 6 (6000.4.7f1)
- Android Build Support
- Visual Studio 2022

---

## Clone Repository

```bash
git clone https://github.com/AsheedEliyangod/CurveShot.git
```

Open the project using:

```
Unity 6 (6000.4.7f1)
```

Open the main scene:

```
Assets/Scenes/MainScene
```

Click **Play** inside the Unity Editor to test the game.

---

# 📦 Building for Android

To generate the APK:

```
File
→ Build Profiles
→ Android
→ Build
```

Install the generated APK on an Android device.

---

# 🎯 Implemented Mechanics

- Drag aiming system
- Shot power calculation
- Physics-based golf ball movement
- Curved trajectory
- Rigidbody physics
- Collision detection
- Hole trigger detection
- Mobile touch controls
- Scene Management
- Android deployment

---

# 🚧 Challenges Faced

During development, several challenges were encountered:

- Balancing shot power for consistent gameplay.
- Fine-tuning Rigidbody values for smooth movement.
- Designing a curved course that feels natural.
- Optimizing touch controls for mobile devices.
- Testing gameplay across different Android screen sizes.

---

# 📚 What I Learned

This project helped me improve my skills in:

- Unity mobile game development
- Rigidbody physics
- Touch input handling
- Mobile UI design
- Scene management
- Android deployment
- Mobile optimization
- Git & GitHub workflow
- Project organization

---

# 📈 Future Improvements

- 🎮 More challenging levels
- 🏆 Score system
- 📊 Shot counter
- ⏱ Timer mode
- 🔊 Sound effects
- 🎵 Background music
- 📋 Level selection
- ⏸ Pause menu
- ✨ Particle effects
- 🌍 Leaderboards
- 📈 Difficulty progression

---

# 📁 Repository Structure

```
Assets/
Packages/
ProjectSettings/
Screenshots/
README.md
.gitignore
```

---

# 👨‍💻 Developer

## Asheed Eliyangod

Game Developer passionate about creating immersive gameplay experiences using **Unity** and **Unreal Engine**.

### GitHub

https://github.com/AsheedEliyangod

---

# 📄 License

This project was developed for educational purposes as part of a Unity Game Developer technical assignment.

Feel free to explore the project and provide feedback.

---

# 🙏 Acknowledgements

- Unity Technologies
- Unity Asset Store
- Free stylized assets used for environment creation

---

# ⭐ Support

If you enjoyed this project, consider giving the repository a **⭐ Star**.

It motivates me to continue building and sharing more game development projects.

---

# 🚀 More Projects Coming Soon

I'm continuously learning and building new projects in **Unity** and **Unreal Engine**. Stay tuned for more!

---

## Thank You for Visiting! ❤️
