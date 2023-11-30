using Backend.Domain;
using Backend.Services.Interfaces;
namespace Backend.Services.Algorithms;

public class GreedyAlgorithm : IAlgorithm
{
    public List<string> Solve(Graph graph)
    {
        var remainingCities = graph.GetCities().ToList();
        var currentCity = remainingCities.First();
        var path = new List<string> { currentCity };
        remainingCities.Remove(currentCity);

        while (remainingCities.Any())
        {
            string nextCity = GetNextCity(currentCity, remainingCities, graph);
            path.Add(nextCity);
            remainingCities.Remove(nextCity);
            currentCity = nextCity;
        }

        path.Add(path.First());
        return path;
    }

    private string GetNextCity(string currentCity, List<string> remainingCities, Graph graph)
    {
        string nearestCity = null;
        int minDistance = int.MaxValue;

        foreach (var city in remainingCities)
        {
            int distance = graph.GetDistance(currentCity, city);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestCity = city;
            }
        }

        return nearestCity;
    }
}
