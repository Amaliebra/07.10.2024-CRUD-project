# Weather App for Bergen

## Introduction

* This is a school project made by [Bax](https://github.com/bax082024) and [Amalie](https://github.com/Amaliebra).
* We made a weather app to show the weather in our city, Bergen.
* We added filters to remove or add details.

### How to Use

**Run the app**

* `dotnet run`

**Use the app**

* [http://localhost:5000](http://localhost:5000)
* [http://localhost:5000/api/weather](http://localhost:5000/api/weather)

**Navigate to files**

| BACKEND | FRONTEND |
| ------- | -------- |
| [Program.cs](/Program.cs) | [index.html](/wwwroot/index.html) |
| [WeatherData.cs](/classes/WeatherData.cs) | [styles.css](/wwwroot/styles.css) |
| [WeatherController.cs](/Controller/WeatherController.cs) | [Figma](documentation/Figma-design.pdf) |
| [WeatherService.cs](/Services/WeatherService.cs) | [Plan](documentation/WeatherApp.png) |

## Conclusion

### Idea
Initially, we envisioned developing an app that would gather weather data based on location searches and provide a week's worth of forecasts. However, we quickly recognized that this scope was too ambitious for a one-week project. Managing such a vast amount of data and establishing the necessary infrastructure would require significantly more time and resources than we had available.

### Function and Use
We chose to use an API that provided weather data for a specific location—Bergen. Rather than trying to cover multiple areas, we decided to dive deeper into Bergen, adding more detailed information and incorporating features that let users filter and manage that data. One challenge we faced was that the API only allowed us to refresh the data every hour, which influenced how we handled everything.

### Design Process & Figma
The initial design we created in Figma was a quick sketch of the layout, showcasing our concept for a search function and data display. However, as development progressed, our implementation evolved significantly. Since we approached this project as a learning experience, the design underwent substantial changes almost daily. By the time of writing this, it is likely to evolve even further.

### Branches and GitHub
This was our first experience managing multiple branches and collaborating on GitHub. We ran into some challenges, like accidentally overwriting branches and forgetting to switch to the right one. Luckily, we were able to restore our progress by recovering commits or relying on local saves. Through this process, we learned a lot about teamwork and best practices for using branches effectively.

## Sources

- Background image https://pixabay.com/photos/bergen-harbour-norway-scandinavia-2237288/
- API https://open-meteo.com/

