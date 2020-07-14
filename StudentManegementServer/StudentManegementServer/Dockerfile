#get base SDK Image from Microsoft

FROM mcr.Microsoft.com/dotnet/core/sdk:3.1 as build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet publish -c Release -o out

FROM mcr.Microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet","StudentManagementSever.dll" ]

