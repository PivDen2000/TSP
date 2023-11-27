using Backend.Services;
namespace Backend.Domain;

public class GraphSolveRequest
{
    public required List<string> Cities { get; set; }
    public required List<List<int>> AdjacencyMatrix { get; set; }
    public AlgorithmType AlgorithmType { get; set; }
}
