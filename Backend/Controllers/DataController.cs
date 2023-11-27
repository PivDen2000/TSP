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
            var graph = CreateGraph(request.Cities, request.AdjacencyMatrix);
            var solverService = _algorithmFactory.CreateSolverService(request.AlgorithmType);
            var dataAfterFuncUsing = solverService.Solve(graph);
            return Ok(dataAfterFuncUsing);
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
