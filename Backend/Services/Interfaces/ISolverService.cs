using Backend.Domain;

namespace Backend.Services.Interfaces;

public interface ISolverService
{
    public List<string> Solve(Graph graph);
}