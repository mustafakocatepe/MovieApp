FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MovieStudyCase.Api/MovieStudyCase.Api.csproj", "MovieStudyCase.Api/"]
RUN dotnet restore "MovieStudyCase.Api/MovieStudyCase.Api.csproj"
COPY . .
WORKDIR "/src/MovieStudyCase.Api"
RUN dotnet build "MovieStudyCase.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieStudyCase.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieStudyCase.Api.dll"]
