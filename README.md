# Ping-Pong

Arcade ping-pong built with Unity, playable in the browser (WebGL).

**Play it now:** https://marveee3.itch.io/ping-pong

## Features

- Three game modes: Player vs Player, Player vs AI, AI vs AI
- Neon visual style
- Score tracking and game over screen
- Keyboard controls

## Tech

- Unity 2022.3.16f1
- C# scripts
- WebGL build (Brotli compression)

## Project layout

- `Assets/Scripts/` — game logic (ball physics, paddles, AI, scoring, scenes)
- `Assets/Scenes/` — MainMenu, Game-P2P, Game-P2AI, Game-AI2AI, GameOver
- `Assets/WebGLTemplates/NeonPong/` — custom WebGL template (splash screen, fullscreen button)
- `Tools/remove_splash.py` — patches the WebGL build to remove the Unity splash screen
