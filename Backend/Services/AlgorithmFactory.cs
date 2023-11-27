using Backend.Services.Algorithms;
using Backend.Services.Interfaces;

namespace Backend.Services;

public enum AlgorithmType
{
    AcceleratedGradient,
    BranchAndBound,
    CoordinateDescent,
    Serdjukov,
    SerdjukovImproved,
}

public class AlgorithmFactory : IAlgorithmFactory
{
    private readonly IServiceProvider _serviceProvider;

    public AlgorithmFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IAlgorithm CreateSolverService(AlgorithmType algorithmType)
    {
        return algorithmType switch
        {
            AlgorithmType.AcceleratedGradient => _serviceProvider.GetRequiredService<AcceleratedGradientAlgorithm>(),
            AlgorithmType.CoordinateDescent => _serviceProvider.GetRequiredService<CoordinateDescentAlgorithm>(),
            AlgorithmType.Serdjukov => _serviceProvider.GetRequiredService<SerdjukovAlgorithm>(),
            AlgorithmType.SerdjukovImproved => _serviceProvider.GetRequiredService<SerdjukovImprovedAlgorithm>(),
            AlgorithmType.BranchAndBound => _serviceProvider.GetRequiredService<BranchAndBoundAlgorithm>(),
            _ => throw new ArgumentException("Invalid algorithm type", nameof(algorithmType))
        };
    }
}
