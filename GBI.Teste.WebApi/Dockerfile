#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GBI.Teste.WebApi/GBI.Teste.WebApi.csproj", "GBI.Teste.WebApi/"]
COPY ["GBI.Teste.Model/GBI.Teste.Model.csproj", "GBI.Teste.Model/"]
COPY ["GBI.Teste.Repository/GBI.Teste.Repository.csproj", "GBI.Teste.Repository/"]
RUN dotnet restore "GBI.Teste.WebApi/GBI.Teste.WebApi.csproj"
COPY . .
WORKDIR "/src/GBI.Teste.WebApi"
RUN dotnet build "GBI.Teste.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GBI.Teste.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GBI.Teste.WebApi.dll"]