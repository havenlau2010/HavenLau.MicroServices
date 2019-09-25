FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Blazor/BlazorBase/BlazorBase.csproj", "Blazor/BlazorBase/"]
RUN dotnet restore "Blazor/BlazorBase/BlazorBase.csproj"
COPY . .
WORKDIR "/src/Blazor/BlazorBase"
RUN dotnet build "BlazorBase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorBase.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorBase.dll"]