# SonarCubewithDotNet

## Overview

This project demonstrates:

- ASP.NET Core MVC application
- SonarQube integration
- GitHub Actions CI pipeline
- Docker support

---

# Prerequisites

Install the following software before running the project:

- .NET 9 SDK
- Docker Desktop
- Git
- SonarQube Server (local or remote)

Verify installation:

```powershell
dotnet --version
docker --version
git --version
```

---

# Clone Repository

```powershell
git clone <repository-url>
cd SonarCubewithDotNet
```

---

# Run Application Locally

Restore packages:

```powershell
dotnet restore
```

Build application:

```powershell
dotnet build
```

Run application:

```powershell
dotnet run
```

Open:

```text
http://localhost:5134/Employee
```

---

# Running SonarQube Analysis Locally

Install SonarScanner if not already installed:

```powershell
dotnet tool install --global dotnet-sonarscanner
```

Start analysis:

```powershell
dotnet sonarscanner begin /k:"SonarCubewithDotNet" /d:sonar.host.url="http://localhost:9000" /d:sonar.token="<SONAR_TOKEN>"
```

Build project:

```powershell
dotnet build
```

Finish analysis:

```powershell
dotnet sonarscanner end /d:sonar.token="<SONAR_TOKEN>"
```

Open SonarQube dashboard:

```text
http://localhost:9000
```

---

# GitHub Actions Runner

This repository uses a self-hosted GitHub Actions runner.

If code is pushed to the `main` branch:

1. Ensure the self-hosted runner machine is running.
2. Open PowerShell.
3. Navigate to:

```text
C:\actions-runner
```

4. Start the runner:

```powershell
.\run.cmd
```

5. Keep the terminal open while workflows execute.

The runner will automatically pick up jobs pushed to `main`.

---

# Main Branch Workflow

Whenever code is pushed to `main`:

1. GitHub Actions starts automatically.
2. The self-hosted runner receives the job.
3. Dependencies are restored.
4. Project is built.
5. SonarQube analysis runs.
6. Results are uploaded to SonarQube.

---

# Docker Usage

Build image:

```powershell
docker build -t sonarcube-dotnet .
```

Run container:

```powershell
docker run -p 8080:8080 sonarcube-dotnet
```

Open:

```text
http://localhost:8080
```

Stop container:

```powershell
docker stop <container-id>
```

Remove container:

```powershell
docker rm <container-id>
```

Remove image:

```powershell
docker rmi sonarcube-dotnet
```

---

# Starting From Scratch

A new developer should follow these steps:

```powershell
git clone <repository-url>
cd SonarCubewithDotNet
dotnet restore
dotnet build
dotnet run
```

Open:

```text
http://localhost:5134/Employee
```

If GitHub Actions uses a self-hosted runner:

```powershell
cd C:\actions-runner
.\run.cmd
```

---

# Cleaning Generated Files

Clean build output:

```powershell
dotnet clean
```

Remove generated folders:

```powershell
Remove-Item -Recurse -Force .\bin, .\obj -ErrorAction SilentlyContinue
```

Remove SonarQube generated files:

```powershell
Remove-Item -Recurse -Force .\.sonarqube -ErrorAction SilentlyContinue
Remove-Item -Recurse -Force .\.scannerwork -ErrorAction SilentlyContinue
```

Remove Docker containers:

```powershell
docker container prune -f
```

Remove Docker images:

```powershell
docker image prune -f
```

Remove unused Docker resources:

```powershell
docker system prune -a -f
```

---

# Recommended Project Structure

```text
.github/
docker/
Controllers/
Models/
Views/
wwwroot/
README.md
Dockerfile
docker-compose.yml
```
