# Weather App for Bergen

## Introduction

* This is  a school project [Bax](https://github.com/bax082024) and [Amalie](https://github.com/Amaliebra) made together.
* We made a weather app to show the weather in our city, Bergen.
* We added filters to remove or add details.

### How to use

**Run the app**

* dotnet run

**Use the app**

* http://localhost:5000
* http://localhost:5000/api/weather

**Navigate to files**

| BACKEND | FRONTEND |
| ------- | -------- |
| [Program.cs](/Program.cs) | [index.html](/wwwroot/index.html) |
| [WeatherData.cs](/classes/WeatherData.cs) | [styles.css](/wwwroot/styles.css) |
| [WeatherController.cs](/Controller/WeatherController.cs) | [Figma](documentation/Figma-design.pdf) |
| [WeatherService.cs](/Services/WeatherService.cs) | [Plan](documentation/WeatherApp.png) |
<br>
## Conclusion

### Idea
Our first idea was to create an app that could gather weather data based on a location search. We soon realized that this would be too ambitious for a week-long project. It would entail managing an enormous amount of data and setting up the structure for it.

### Function and Use
We ended up using an API with a predetermined location for Bergen, and instead, we added more data for that location, along with filters and logic for viewing and removing data. The API itself limited us to refreshing the data every hour.

### Design Process & Figma
The initial design planned in Figma and what we ultimately implemented changed over the course of development. We used this project for practice, so at times, the design changed drastically on a day-to-day basis. By the time of writing this, it will likely change some more.

### Branches and GitHub
This was our first time managing several branches, as well as our first experience collaborating on GitHub. We faced some issues with overwriting branches, in addition to forgetting to use the correct branch. However, we always managed to restore our progress, either by recovering commits or using local saves. We learned a lot about how to work together on a project and what the best practices are for branch usage.
