FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# COPY *.csproj ./
# Copy everything
COPY . ./
# Install required tools
RUN dotnet tool install --global dotnet-ef
# Run tests
#RUN dotnet test
# Restore as distinct layers
RUN dotnet restore



# COPY --from=build-env /root/.nuget/packages/refit/6.3.0/lib/netstandard2.0/Refit.dll /app
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BTG.ITPrice.Challenge.API.dll"]

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# WORKDIR /app

# # Install required tools
# RUN dotnet tool install --global dotnet-ef
# # Run tests
# #RUN dotnet test
# # Restore as distinct layers
# COPY *.csproj ./
# RUN dotnet restore
# COPY . ./
# # Build and publish a release
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "BTG.ITPrice.Challenge.API.dll"]
