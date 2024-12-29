# Gerenciador de Tarefas - ASP.NET Core Web API

Este projeto é um Gerenciador de Tarefas desenvolvido em ASP.NET Core Web API. Ele permite criar Tarefas, cadastrar usuários e associar usuários a múltiplas Tarefas. Além disso, a API integra-se ao serviço [ViaCep](https://viacep.com.br) para consulta de endereços com base no CEP.

## Funcionalidades

- **Gerenciamento de Usuários**:
  - Criar, atualizar, listar e excluir usuários.
  - Associar usuários a múltiplas Tarefas.
- **Gerenciamento de Tarefas**:
  - Criar, atualizar, listar e excluir Tarefas.
  - Relacionar Tarefas a usuários.
- **Integração com ViaCep**:
  - Consulta de endereços com base no CEP fornecido.

## Tecnologias Utilizadas

- **Backend**:
  - ASP.NET Core Web API
  - Entity Framework Core
- **Banco de Dados**:
  - SQL Server (pode ser configurado para outros tipos de banco de dados)
- **Integração**:
  - API ViaCep para consulta de CEP

## Configuração do Projeto

### Pré-requisitos

1. **.NET SDK**: Certifique-se de que o .NET SDK esteja instalado. Recomenda-se a versão mais recente do .NET.
2. **Banco de Dados**: Um servidor de banco de dados (ex.: SQL Server).

### Passos para Configuração

1. **Clone o repositório**:

   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd <PASTA_DO_PROJETO>
   ```

2. **Configurar a Connection String**:
   No arquivo `appsettings.json`, configure a connection string para o banco de dados:

   ```json
   "ConnectionStrings": {
     "Database": "Server=<SERVIDOR>;Database=<NOME_DO_BANCO>;User Id=<Usuario>;Password=<SENHA>;"
   }
   ```

3. **Executar Migrações**:

   Execute as migrações para criar o banco de dados:

   ```bash
   Add-Miggration InitialDB -Context TarefaDb
   Update-Database -Context TarefaDb
   ```

4. **Iniciar a Aplicação**:

   Inicie o servidor da API:

   ```bash
   dotnet run
   ```

5. **Documentação da API**:

   Acesse o Swagger no endereço: `http://localhost:7216/swagger/index.html`.

## Consumo da API

### Endpoints Principais

#### Usuários
- **Criar usuário**: `POST /api/Usuario`
- **Listar usuários**: `GET /api/Usuario`
- **Atualizar usuário**: `PUT /api/Usuario/{id}`
- **Excluir usuário**: `DELETE /api/Usuario/{id}`

#### Tarefas
- **Criar tarefa**: `POST /api/Tarefa`
- **Listar tarefas**: `GET /api/Tarefa`
- **Atualizar tarefa**: `PUT /api/Tarefa/{id}`
- **Excluir tarefa**: `DELETE /api/Tarefa/{id}`

#### Integração ViaCep
- **Buscar endereço**: `GET /api/Cep/{cep}`