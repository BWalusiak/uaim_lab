FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DoctorsData.Web/DoctorsData.Web.csproj", "DoctorsData.Web/"]
RUN dotnet restore "DoctorsData.Web/DoctorsData.Web.csproj"
COPY . .
WORKDIR "/src/DoctorsData.Web"
RUN dotnet build "DoctorsData.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DoctorsData.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY DoctorsData.Web/Resources/ Resources/
ENTRYPOINT ["dotnet", "DoctorsData.Web.dll"]
