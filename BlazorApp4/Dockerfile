#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BlazorApp4/BlazorApp4.csproj", "BlazorApp4/"]
RUN dotnet restore "BlazorApp4/BlazorApp4.csproj"
COPY . .
WORKDIR "/src/BlazorApp4"
RUN dotnet build "BlazorApp4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorApp4.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorApp4.dll"]