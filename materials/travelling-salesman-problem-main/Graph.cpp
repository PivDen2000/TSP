#include "Graph.h"

Graph::Graph() {
    this->n = 5;
    data = new int*[5];
    for (int i = 0; i < 5; i++) {
        data[i] = new int[5];
    }

    // граф по умолчанию
    data[0][0] = 0;    data[0][1] = 2;    data[0][2] = -1;    data[0][3] = 3;    data[0][4] = -1;
    data[1][0] =2;     data[1][1] = 0;    data[1][2] = 4;     data[1][3] = 4;    data[1][4] = -1;
    data[2][0] = -1;   data[2][1] = 4;    data[2][2] = 0;     data[2][3] = 5;    data[2][4] = 6;
    data[3][0] = 3;    data[3][1] = 4;    data[3][2] = 5;    data[3][3] = 0;    data[3][4] = -1;
    data[4][0] = -1;   data[4][1] = -1;   data[4][2] = 6;     data[4][3] = -1;   data[4][4] = 0;
}

// создание графа с n вершинами
Graph::Graph(int n) {
    this->n = n;
    data = new int*[n];
    for (int i = 0; i < n; i++) {
        data[i] = new int[n];
    }
    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n; j++) {
            cout << "Input " << i << '-' << j << ": ";
            cin >> data[i][j];
            data[j][i] = data[i][j];
        }
    }
}

// данные о графе
int** Graph::Get_data() const {
    int** d = new int*[n];
    for (int i = 0; i < n; ++i) {
        d[i] = new int[n];
        for (int j = 0; j < n; ++j) {
            d[i][j] = data[i][j];
        }
    }
    return d;
}

// количество вершин графа
int Graph::Get_n() const { return n; }

// вывод графа
ostream& operator<<(ostream& os, const Graph& g) {
    int** d = g.Get_data();
    
    for (int i = 0; i < g.Get_n(); i++) {
        for (int j = 0; j < g.Get_n(); j++) {
            os << setw(4) << d[i][j] << ' ';
        }
        os << endl;
    }
    return os;
}
