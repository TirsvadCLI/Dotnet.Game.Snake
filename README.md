﻿<!-- BADGES V1 -->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![downloads][downloads-shield]][downloads-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# ![Logo][Logo] Snake Game
This is a simple snake game for windows console and linux console. It's written in C# and uses .NET 9

[![Screenshot_menu][Screenshot_menu]][Screenshot_menu_url][![Screenshot_snakeGame][Screenshot_snakeGame]][Screenshot_snakeGame_url][![Screenshot_highscore][Screenshot_highscore]][Screenshot_highscore_url]

## Table of Contents

- [About The Snake Game](#about-the-snake-game)
- [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
    + [Optional for changing the code](#optional-for-changing-the-code)
  * [Build and Run](#build-and-run)
    + [Powershell](#powershell)
    + [Bash (Linux)](#bash--linux-)
- [Features](#features)
- [Roadmap](#roadmap)
- [Change Log](#change-log)
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

#### Optional for changing the code

- Visual Studio 2022
    ```
    https://visualstudio.microsoft.com/
    ```

#### Powershell

1. Open a powershell window and enter the following commands to download game

```powershell
# Define the URL and the destination file path
$url = "https://github.com/TirsvadCLI/Dotnet.Game.Snake/releases/download/1.1.2/Snake.zip"
$destination = "Snake.zip"
$unzipPath = "Snake"

# Download the file
Invoke-WebRequest -Uri $url -OutFile $destination

# Unzip the file
Expand-Archive -Path $destination -DestinationPath $unzipPath

# Remove the zip file
Remove-Item $destination
```

2. Go to the folder and run the game
```powershell
cd Snake
.\Snake.exe
```

#### Bash (Linux)

1. Open a bash window and enter the following commands to download game
```bash
# Define the URL and the destination file path
url="https://github.com/TirsvadCLI/Dotnet.Game.Snake/releases/download/1.1.2/Snake.zip"
destination="Snake"
unzipPath="Snake"

# Download the file
wget $url --output-file=$destination

# Unzip the file
rm ${destination}
unzip $destination -d $unzipPath

# Remove the zip file
rm ${destination}.zip
```

2. Go to the folder and run the game
```bash
cd Snake
./Snake.exe
```

## Features

- [x] Windows console support
- [x] Linux console support
- [x] Score system
- [x] Save and load highscore
 
## Roadmap

- [ ] Add more food types
- [ ] Add bad food which reduce score (time limited witch it change food type)
- [ ] Speed up game when snake eat food
- [ ] World highscore online
- [ ] Multi language support

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
Dotnet.Game.Snake/          # Root folder that contains the solution
|---Snake/                  # Contains the project
      |---Model/            # Contains the models
|---images/                 # Contains images
|---logo/                   # Contains the logo
```

<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/TirsvadCLI/Dotnet.Game.Snake?style=for-the-badge
[contributors-url]: https://github.com/TirsvadCLI/Dotnet.Game.Snake/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/TirsvadCLI/Dotnet.Game.Snake?style=for-the-badge
[forks-url]: https://github.com/TirsvadCLI/Dotnet.Game.Snake/network/members
[stars-shield]: https://img.shields.io/github/stars/TirsvadCLI/Dotnet.Game.Snake?style=for-the-badge
[stars-url]: https://github.com/TirsvadCLI/Dotnet.Game.Snake/stargazers
[downloads-shield]: https://img.shields.io/github/downloads/TirsvadCLI/Dotnet.Game.Snake/total?style=for-the-badge
[downloads-url]: https://github.com/TirsvadCLI/Dotnet.Game.Snake/releases
[issues-shield]: https://img.shields.io/github/issues/TirsvadCLI/Dotnet.Game.Snake?style=for-the-badge
[issues-url]: https://github.com/TirsvadCLI/Dotnet.Game.Snake/issues
[license-shield]: https://img.shields.io/github/license/TirsvadCLI/Dotnet.Game.Snake?style=for-the-badge
[license-url]: https://github.com/TirsvadCLI/Dotnet.Game.Snake/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/jens-tirsvad-nielsen-13b795b9/
[Repos-size-shield]: https://img.shields.io/github/repo-size/TirsvadCLI/Dotnet.PfxCertificateManager?style=for-the-badge

[Logo]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Game.Snake/master/image/logo/32x32/logo.png

[Screenshot_menu]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Game.Snake/master/image/small/Screenshot_menu.png
[Screenshot_menu_url]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Game.Snake/master/image/Screenshot_menu.png
[Screenshot_snakeGame]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Game.Snake/master/image/small/Screenshot_snakeGame.png
[Screenshot_snakeGame_url]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Game.Snake/master/image/Screenshot_snakeGame.png
[Screenshot_highscore]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Game.Snake/master/image/small/Screenshot_highscore.png
[Screenshot_highscore_url]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Game.Snake/master/image/Screenshot_highscore.png
