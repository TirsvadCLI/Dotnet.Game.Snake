[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<br />
<div align="center">
    <a href="https://github.com/TirsvadCLI/CSharp.Game.Snake">
        <img src="logo/logo.png" alt="Logo" width="80" height="80">
    </a>
    <h3 align="center">Snake Game</h3>
    <p align="center">
    A classic snake game for windows console and linux console
    <br />
    <br />
    <!-- PROJECT SCREENSHOTS -->
    <a href="https://github.com/TirsvadCLI/CSharp.Game.Snake/blob/master/images/Screenshot_menu.png">
        <img src="images/Screenshot_menu.png" alt="The game" height="120">
    </a>
    <a href="https://github.com/TirsvadCLI/CSharp.Game.Snake/blob/master/images/Screenshot_snakeGame.png">
        <img src="images/Screenshot_snakeGame.png" alt="The game" height="120">
    </a>
    <a href="https://github.com/TirsvadCLI/CSharp.Game.Snake/blob/master/images/Screenshot_highscore.png">
        <img src="images/Screenshot_highscore.png" alt="The game" height="120">
    </a>
    <br />
    <a href="https://github.com/TirsvadCLI/CSharp.Game.Snake"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/TirsvadCLI/CSharp.Game.Snake/issues/new?labels=bug&template=bug-report---.md">Report Bug</a>
    ·
    <a href="https://github.com/TirsvadCLI/CSharp.Game.Snake/issues/new?labels=enhancement&template=feature-request---.md">Request Feature</a>
    </p>
</div>

# Snake Game
This is a simple snake game for windows console and linux console. It's written in C# and uses .NET 9

## Table of Contents

- [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Build and Run](#build-and-run)
- [Features](#features)
- [Roadmap](#roadmap)
- [Folder Structure](#folder-structure)

## About The Snake Game

This is a simple snake game for windows console and linux console. It's written in C# and uses .NET 9

Snake eat food and grow. The game is over if the snake hits the wall or itself.

Food gives points.

- Food 🍎 gives 10 points.
- Food 🍌 gives 11 points.
- Food 🍒 gives 12 points.

Food is placed randomly on the board. Food size is more than one field so you have to cath the left side of the food to eat it.

The snake can move up, down, left and right.

The score is shown in the top.

## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.

- .NET 9.0
    ```
    https://dotnet.microsoft.com/download/dotnet/9.0
    ```

- Visual Studio 2022
    ```
    https://visualstudio.microsoft.com/
    ```

### Build and Run

1. Clone the repo
    ```
    git clone git@github.com:TirsvadCLI/CSharp.Game.Snake.git
    ```

2. Open the project in Visual Studio 2022

3. Build the project

4. Run the project

5. Use the arrow keys to move the snake

## Features

- [x] Windows console support
- [x] Linux console support
- [x] Score system
- [x] Save and load highscore
 
## Roadmap
- [ ] Add more food types
- [ ] Add bad food which reduce score (time limited witch it change food type)
- [ ] Speed up game when snake eat food

## Change Log

Version 1.1.0
- Add Frame for HighScore Board
- Add Frame for input name for new HighScore
- Add menu for new game, highscore and exit
Version 1.0.0
- Add game over Board
- Add highScore Board

## Folder Structure

```
CSharp.Game.Snake/          # Root folder that contains the solution
    |
    |---Snake/              # Contains the project
          |---Model/        # Contains the models
    |---images/             # Contains images
    |---logo/               # Contains the logo
```

<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/TirsvadCLI/CSharp.Game.Snake?style=for-the-badge
[contributors-url]: https://github.com/TirsvadCLI/CSharp.Game.Snake/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/TirsvadCLI/CSharp.Game.Snake?style=for-the-badge
[forks-url]: https://github.com/TirsvadCLI/CSharp.Game.Snake/network/members
[stars-shield]: https://img.shields.io/github/stars/TirsvadCLI/CSharp.Game.Snake?style=for-the-badge
[stars-url]: https://github.com/TirsvadCLI/CSharp.Game.Snake/stargazers
[issues-shield]: https://img.shields.io/github/issues/TirsvadCLI/CSharp.Game.Snake?style=for-the-badge
[issues-url]: https://github.com/TirsvadCLI/CSharp.Game.Snake/issues
[license-shield]: https://img.shields.io/github/license/TirsvadCLI/CSharp.Game.Snake?style=for-the-badge
[license-url]: https://github.com/TirsvadCLI/CSharp.Game.Snake/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/jens-tirsvad-nielsen-13b795b9/
