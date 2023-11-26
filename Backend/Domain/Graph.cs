using System;
using System.Collections.Generic;

namespace Backend.Domain
{
    public class Graph
    {
        private readonly int[,] _adjacencyMatrix;
        private readonly Dictionary<string, int> _cityIndexMap;

        public Graph(int numberOfCities)
        {
            _adjacencyMatrix = new int[numberOfCities, numberOfCities];
            _cityIndexMap = new Dictionary<string, int>();
        }

        public void AddCity(string cityName)
        {
            if (_cityIndexMap.Count >= _adjacencyMatrix.GetLength(0))
            {
                throw new InvalidOperationException("Cannot add more cities than the initially specified number.");
            }

            _cityIndexMap[cityName] = _cityIndexMap.Count;
        }

        public void AddDistance(string city1, string city2, int distance)
        {
            if (!_cityIndexMap.ContainsKey(city1) || !_cityIndexMap.ContainsKey(city2))
            {
                throw new ArgumentException("One or both cities are not in the graph.");
            }

            int index1 = _cityIndexMap[city1];
            int index2 = _cityIndexMap[city2];

            _adjacencyMatrix[index1, index2] = distance;
            _adjacencyMatrix[index2, index1] = distance;
        }

        public int GetDistance(string city1, string city2)
        {
            if (!_cityIndexMap.ContainsKey(city1) || !_cityIndexMap.ContainsKey(city2))
            {
                throw new ArgumentException("One or both cities are not in the graph.");
            }

            return _adjacencyMatrix[_cityIndexMap[city1], _cityIndexMap[city2]];
        }
    }
}
