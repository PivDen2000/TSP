#include "Path.h"

Path::Path(int start) {
    path.push_back(start);
    length = 0;
}

Path& Path::operator=(const Path& p) {
    path = p.Get_path();
    length = p.Get_length();
    return *this;
}

// путь
vector<int> Path::Get_path() const { return path; }

// длина пути
int Path::Get_length() const { return length; }

// добавление вершины в конец
void Path::push_back(int v, int l) {
    path.push_back(v);
    length += l;
}

// добавление пути в конец
void Path::push_back(Path p) {
    for (size_t i = 0; i < p.Get_path().size(); ++i) {
        int last = path[path.size() - 1];
        if (last != p.Get_path()[i]) {
            path.push_back(p.Get_path()[i]);
        }
    }
    length += p.Get_length();
}

ostream& operator<<(ostream& os, const Path& p) {
    size_t n = p.Get_path().size();
    for (size_t i = 0; i < n; i++) {
        os << p.Get_path()[i] + 1;
        if (i != n - 1) {
            os << "->";
        } else {
            os << " (";
        }
    }
    os << p.Get_length() << ')' << endl;
    return os;
}
