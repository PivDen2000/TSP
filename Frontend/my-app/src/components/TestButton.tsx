import React, { useState } from 'react';
import axios from 'axios';
import { data, url } from "../config/config";
import styles from './TestButton.module.scss';

interface ResultType {
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

const TestButton = () => {

  const [result, setResult] = useState<ResultType | null>(null);

  const getResult = async () => {
    try {
      const response = await axios.post<ResultType>(url, data);
      setResult(response.data);
    } catch (error) {
      console.error('Error fetching data:', error);
      setResult(null);
    }
  }
  return (
    <div>
      <div className={styles.container} role="presentation" onClick={getResult}>
        Test Button
      </div>
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

export default TestButton;
