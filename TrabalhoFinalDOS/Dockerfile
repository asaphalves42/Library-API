FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TrabalhoFinalDOS.csproj", "."]
RUN dotnet restore "./TrabalhoFinalDOS.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TrabalhoFinalDOS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrabalhoFinalDOS.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrabalhoFinalDOS.dll"]