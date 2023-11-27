import React, { useEffect } from 'react';
import axios from 'axios';

const TestButton = () => {
  const url = 'http://localhost:5201/SolveGraph';

  const getEmployees = async () => {
    await axios.post<any>(url);
  }
  return (
    <div role="presentation" onClick={getEmployees}>
      Test Button
    </div>
  );
};

export default TestButton;
