FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app
# Enable detection of running in a container
ENV ENV ASPNETCORE_URLS=http://+:80 \
    DOTNET_RUNNING_IN_CONTAINER=true \
    DOTNET_CLI_TELEMETRY_OPTOUT=1

COPY ./src /src

WORKDIR /src
RUN dotnet restore "RestApp/RestApp.csproj"
RUN dotnet restore "RestApp.Data/RestApp.Data.csproj"

WORKDIR /src/RestApp
RUN dotnet build "RestApp.csproj" -c Release -o /app

WORKDIR /src/RestApp.Data
RUN dotnet build "RestApp.Data.csproj" -c Release -o /app

WORKDIR /src/RestApp
RUN dotnet publish "RestApp.csproj" -c Release -o /app

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "RestApp.dll"]
EXPOSE 80