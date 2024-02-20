## Setup local environment (API+DB)
`docker-compose up --build --force-recreate -d`

## Save database
`docker commit & docker push`
`dotnet tool install --global dotnet-ef --version 7.*`

## Migraciones
`dotnet ef migrations add InitialCreate -p ./Data/Data.csproj -s ./Api/Api.csproj`
`dotnet ef database update -p ./Data/Data.csproj -s ./Api/Api.csproj`
`dotnet ef database drop -p ./Data/Data.csproj -s ./Api/Api.csproj`