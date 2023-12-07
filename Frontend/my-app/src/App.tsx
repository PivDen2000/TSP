import React, { useState } from 'react';
import './App.css';
import ResultButton, { ResultType } from "./components/ResultButton";
import { data } from "./config/config";
import Graph from "./components/Graph";

function App() {
  const [graphData, setGraphData] = useState<ResultType>();

  const updateGraphData = (newData: any) => {
    setGraphData(newData);
  };

  return (
    <div className="App">
      <div className="input_data table-container">
        Cities: {data.inputRequest.cities.join(', ')}
        <table>
          <tbody>
          {data.inputRequest.adjacencyMatrix.map((row, rowIndex) => (
            <tr key={rowIndex}>
              {row.map((value, columnIndex) => (
                <td key={columnIndex}>{value}</td>
              ))}
            </tr>
          ))}
          </tbody>
        </table>
      </div>
      <ResultButton onDataUpdate={updateGraphData}/>
      {graphData && <Graph optimalPath={graphData.solution.optimalPath} adjacencyMatrix={graphData.inputRequest.adjacencyMatrix} />}
    </div>
  );
}

export default App;
