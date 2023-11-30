using Backend.Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly IAlgorithmFactory _algorithmFactory;

        public DataController(ILogger<DataController> logger, IAlgorithmFactory algorithmFactory)
        {
            _logger = logger;
            _algorithmFactory = algorithmFactory;
        }

        [HttpPost(Name = "SolveGraph")]
        public ActionResult<object> SolveGraph([FromBody] GraphSolveRequest request)
        {
            var inputData = request.InputRequest;
            var graph = CreateGraph(inputData.Cities, inputData.AdjacencyMatrix);
            var solverService = _algorithmFactory.CreateSolverService(inputData.AlgorithmType);
            var solution = solverService.Solve(graph);

            var response = new
            {
                InputRequest = inputData,
                Solution = new
                {
                    OptimalPath = solution,
                    TotalDistance = CalculateTotalDistance(solution, graph)
                }
            };

            return Ok(response);
        }


        private static int CalculateTotalDistance(List<string> path, Graph graph)
        {
            int totalDistance = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                totalDistance += graph.GetDistance(path[i], path[i + 1]);
            }
            return totalDistance;
        }

        private static Graph CreateGraph(List<string> cities, List<List<int>> adjacencyMatrix)
        {
            var graph = new Graph(cities.Count);
            for (int i = 0; i < cities.Count; i++)
            {
                graph.AddCity(cities[i]);
            }

            for (int i = 0; i < adjacencyMatrix.Count; i++)
            {
                for (int j = 0; j < adjacencyMatrix[i].Count; j++)
                {
                    if (i != j)
                    {
                        graph.AddDistance(cities[i], cities[j], adjacencyMatrix[i][j]);
                    }
                }
            }

            return graph;
        }
    }
}
