# Get Base Image (Full .NET Core SDK)
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore
COPY ./DockerTestApi/.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DockerTestApi.dll"]



#Docker build
#docker build -t shad007/corecodecamp .
#docker run -p 8080:80 shad007/corecodecamp
#docker rmi Image 314918ddaedf
#docker rmi --force 7837f76ae5b3

#Docker Compose
  # - Reduce reliance on, and Simplifies use of, Docker command line
  # - Allow us to start up multiple container quickly
  # - Allow us to set up connection between containers

#sql containe
#docker pull microsoft/mssql-server-linux:2017-latest
#docker run -d -p 1433:1433 -e "SA_PASSWORD=Passw0rd" -e "ACCEPT_EULA=Y" <ImageID>