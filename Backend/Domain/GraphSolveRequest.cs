using Backend.Services;

public class GraphSolveRequest
{
    public InputRequestData InputRequest { get; set; }

    public class InputRequestData
    {
        public List<string> Cities { get; set; }
        public List<List<int>> AdjacencyMatrix { get; set; }
        public AlgorithmType AlgorithmType { get; set; }
    }
}
