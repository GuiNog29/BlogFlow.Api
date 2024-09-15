

Para criar container do banco de dados
Abrir  Developer PowerShell

executar comando para criar banco de dados
docker run --name blogflowdb -e POSTGRES_PASSWORD="insira a senha desejada e guarde-a para utilizar no .env" -e POSTGRES_DB=blogflowdb -p 5432:5432 -d postgres

executar comando para descobrir qual IP do container do banco de dados
docker inspect -f '{{range.NetworkSettings.Networks}}{{.IPAddress}}{{end}}' blogflowdb

Ir até o caminho onde se encontra as migrations
cd .\BlogFlow.Infrastructure\

executar para rodar as migrations 
dotnet ef database update --project ../BlogFlow.Infrastructure --startup-project ../BlogFlow.Api

renomear .env.example para apenas .env
substituir valores das variáveis
DB_PASSWORD=insiraSuaSenhaDoContainerAqui
DB_HOST=ipDoContainer

Executar sistema
