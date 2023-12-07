using Backend.Domain;
using Backend.Services.Interfaces;

namespace Backend.Services.Algorithms;

public class AcceleratedGradientAlgorithm : IAlgorithm
{
    public List<string> Solve(Graph graph)
    {
        int numberOfCities = graph.GetCities().Count();
        double[] x = Enumerable.Range(0, numberOfCities).Select(i => (double)i).ToArray();
        double[] y = Enumerable.Range(0, numberOfCities).Select(i => (double)i).ToArray();
        double[] z = Enumerable.Range(0, numberOfCities).Select(i => (double)i).ToArray();

        int k = 1; // Iteration counter
        double epsilon = 1e-6; // Convergence threshold

        while (true)
        {
            UpdateVariables(ref x, ref y, ref z, k, graph);

            // Check for convergence
            if (CheckConvergence(x, y, z, epsilon))
            {
                break;
            }

            k++;
        }

        // Return the result as a list of city names
        List<string> result = x.Select(cityIndex => graph.GetCities().ElementAt((int)cityIndex)).ToList();
        return result;
    }

    private void UpdateVariables(ref double[] x, ref double[] y, ref double[] z, int k, Graph graph)
    {
        double step = 1.0 / k;

        for (int i = 0; i < x.Length; i++)
        {
            x[i] -= step * ComputeGradient(i, x, y, z, graph);
            y[i] -= step * ComputeGradient(i, x, y, z, graph);
            z[i] -= step * ComputeGradient(i, x, y, z, graph);
        }
    }

    private double ComputeGradient(int index, double[] x, double[] y, double[] z, Graph graph)
    {
        double sum = 0;

        for (int j = 0; j < x.Length; j++)
        {
            int cityXIndex = (int)Math.Round(x[index]);
            int cityYIndex = (int)Math.Round(y[index]);
            int cityZIndex = (int)Math.Round(z[index]);

            if (cityXIndex >= 0 && cityXIndex < graph.GetCities().Count() &&
                cityYIndex >= 0 && cityYIndex < graph.GetCities().Count() &&
                cityZIndex >= 0 && cityZIndex < graph.GetCities().Count())
            {
                sum += graph.GetDistance(graph.GetCities().ElementAt(cityXIndex), graph.GetCities().ElementAt(cityYIndex)) +
                       graph.GetDistance(graph.GetCities().ElementAt(cityYIndex), graph.GetCities().ElementAt(cityZIndex)) -
                       graph.GetDistance(graph.GetCities().ElementAt(cityZIndex), graph.GetCities().ElementAt(cityXIndex));
            }
            else
            {
                // Обработка ошибки или другие действия по вашему усмотрению
                throw new InvalidOperationException("Invalid city index.");
            }
        }

        return sum;
    }

    private bool CheckConvergence(double[] x, double[] y, double[] z, double epsilon)
    {
        for (int i = 0; i < x.Length; i++)
        {
            if (Math.Abs(x[i] - y[i]) > epsilon || Math.Abs(x[i] - z[i]) > epsilon)
            {
                return false;
            }
        }

        return true;
    }
}