import React, { useState } from 'react';
import axios from 'axios';
import { data, url } from "../config/config";
import styles from './ResultButton.module.scss';

export interface ResultType {
  inputRequest: {
    cities: string[];
    adjacencyMatrix: number[][];
    algorithmType: string;
  };
  solution: {
    optimalPath: string[];
    totalDistance: number;
  };
}

const ResultButton = ({ onDataUpdate }: { onDataUpdate: (data: ResultType) => void }) => {
  const [algorithmType, setAlgorithmType] = useState('AcceleratedGradient');
  const [result, setResult] = useState<ResultType | null>(null);

  const requestData = {
    inputRequest: {
      cities: ["CityA", "CityB", "CityC", "CityD"],
      adjacencyMatrix: [
        [0, 20, 30, 10],
        [20, 0, 15, 35],
        [30, 15, 0, 25],
        [10, 35, 25, 0]
      ],
      algorithmType: algorithmType,
    }
  };

  const getResult = async () => {
    try {
      const response = await axios.post<ResultType>(url, requestData);
      setResult(response.data);
      onDataUpdate(response.data); // Викликає функцію зворотнього виклику з результатами
    } catch (error) {
      console.error('Error fetching data:', error);
      setResult(null);
    }
  };

  return (
    <div>
      <div className={styles.container} role="presentation" onClick={getResult}>
        Get Result
      </div>
      <label>
        Choose Algorithm:
        <select className={styles.dropdown} value={algorithmType} onChange={(e) => setAlgorithmType(e.target.value)}>
          <option value="AcceleratedGradient">Accelerated Gradient</option>
          <option value="BranchAndBound">Branch And Bound</option>
          <option value="CoordinateDescent">Coordinate Descent</option>
          <option value="Greedy">Greedy</option>
          <option value="Serdjukov">Serdjukov</option>
          <option value="SerdjukovImproved">Serdjukov Improved</option>
        </select>
      </label>
      {result && (
        <div>
          <h2>Optimal Path:</h2>
          <ul>
            {result.solution.optimalPath.map(city => (
              <li key={city}>{city}</li>
            ))}
          </ul>
          <p>Total Distance: {result.solution.totalDistance}</p>
        </div>
      )}
    </div>
  );
};

export default ResultButton;
