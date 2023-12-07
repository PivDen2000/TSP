import React, { useEffect } from 'react';
import { data } from '../config/config';
import * as d3 from 'd3';

const Graph = ({optimalPath, adjacencyMatrix}: any) => {
  useEffect(() => {
    const nodes = optimalPath.map((city: string) => ({ id: city }));
    const links = [];

    for (let i = 0; i < optimalPath.length - 1; i++) {
      const source = optimalPath[i];
      const target = optimalPath[i + 1];
      const distance = adjacencyMatrix[optimalPath.indexOf(source)][optimalPath.indexOf(target)];

      links.push({ source, target, distance });
    }

    const width = 400;
    const height = 300;

    const svg = d3.select('#graph-container')
      .append('svg')
      .attr('width', width)
      .attr('height', height);

    const simulation = d3.forceSimulation(nodes)
      .force('link', d3.forceLink(links).id((d: any) => d.id))
      .force('charge', d3.forceManyBody())
      .force('center', d3.forceCenter(width / 2, height / 2));

    const link = svg.append('g')
      .selectAll('line')
      .data(links)
      .enter().append('line');

    const node = svg.append('g')
      .selectAll('circle')
      .data(nodes)
      .enter().append('circle')
      .attr('r', 5);

    simulation.on('tick', () => {
      link
        .attr('x1', (d: any) => d.source.x)
        .attr('y1', (d: any) => d.source.y)
        .attr('x2', (d: any) => d.target.x)
        .attr('y2', (d: any) => d.target.y);

      node
        .attr('cx', (d: any) => d.x)
        .attr('cy', (d: any) => d.y);
    });

    return () => {
      svg.selectAll('*').remove(); // Cleanup
      simulation.stop();
    };
  }, [optimalPath, adjacencyMatrix]);

  return <div id="graph-container"/>;
};

export default Graph;
