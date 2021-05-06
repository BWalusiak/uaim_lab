FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PatientsApp.Web/PatientsApp.Web.csproj", "PatientsApp.Web/"]
RUN dotnet restore "PatientsApp.Web/PatientsApp.Web.csproj"
COPY . .
WORKDIR "/src/PatientsApp.Web"
RUN dotnet build "PatientsApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientsApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientsApp.Web.dll"]
