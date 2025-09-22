# 💻 API de Gestão de Notas Fiscais

Uma API RESTful simples e completa, desenvolvida em C# com ASP.NET Core, para o desafio técnico da UneCont. O objetivo é fornecer endpoints para a gestão de notas fiscais, utilizando uma lista em memória para persistência de dados.

### 🚀 Tecnologias e Arquitetura

- **Backend:** C# com **ASP.NET Core** 8
- **Padrões de Projeto:** Arquitetura em camadas (Controller, Service, Entity, DTO) com **Injeção de Dependência**.
- **Testes:** **xUnit** para testes unitários da camada de serviço.
- **Outros:** Utilização de `DateOnly` para datas e `decimal` para valores monetários, garantindo precisão.

### 📋 Endpoints da API

A API está exposta na porta `5091` e oferece os seguintes endpoints:

| Método HTTP | URL | Descrição |
| :--- | :--- | :--- |
| `GET` | `/notas` | Retorna a lista completa de notas fiscais. |
| `POST` | `/notas` | Adiciona uma nova nota fiscal à lista. |
| `GET` | `/notas/{id}` | Retorna uma nota fiscal específica pelo seu ID. |
| `DELETE` | `/notas/{id}` | Deleta uma nota fiscal pelo seu ID. |
| `GET` | `/notas/buscar` | Busca notas fiscais pelo nome do cliente. Ex: `/notas/buscar?nome=joao` |

### ▶️ Como Rodar o Backend

1.  Clone este repositório.
2.  Abra o projeto no Visual Studio ou use o terminal.
3.  No terminal, navegue até a pasta do projeto (`UneCont Notas Fiscais`).
4.  Execute o comando `dotnet run`. A API estará disponível em `http://localhost:5091`.

### ✅ Como Rodar os Testes

1.  Abra o terminal na pasta do projeto.
2.  Execute o comando `dotnet test`.
3.  Os testes também podem ser executados no Visual Studio pelo **Test Explorer**.
