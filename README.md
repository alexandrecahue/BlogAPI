BlogAPI - Backend para Gerenciamento de Posts
Este projeto é um backend para um sistema de gerenciamento de posts de blog, utilizando .NET 6, Entity Framework Core, e PostgreSQL como banco de dados. 

A autenticação é gerenciada através do Azure Active Directory B2C.
Uso somente para teste técnico

Tecnologias Utilizadas
.NET 6 - Framework para construir APIs web.
Entity Framework Core 6 - ORM para gerenciar o banco de dados relacional.
PostgreSQL - Banco de dados relacional utilizado.
Azure Active Directory B2C - Serviço para autenticação de usuários.
Dependências
.NET SDK: 6.0.400
Entity Framework Core: 6.0.0
Npgsql.EntityFrameworkCore.PostgreSQL: 6.0.3
Microsoft.AspNetCore.Authentication.AzureADB2C.UI: 6.0.11
Microsoft.Identity.Web: 1.25.8
Pré-requisitos
Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:

.NET 6 SDK: Instalar aqui
PostgreSQL: Instalar aqui
Azure Active Directory B2C: Documentação para configuração
Instalação e Execução
1. Clone o Repositório

git clone https://github.com/seuusuario/BlogAPI.git
cd BlogAPI
2. Configuração do Banco de Dados (PostgreSQL)
Criar banco de dados PostgreSQL:

Use o psql ou outro cliente PostgreSQL para criar o banco de dados:

CREATE DATABASE blogdb;
Atualizar appsettings.json:

No arquivo BlogAPI/appsettings.json, insira as credenciais e o nome do banco de dados:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=blogdb;Username=seu_usuario;Password=sua_senha"
}

3. Configuração do Azure B2C
Siga a documentação do Azure para criar e configurar seu tenant Azure B2C.
Adicione as configurações de autenticação no arquivo appsettings.json:

"AzureAdB2C": {
  "Instance": "https://login.microsoftonline.com/",
  "ClientId": "SEU_CLIENT_ID",
  "Domain": "SEU_DOMINIO_B2C.onmicrosoft.com",
  "SignUpSignInPolicyId": "B2C_1_signupsignin",
  "ResetPasswordPolicyId": "B2C_1_passwordreset",
  "EditProfilePolicyId": "B2C_1_profileediting",
  "CallbackPath": "/signin-oidc"
}

4. Aplicar Migrations e Iniciar a API
Restaurar Dependências:

No diretório raiz do projeto BlogAPI, execute o seguinte comando para restaurar as dependências do projeto:

dotnet restore
Aplicar Migrations:

Aplique as migrations para criar as tabelas no banco de dados:

dotnet ef database update
Rodar a Aplicação:

Execute o servidor localmente:


dotnet run
A API estará disponível em https://localhost:5001.

Endpoints
A API possui os seguintes endpoints:

GET /api/posts - Retorna todos os posts
POST /api/posts - Cria um novo post
PUT /api/posts/{id} - Atualiza um post existente
DELETE /api/posts/{id} - Deleta um post
Todos os endpoints estão protegidos e requerem autenticação via Azure B2C.

Licença
Este projeto é licenciado sob a licença MIT. Consulte o arquivo LICENSE para mais detalhes.

Nota: A integração com o Azure B2C deve estar configurada corretamente para que o sistema de login funcione. Certifique-se de seguir as etapas de configuração do Azure AD B2C descritas acima.
