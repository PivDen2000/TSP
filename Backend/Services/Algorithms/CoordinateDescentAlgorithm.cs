using Backend.Domain;
using Backend.Services.Interfaces;
namespace Backend.Services.Algorithms;

public class CoordinateDescentAlgorithm : IAlgorithm
{
    private List<string> _bestPath;
    private int _bestCost;

    public List<string> Solve(Graph graph)
    {
        _bestPath = new List<string>();
        _bestCost = 0;

        List<string> cities = graph.GetCities().ToList();
        int numberOfCities = cities.Count;

        int[][] costMatrix = new int[numberOfCities][];
        for (int i = 0; i < numberOfCities; i++)
        {
            costMatrix[i] = new int[numberOfCities];
        }
        foreach (var city1 in cities)
        {
            foreach (var city2 in cities)
            {
                costMatrix[graph.GetCityIndex(city1)][graph.GetCityIndex(city2)] = graph.GetDistance(city1, city2);
            }
        }

        {   
            int[] maxIndex;
            int[] maxes = new int[numberOfCities];
            int[] maxIndexes = new int[numberOfCities];
            for (int i = 0; i < numberOfCities; i++)
            {
                maxes[i] = costMatrix[i].Max();
                maxIndexes[i] = costMatrix[i].ToList().IndexOf(maxes[i]);
            }
            _bestCost = maxes.Max();
            int maxind = maxes.ToList().IndexOf(_bestCost);
            maxIndex = new int[] { maxind, maxIndexes[maxind] };
            costMatrix[maxIndex[0]][maxIndex[1]] = 0;
            costMatrix[maxIndex[1]][maxIndex[0]] = 0;
            _bestPath.Add(cities[maxIndex[0]]);
            _bestPath.Add(cities[maxIndex[1]]);
        }
        int n = 2;
        while (n < numberOfCities)
        {
            int a = graph.GetCityIndex(_bestPath[0]);
            int b = graph.GetCityIndex(_bestPath[_bestPath.Count - 1]);
            int maxCostA = costMatrix[a].Max();
            int maxCostB = costMatrix[b].Max();
            if (maxCostA > maxCostB)
            {
                _bestCost += maxCostA;
                _bestPath.Insert(0, cities[costMatrix[a].ToList().IndexOf(maxCostA)]);
                for (int i = 0; i < numberOfCities; i++)
                {
                    costMatrix[i][a] = 0;
                    costMatrix[a][i] = 0;
                }
            } else
            {
                _bestCost += maxCostB;
                _bestPath.Add(cities[costMatrix[b].ToList().IndexOf(maxCostB)]);
                for (int i = 0; i < numberOfCities; i++)
                {
                    costMatrix[i][b] = 0;
                    costMatrix[b][i] = 0;
                }
            }
            n++;
        }
        _bestPath.Add(_bestPath.First());
        return _bestPath;
    }
}