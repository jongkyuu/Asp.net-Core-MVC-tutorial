using Microsoft.AspNetCore.Mvc;

namespace Validation.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        private List<WeatherForecast> _forecasts;

        public WeatherForecastService()
        {
            InitForecastData(DateOnly.FromDateTime(DateTime.Now));
        }


        public Task InitForecastData(DateOnly startDate)
        {
            _forecasts = (Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList());

            return Task.CompletedTask;
        }

        public Task<List<WeatherForecast>> GetForecastAsync()
        {

            return Task.FromResult(_forecasts);

            //return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = startDate.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //}).ToList());
        }

        public Task AddForecastAsync(WeatherForecast weatherForecast)
        {
            _forecasts.Add(weatherForecast);
            return Task.CompletedTask;
        }
    }
}