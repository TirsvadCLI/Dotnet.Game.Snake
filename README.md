<!-- BADGES V1 -->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![downloads][downloads-shield]][downloads-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# ![Logo][Logo] Snake Game
This is a simple snake game for windows console and linux console. It's written in C# and uses .NET 9

[![Screenshot_menu][Screenshot_menu]][Screenshot_menu_url] [![Screenshot_snakeGame][Screenshot_snakeGame]][Screenshot_snakeGame_url] [![Screenshot_highscore][Screenshot_highscore]][Screenshot_highscore_url]

## Table of Contents

- [Overview](#Overview)
- [Features](#Features)
- [Installation](#Installation)
  - [Download the game](#Download-the-game)
    - [Windows](#Windows)
    - [Linux](#Linux)
  - [Optional for development](#Optional-for-development)
- [Roadmap](#Roadmap)
- [Contributing](#Contributing)
- [Bug / Issue Reporting](#Bug--Issue-Reporting)
- [License](#License)


## Overview

This is a simple snake game for windows console and linux console. It's written in C# and uses .NET 9

Snake eat food and grow. The game is over if the snake hits the wall or itself.

Food gives points.

- Food 🍎 gives 10 points.
- Food 🍌 gives 11 points.
- Food 🍒 gives 12 points.

Food is placed randomly on the board. Food size is more than one field so you have to cath the left side of the food to eat it.

The snake can move up, down, left and right.

The score is shown in the top.

## Features

- [x] Windows console support
- [x] Linux console support
- [x] Score system

## Installation

### Download the game

To get a local copy up and running follow these simple steps.

#### Windows

Get zip and extract zip file from github
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

# Navigate to the extracted folder
Set-Location -Path $unzipPath

#Run the game
.\Snake.exe
```

#### Linux

Get zip and extract zip file from github
```bash
# Define the URL and the destination file path
url="https://github.com/TirsvadCLI/Dotnet.Game.Snake/releases/download/1.1.2/Snake.zip"
destination="Snake.zip"
unzipPath="Snake"

# Download the file
wget -O $destination $url

# Unzip the file
unzip $destination -d $unzipPath

# Remove the zip file
rm $destination

# Navigate to the extracted folder
cd $unzipPath

#Run the game
./Snake.exe
```

#### Optional for development

We are using Visual Studio 2022 for development. You can use any IDE you want.

```powdershell
# Clone the repo
git clone https://github.com/TirsvadCLI/Dotnet.Game.Snake.git
```
 
## Roadmap

- [ ] Add more food types
- [ ] Add bad food which reduce score (time limited witch it change food type)
- [ ] Speed up game when snake eat food
- [ ] World highscore online
- [ ] Multi language support

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Bug / Issue Reporting  

If you encounter a bug or have an issue to report, please follow these steps:  

1. **Go to the Issues Page**  
  Navigate to the [GitHub Issues page](https://github.com/TirsvadCLI/CSharp.Tool.Frame/issues).  

2. **Click "New Issue"**  
  Click the green **"New Issue"** button to create a new issue.  

3. **Provide Details**  
  - **Title**: Write a concise and descriptive title for the issue.  
  - **Description**: Include the following details:  
    - Steps to reproduce the issue.  
    - Expected behavior.  
    - Actual behavior.  
    - Environment details (e.g., OS, .NET version, etc.).  
  - **Attachments**: Add screenshots, logs, or any other relevant files if applicable.  

4. **Submit the Issue**  
  Once all details are filled in, click **"Submit new issue"** to report it.  

Your feedback is valuable and helps improve the project!

## License

Distributed under the GPL-3.0 [License][license-url].

## Contact

Jens Tirsvad Nielsen - [LinkedIn][linkedin-url]

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
