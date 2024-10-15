# Weather App for Bergen


## Introduction

* This is school project Bax and Amalie made together.
* We made a weather app to show the weather in our city

### How to use

**Run the app**

* dotnet run

**Use the app**

* http://localhost:5000
* http://localhost:5000/api/weather

**Navigate to files**
| BACKEND&nbsp;&nbsp;&nbsp; | FRONTEND |
| -------------------------- | --------- |
| [Program.cs](/Program.cs) | [HTML](/wwwroot/index.html) |
| [WeatherData.cs](/classes/WeatherData.cs) | [CSS](/wwwroot/styles.css) |
| [WeatherController.cs](/Controller/WeatherController.cs) | [Figma](documentation/Figma-design.pdf) |
| [WeatherService.cs](/Services/WeatherService.cs) | [Plan](documentation/WeatherApp.png) |

<br>
## **Conclusion**

**Idea**
Our first idea, was to make an app that could gather weather data from location based on search. We soon realized that would be way to ambitious for a week long project.
It would entail managing an enormous amount of data and setting up the structure for it.

**Function and use**
We stuck to just one location,-Bergen. And rather added more data for that location, along with filters and logic for viewing and removing data. The api itself limited us to refreshing the data every hour.

**Design prosess & Figma**
The initial design planned in figma, and what we went for, changed over the course of development.
We used this project for practice, so at some points the design changed drastically on a day to day basis. And at the point of typing this, it will probably change some more.

**Branches and github**
This was our first time managing several branches, aswell as first time collaborating on github. We faced some issues with overwriting branches, in addition forgetting to use the correct branch. But we always managed to restore the progress, either by recovering commits, or by using local saves.
We learned alot about how to work together in a project, and what is best practice in branch usage.