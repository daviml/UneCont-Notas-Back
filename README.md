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

---

### **`README.md` (Para o repositório do Frontend)**

```markdown
# 🌐 Frontend de Gestão de Notas Fiscais

Interface de usuário web (Single-Page Application) para consumir a API de gestão de notas fiscais. O frontend permite o cadastro, listagem, busca, ordenação e deleção de notas fiscais, demonstrando as habilidades em HTML, CSS e JavaScript.

### 🛠️ Tecnologias Utilizadas

- **HTML5:** Estrutura da página.
- **CSS3:** Estilização personalizada.
- **Bootstrap 5:** Framework para o layout responsivo e componentes UI.
- **JavaScript (ES6):** Lógica de interação com a página e chamadas AJAX.
- **jQuery:** Biblioteca para simplificar a manipulação do DOM e as requisições AJAX.
- **decimal.js:** Biblioteca para garantir a precisão em cálculos com valores monetários.

### ✨ Funcionalidades

- **Cadastro de Notas:** Formulário para adicionar novas notas fiscais à API.
- **Listagem Dinâmica:** Tabela que é atualizada em tempo real após o cadastro ou filtros, sem recarregar a página.
- **Busca:** Campo de busca por nome do cliente.
- **Ordenação:** Botão para ordenar a lista de notas por valor (crescente e decrescente).
- **Deleção:** Botão de lixeira na tabela para deletar uma nota fiscal específica.
- **Estatísticas:** Exibição do número total de notas e o valor total em tempo real.

### ▶️ Como Rodar o Frontend

1.  Certifique-se de que o backend da API está rodando (em `http://localhost:5091`).
2.  Abra o arquivo `index.html` em seu navegador de preferência.

A aplicação irá se conectar automaticamente à API e carregar os dados.