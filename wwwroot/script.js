const showMoreButton = document.querySelector(".show-more");
const windspeedElement = document.getElementById("windspeed");

showMoreButton.textContent = "show more ▼";

showMoreButton.addEventListener("click", () => {
  if (showMoreButton.textContent === "show more ▼") {
    showMoreButton.textContent = "show less ▲";
    windspeedElement.style.display = "block";
  } else {
    showMoreButton.textContent = "show more ▼";
    windspeedElement.style.display = "none";
  }
});

async function fetchWeather() {
  try {
    const response = await fetch("/api/weather");
    if (!response.ok) {
      throw new Error("Failed to fetch weather data");
    }

    const weatherData = await response.json();
    console.log("Received Weather Data: ", weatherData);

    // Update the HTML elements with the fetched data
    document.getElementById(
      "temperature"
    ).innerText = `Temperature: ${weatherData.temperature}`;
    document.getElementById(
      "windspeed"
    ).innerText = `Windspeed: ${weatherData.windspeed}`;
    document.getElementById(
      "condition"
    ).innerText = `Condition: ${weatherData.condition}`;
  } catch (error) {
    console.error("Error: ", error.message);
    document.getElementById("temperature").innerText = "Temperature: Error";
    document.getElementById("windspeed").innerText = "Windspeed: Error";
    document.getElementById("condition").innerText = "Condition: Error";
  }
}

function toggleCheckboxList() {
  const checkboxList = document.querySelector('.checkbox-list');
  const showMoreButton = document.querySelector('.show-more');

  // Toggle the visibility of the checkbox list
  checkboxList.classList.toggle('hidden-element');

  // Update the button text depending on the state
  if (checkboxList.classList.contains('hidden-element')) {
    showMoreButton.innerText = 'Show more ▼';
  } else {
    showMoreButton.innerText = 'Show less ▲';
  }
}

// Call the function when the page loads
window.onload = fetchWeather;
