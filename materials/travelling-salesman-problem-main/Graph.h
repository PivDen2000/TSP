#ifndef GRAPH_H
#define GRAPH_H

#include <iostream>
#include <iomanip>

using namespace std;

class Graph {
private:
    int n;                          // количество вершин графа
    int** data;                     // данные о ребрах графа: -1 - отсутствует ребро; >0 - расттояние между вершинами i и j
    
public:
    Graph(int n);                   // создание графа с n вершинами
    Graph();                        // граф по умолчанию
    int** Get_data() const;         // данные о графе
    int Get_n() const;              // количество вершин графа

};

ostream& operator<<(ostream& os, const Graph& g);

#endif
