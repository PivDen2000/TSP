using Backend.Domain;
using Backend.Services.Interfaces;
namespace Backend.Services.Algorithms;

public class BranchAndBoundAlgorithm : IAlgorithm
{
        private List<string> _bestPath;
        private int _bestCost;

        public List<string> Solve(Graph graph)
        {
            _bestPath = new List<string>();
            _bestCost = int.MaxValue;

            List<string> cities = graph.GetCities().ToList();
            int numberOfCities = cities.Count;

            int[,] costMatrix = new int[numberOfCities, numberOfCities];
            foreach (var city1 in cities)
            {
                foreach (var city2 in cities)
                {
                    costMatrix[graph.GetCityIndex(city1), graph.GetCityIndex(city2)] = graph.GetDistance(city1, city2);
                }
            }

            List<string> currentPath = new List<string>();
            currentPath.Add(cities.First());
            List<bool> visited = Enumerable.Repeat(false, numberOfCities).ToList();
            visited[0] = true;

            BranchAndBound(graph, 1, numberOfCities, costMatrix, currentPath, visited, 0);

            _bestPath.Add(_bestPath.First());
            return _bestPath;
        }

        private void BranchAndBound(Graph graph, int level, int numberOfCities, int[,] costMatrix, List<string> currentPath, List<bool> visited, int currentCost)
        {
            if (level == numberOfCities)
            {
                int cost = currentCost + costMatrix[graph.GetCityIndex(currentPath.Last()), graph.GetCityIndex(currentPath.First())];
                if (cost < _bestCost)
                {
                    _bestPath.Clear();
                    _bestPath.AddRange(currentPath);
                    _bestCost = cost;
                }
                return;
            }

            foreach (var city in graph.GetCities())
            {
                int cityIndex = graph.GetCityIndex(city);

                if (!visited[cityIndex])
                {
                    int newCost = currentCost + costMatrix[graph.GetCityIndex(currentPath.Last()), cityIndex];

                    if (newCost < _bestCost)
                    {
                        currentPath.Add(city);
                        visited[cityIndex] = true;

                        BranchAndBound(graph, level + 1, numberOfCities, costMatrix, currentPath, visited, newCost);

                        visited[cityIndex] = false;
                        currentPath.RemoveAt(currentPath.Count - 1);
                    }
                }
            }
        }
    }
    
