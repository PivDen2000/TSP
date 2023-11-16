#include "Graph.h"
#include "Path.h"
#include "Solution.h"

int main()
{
    Graph graph = Graph();
    cout << graph << endl;
    Solution s(graph);
    cout << s.calc({3, 4}, 0);
    return 0;
}
