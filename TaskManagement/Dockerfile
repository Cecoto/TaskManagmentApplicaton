#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

# Use the official .NET Core SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy and restore project files for the API project
COPY ["TaskManagement/TaskManagementApi.csproj", "TaskManagement/"]
RUN dotnet restore "TaskManagement/TaskManagementApi.csproj"

# Copy and restore project files for other projects
COPY ["TaskManagement.DTOs/TaskManagement.DTOs.csproj", "TaskManagement.DTOs/"]
COPY ["TaskManagment.Common/TaskManagment.Common.csproj", "TaskManagment.Common/"]
COPY ["TaskManagment.Data.Models/TaskManagment.Data.Models.csproj", "TaskManagment.Data.Models/"]
COPY ["TaskManagment.Data/TaskManagment.Data.csproj", "TaskManagment.Data/"]
COPY ["TaskManagment.Services/TaskManagment.Services.csproj", "TaskManagment.Services/"]

# Build projects
RUN dotnet build "TaskManagement/TaskManagementApi.csproj" -c Release -o /app/build
RUN dotnet build "TaskManagement.DTOs/TaskManagement.DTOs.csproj" -c Release -o /app/build-dtos
RUN dotnet build "TaskManagment.Common/TaskManagment.Common.csproj" -c Release -o /app/build-common
RUN dotnet build "TaskManagment.Data.Models/TaskManagment.Data.Models.csproj" -c Release -o /app/build-models
RUN dotnet build "TaskManagment.Data/TaskManagment.Data.csproj" -c Release -o /app/build-data
RUN dotnet build "TaskManagment.Services/TaskManagment.Services.csproj" -c Release -o /app/build-services

# Publish projects
COPY . .
WORKDIR "/src/TaskManagement"
RUN dotnet publish "TaskManagementApi.csproj" -c Release -o /app/publish -p:UseAppHost=false

WORKDIR "/src/TaskManagement.DTOs"
RUN dotnet publish "TaskManagement.DTOs.csproj" -c Release -o /app/publish-dtos -p:UseAppHost=false

WORKDIR "/src/TaskManagment.Common"
RUN dotnet publish "TaskManagment.Common.csproj" -c Release -o /app/publish-common -p:UseAppHost=false

WORKDIR "/src/TaskManagment.Data.Models"
RUN dotnet publish "TaskManagment.Data.Models.csproj" -c Release -o /app/publish-models -p:UseAppHost=false

WORKDIR "/src/TaskManagment.Data"
RUN dotnet publish "TaskManagment.Data.csproj" -c Release -o /app/publish-data -p:UseAppHost=false

WORKDIR "/src/TaskManagment.Services"
RUN dotnet publish "TaskManagment.Services.csproj" -c Release -o /app/publish-services -p:UseAppHost=false

# Use the official .NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy the published output of each project
COPY --from=build /app/publish .
COPY --from=build /app/publish-dtos ./TaskManagement.DTOs
COPY --from=build /app/publish-common ./TaskManagment.Common
COPY --from=build /app/publish-models ./TaskManagment.Data.Models
COPY --from=build /app/publish-data ./TaskManagment.Data
COPY --from=build /app/publish-services ./TaskManagment.Services

# Define the entry point for your application (e.g., API project)
ENTRYPOINT ["dotnet", "TaskManagementApi.dll"]
