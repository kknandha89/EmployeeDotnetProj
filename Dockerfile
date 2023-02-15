FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base

WORKDIR /app

COPY *.csproj /app/

COPY . ./

RUN dotnet build -c Release -o build

RUN dotnet publish -c Release -o publish

FROM base as final

COPY --from=base /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "EmployeeMVC.dll"]