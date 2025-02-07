import axios from "axios";

export const api = axios.create({
  baseURL: "http://localhost:5001",
  timeout: 5000,
});

export const getWeatherForecast = () => api.get("/weatherforecast");
