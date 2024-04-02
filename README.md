## Containerized .NET Core Server-Client Application with gRPC Communication

This repository contains a system of two containerized applications, a server and a client, built using .NET Core and communicating via gRPC. The server accepts text input from the user in the console and sends it to the client, which prints out the text to the console in real-time.

## Prerequisites

To run this application, you need the following installed on your machine:

- Docker
- Bash, cmd, or PowerShell

## Setup Instructions

1. Clone the repository:

```bash
git clone https://github.com/AliMohammadnezhad/dotnet-grpc-communication.git
```

Navigate to the project directory:

```bash
cd dotnet-grpc-communication
```

Build Docker images for the server and client:

```bash
docker-compose build
```

Start the Docker containers:

```bash
docker-compose up
```

This command will start both the server and client containers in the background.

## Usage

To interact with the application:

Open two terminal/command prompt windows.

In one terminal window, attach to the server container by running the following command:

```bash
docker attach server_Container
```

In the other terminal window, attach to the client container by running the following command:

```bash
docker attach Client_Container
```

Now, you can interact with the application:

In the terminal attached to the server container, type text and press Enter. This text will be sent to the client.

In the terminal attached to the client container, you will see the text received from the server in real-time.

## Stopping the Application

To stop the application and terminate the containers, use the following command:

```bash
docker-compose down
```

## Additional Notes

* The communication between the server and client is handled via gRPC.
* Both the server and client applications are containerized using Docker for easy deployment and scalability.
