namespace Backend.Services.Interfaces;

public interface IAlgorithmFactory
{
    IAlgorithm CreateSolverService(AlgorithmType algorithmType);
}