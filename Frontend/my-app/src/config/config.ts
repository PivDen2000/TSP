const data = {
  inputRequest: {
    cities: [ "CityA", "CityB", "CityC", "CityD" ],
    adjacencyMatrix: [
      [ 0, 20, 30, 10 ],
      [ 20, 0, 15, 35 ],
      [ 30, 15, 0, 25 ],
      [ 10, 35, 25, 0 ]
    ],
    algorithmType: "AcceleratedGradient"
  }
}

const url = 'http://localhost:5201/Data'

export { data, url };
