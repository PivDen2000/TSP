using Backend.Domain;

namespace Backend.Services.Interfaces;

public interface IAlgorithm
{
    public List<string> Solve(Graph graph);
}