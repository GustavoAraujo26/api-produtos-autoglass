# api-produtos-autoglass

Comando docker sql server
docker pull mcr.microsoft.com/mssql/server

docker run --name sql_server -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=1q2w3e4r@#$' -p 1433:1433 -v sqlserver -d mcr.microsoft.com/mssql/server