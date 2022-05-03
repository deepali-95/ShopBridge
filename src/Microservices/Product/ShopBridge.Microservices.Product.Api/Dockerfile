#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ShopBridge.Microservices.Product.Api/ShopBridge.Microservices.Product.Api.csproj", "ShopBridge.Microservices.Product.Api/"]
RUN dotnet restore "ShopBridge.Microservices.Product.Api/ShopBridge.Microservices.Product.Api.csproj"
COPY . .
WORKDIR "/src/ShopBridge.Microservices.Product.Api"
RUN dotnet build "ShopBridge.Microservices.Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopBridge.Microservices.Product.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopBridge.Microservices.Product.Api.dll"]