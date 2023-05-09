FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
COPY ./src .

ENV PROJ_NAME GildedRose

WORKDIR /app/${PROJ_NAME}.API
RUN dotnet restore ${PROJ_NAME}.API.csproj;
RUN dotnet publish ${PROJ_NAME}.API.csproj -c Release -o /app/published-app


FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build /app/published-app/ .

EXPOSE 80

ENTRYPOINT ["dotnet", "/app/GildedRose.API.dll"]