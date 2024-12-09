FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY src/DatetimeSender.csproj .
RUN dotnet restore

COPY src/ ./
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 80

ENTRYPOINT ["dotnet", "DatetimeSender.dll"]
