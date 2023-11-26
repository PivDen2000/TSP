CC = g++
CFLAGS = -Wall -g

a.out: main.o Graph.o Path.o Solution.o
	$(CC) $(CFLAGS) -o a.out main.o Graph.o Path.o Solution.o

main.o: main.cpp Graph.h Path.h Solution.h
	$(CC) -c main.cpp

Graph.o: Graph.h

Path.o: Path.h

Solution.o: Solution.h

