FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY ./src /src

ENV PATH /root/.dotnet/tools:$PATH
RUN dotnet tool install --global dotnet-ef

RUN mkdir bundler
RUN dotnet ef migrations bundle --startup-project src/GildedRose.API/GildedRose.API.csproj --project src/GildedRose.Repository/GildedRose.Repository.csproj --output /bundler/bundle
ENV ConnectionStrings__AccessPostgresMigration "Host=db;port=5432;Username=postgres;Password-password;Database=gilded-db;"

ENTRYPOINT [ "/bundler/bundle" ]
