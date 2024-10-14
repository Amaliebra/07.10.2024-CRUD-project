// Function to uncheck all checkboxes
function resetSelection() {
  const checkboxes = document.querySelectorAll('.checkbox-list input[type="checkbox"]');

  checkboxes.forEach(checkbox => {
    checkbox.checked = false;
  });

  toggleElements();
}

document.getElementById("resetButton").addEventListener("click", resetSelection);

window.onload = function () {
  fetchWeather();
  toggleElements();
  document.getElementById("refreshButton").addEventListener("click", refreshWeather); // Add the event listener for the refresh button here
};

// Function to toggle visibility of weather elements based on checkbox states
function toggleElements() {
  const temperatureEl = document.getElementById("temperature");
  const windspeedEl = document.getElementById("windspeed");
  const conditionEl = document.getElementById("condition");
  const isDayEl = document.getElementById("is-day");
  const visibilityEl = document.getElementById("visibility");
  const humidityEl = document.getElementById("humidity");

  if (temperatureEl && windspeedEl && conditionEl && isDayEl && visibilityEl && humidityEl) {
    temperatureEl.style.display = document.getElementById("toggle-temperature").checked ? "block" : "none";
    windspeedEl.style.display = document.getElementById("toggle-windspeed").checked ? "block" : "none";
    conditionEl.style.display = document.getElementById("toggle-condition").checked ? "block" : "none";
    isDayEl.style.display = document.getElementById("toggle-is-day").checked ? "block" : "none";
    visibilityEl.style.display = document.getElementById("toggle-visibility").checked ? "block" : "none";
    humidityEl.style.display = document.getElementById("toggle-humidity").checked ? "block" : "none";
  }
}

document.querySelectorAll('input[type="checkbox"]').forEach((checkbox) => {
  checkbox.addEventListener('change', toggleElements);
});

// Fetch weather data function
async function fetchWeather() {
  try {
    const response = await fetch("/api/weather");
    if (!response.ok) {
      throw new Error("Failed to fetch weather data");
    }

    const weatherData = await response.json();
    console.log("Received Weather Data: ", weatherData); // Added to check that Api data is received

    // Ensure weatherData contains the required fields
    if (weatherData) {
      // Update the HTML elements with the fetched data
      document.getElementById("temperature").innerText = `Temperature: ${weatherData.temperature || 'N/A'}`;
      document.getElementById("windspeed").innerText = `Windspeed: ${weatherData.windspeed || 'N/A'}`;
      document.getElementById("condition").innerText = `Condition: ${weatherData.condition || 'N/A'}`;
      document.getElementById("is-day").innerText = `Day or Night: ${weatherData.isDay || 'N/A'}`;
      document.getElementById("visibility").innerText = `Visibility: ${weatherData.visibility || 'N/A'}`;
      document.getElementById("humidity").innerText = `Humidity: ${weatherData.humidity || 'N/A'}`;
    }
  } catch (error) {
    console.error("Error fetching weather data: ", error.message);

    // Handle errors by showing "Error" in the text fields
    document.getElementById("temperature").innerText = "Temperature: Error";
    document.getElementById("windspeed").innerText = "Windspeed: Error";
    document.getElementById("condition").innerText = "Condition: Error";
    document.getElementById("is-day").innerText = "Day or Night: Error";
    document.getElementById("visibility").innerText = "Visibility: Error";
    document.getElementById("humidity").innerText = "Humidity: Error";
  }
}

// Function to refresh weather data
function refreshWeather() {
  
  document.getElementById("temperature").innerText = "Temperature: Loading...";
  document.getElementById("windspeed").innerText = "Windspeed: Loading...";
  document.getElementById("condition").innerText = "Condition: Loading...";
  document.getElementById("is-day").innerText = "Day or Night: Loading...";
  document.getElementById("visibility").innerText = "Visibility: Loading...";
  document.getElementById("humidity").innerText = "Humidity: Loading...";

  
  fetchWeather();
}
