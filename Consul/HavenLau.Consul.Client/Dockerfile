#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:2.2-nanoserver-1809 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["Consul/HavenLau.Consul.Client/HavenLau.Consul.Client.csproj", "Consul/HavenLau.Consul.Client/"]
RUN dotnet restore "Consul/HavenLau.Consul.Client/HavenLau.Consul.Client.csproj"
COPY . .
WORKDIR "/src/Consul/HavenLau.Consul.Client"
RUN dotnet build "HavenLau.Consul.Client.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HavenLau.Consul.Client.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HavenLau.Consul.Client.dll"]