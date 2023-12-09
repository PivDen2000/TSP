# TSP

The travelling salesman problem (TSP) asks the following question: "Given a list of cities and the distances between each pair of cities, what is the shortest possible route that visits each city exactly once and returns to the origin city?" It is an NP-hard problem in combinatorial optimization, important in theoretical computer science and operations research.

## Getting Started

This README provides guidelines on how to set up and run the application. The application consists of a frontend and a backend service, both containerized using Docker.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- You have installed Docker and Docker Compose on your machine.
- You have basic knowledge of Docker and containerization.

## Running the Application

To run the application, follow these steps:

1. **Clone the Repository**

   If the code is hosted in a repository, clone it to your local machine (or you can skip this step if the code is already on your machine).

   ```bash
   git clone https://github.com/PivDen2000/TSP
   ```

2. **Navigate to the Project Directory**

   Change into the project directory.

   ```bash
   cd ./TSP
   ```

3. **Build and Run with Docker Compose**

   Use Docker Compose to build and start the services defined in your `docker-compose.yml` file.

   ```bash
   docker-compose up --build
   ```

   The `--build` flag ensures that Docker images are built with the latest changes. If you prefer to run the containers in the background, add the `-d` flag.

4. **Accessing the Services**

   - **Frontend**: The frontend should be accessible at `http://localhost:3000`.
   - **Backend**: The backend API should be accessible at `http://localhost:5201`, and the Swagger UI can be accessed at `http://localhost:5201/swagger`.

5. **Stopping the Application**

   To stop the running Docker containers, you can use:

   ```bash
   docker-compose down
   ```

## Additional Information

- Make sure to check the `docker-compose.yml` for the configuration of services.
- For local development or testing, refer to the individual READMEs in the frontend and backend directories (if available).