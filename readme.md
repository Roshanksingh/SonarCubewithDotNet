```markdown
# SonarCubewithDotNet

## Overview

This project demonstrates:

- ASP.NET Core MVC application
- SonarQube integration
- GitHub Actions CI pipeline
- Self-hosted GitHub Actions runner
- Docker support

The CI pipeline automatically:

1. Builds the ASP.NET Core application.
2. Runs SonarQube code analysis.
3. Uploads analysis results to SonarQube dashboard.

---

# Architecture
```

Developer -> GitHub Repository -> GitHub Actions->Self-hosted Runner ->.NET Build SonarScanner-> SonarQube Server->[http://localhost:9000](http://localhost:9000)

---

# Prerequisites

Install the following software:

- .NET 9 SDK
- Docker Desktop
- Git
- SonarQube Server
- GitHub Account
- Self-hosted GitHub Actions Runner (optional)

Verify installation:

```powershell
dotnet --version
docker --version
git --version
```

---

# Clone Repository

Clone the repository:

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

Open application:

```
http://localhost:5134/Employee
```

---

# SonarQube Setup

SonarQube runs separately from the ASP.NET Core application.

The application runs on:

```
http://localhost:5134
```

SonarQube dashboard runs on:

```
http://localhost:9000
```

---

# Step 1: Start SonarQube Using Docker

Make sure Docker Desktop is running.

Run:

```powershell
docker run -d `
--name sonarqube `
-p 9000:9000 `
sonarqube
```

Verify container:

```powershell
docker ps
```

Expected:

```
CONTAINER ID   IMAGE        PORTS
xxxxxxx        sonarqube    0.0.0.0:9000->9000/tcp
```

Check logs:

```powershell
docker logs sonarqube
```

Wait until SonarQube starts successfully.

Open:

```
http://localhost:9000
```

---

# Step 2: Login to SonarQube

Default credentials:

```
Username:
admin

Password:
admin
```

Change the password after first login.

---

# Step 3: Create SonarQube Project

In SonarQube:

1. Open:

```
http://localhost:9000
```

2. Select:

```
Create local project
```

3. Enter:

Project Name:

```
SonarCubewithDotNet
```

Project Key:

```
SonarCubewithDotNet
```

4. Create the project.

---

# Step 4: Generate SonarQube Token

Create token for GitHub Actions.

Navigate:

```
Administration
    |
My Account
    |
Security
```

Create token:

```
Token Name:

github-sonarqube-token
```

Generate token.

Example:

```
sqp_xxxxxxxxxxxxxxxxx
```

Copy and store it securely.

---

# Step 5: Add GitHub Repository Secrets

Open GitHub Repository:

```
Settings
    |
Secrets and variables
    |
Actions
```

Create these secrets.

---

## SONAR_HOST_URL

Name:

```
SONAR_HOST_URL
```

Value:

```
http://localhost:9000
```

---

## SONAR_TOKEN

Name:

```
SONAR_TOKEN
```

Value:

```
<generated SonarQube token>
```

Example:

```
sqp_xxxxxxxxxxxxxxxxx
```

---

# Running SonarQube Analysis Locally

Install SonarScanner:

```powershell
dotnet tool install --global dotnet-sonarscanner
```

Verify:

```powershell
dotnet sonarscanner --version
```

---

## Start Analysis

Run:

```powershell
dotnet sonarscanner begin `
/k:"SonarCubewithDotNet" `
/d:sonar.host.url="http://localhost:9000" `
/d:sonar.token="<SONAR_TOKEN>"
```

---

## Build Application

```powershell
dotnet build
```

---

## Complete Analysis

```powershell
dotnet sonarscanner end `
/d:sonar.token="<SONAR_TOKEN>"
```

---

Open SonarQube:

```
http://localhost:9000
```

Navigate:

```
Projects
    |
SonarCubewithDotNet
```

You can view:

- Bugs
- Vulnerabilities
- Code smells
- Security issues
- Quality Gate

---

# GitHub Actions Workflow

The project uses GitHub Actions for CI/CD.

Workflow trigger:

```
Push to main branch
```

Process:

1. GitHub Actions starts.
2. Self-hosted runner receives job.
3. Dependencies restore.
4. Application builds.
5. SonarQube analysis runs.
6. Results upload to SonarQube.

---

# Self-hosted GitHub Actions Runner

Install runner on build machine.

Runner directory:

```
C:\actions-runner
```

Start runner:

```powershell
cd C:\actions-runner

.\run.cmd
```

Keep the terminal open.

---

# Docker Usage

## Build Application Image

```powershell
docker build -t sonarcube-dotnet .
```

---

## Run Application Container

```powershell
docker run -p 8080:8080 sonarcube-dotnet
```

Open:

```
http://localhost:8080
```

---

## Stop Container

```powershell
docker stop <container-id>
```

---

## Remove Container

```powershell
docker rm <container-id>
```

---

## Remove Image

```powershell
docker rmi sonarcube-dotnet
```

---

# Complete Local Setup From Scratch

A new developer can follow:

```powershell
git clone <repository-url>

cd SonarCubewithDotNet

docker run -d `
--name sonarqube `
-p 9000:9000 `
sonarqube

dotnet restore

dotnet build

dotnet run
```

Open:

Application:

```
http://localhost:5134/Employee
```

SonarQube:

```
http://localhost:9000
```

---

# Cleaning Generated Files

Clean build output:

```powershell
dotnet clean
```

Remove build folders:

```powershell
Remove-Item -Recurse -Force .\bin, .\obj -ErrorAction SilentlyContinue
```

Remove SonarQube files:

```powershell
Remove-Item -Recurse -Force .\.sonarqube -ErrorAction SilentlyContinue

Remove-Item -Recurse -Force .\.scannerwork -ErrorAction SilentlyContinue
```

---

# Docker Cleanup

Remove unused containers:

```powershell
docker container prune -f
```

Remove unused images:

```powershell
docker image prune -f
```

Remove unused Docker resources:

```powershell
docker system prune -a -f
```

---

# Troubleshooting

## SonarScanner Cannot Connect

Error:

```
No connection could be made because the target machine actively refused it
```

Check SonarQube:

```powershell
docker ps
```

Start container:

```powershell
docker start sonarqube
```

Test:

```powershell
curl http://localhost:9000
```

---

## Port 9000 Already Used

Find container:

```powershell
docker ps
```

Stop:

```powershell
docker stop sonarqube
```

Remove:

```powershell
docker rm sonarqube
```

Start again:

```powershell
docker run -d `
--name sonarqube `
-p 9000:9000 `
sonarqube
```

---

# Recommended Project Structure

```
SonarCubewithDotNet

├── .github
│   └── workflows
│       └── build.yml
│
├── Controllers
├── Models
├── Views
├── wwwroot
│
├── Dockerfile
├── docker-compose.yml
├── README.md
└── SonarCubewithDotNet.csproj
```

---

# URLs Summary

| Component               | URL                                                              |
| ----------------------- | ---------------------------------------------------------------- |
| ASP.NET MVC Application | [http://localhost:5134/Employee](http://localhost:5134/Employee) |
| Docker Application      | [http://localhost:8080](http://localhost:8080)                   |
| SonarQube Dashboard     | [http://localhost:9000](http://localhost:9000)                   |
