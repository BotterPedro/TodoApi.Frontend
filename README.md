# TodoApi.Frontend

Front-end em **Blazor WebAssembly** para a [TodoApi](https://github.com/BotterPedro/TodoApi).

Aplicação web para gerenciar tarefas, com autenticação JWT e comunicação com a API pública hospedada no Render.

## 🌐 Demo

- **Front-end:** https://botterpedro.github.io/TodoApi.Frontend/
- **API (Swagger):** https://todoapi-lhrs.onrender.com/swagger

> **Nota:** os dois serviços estão em camadas gratuitas. A primeira requisição pode demorar ~30 segundos (a API no Render "dorme" após 15 min de inatividade).

## ✨ Funcionalidades

- Cadastro e login de usuários
- Criação, edição, conclusão e exclusão de tarefas
- Filtros por status (todas / pendentes / concluídas)
- Sessão persistente (o usuário continua logado ao recarregar)
- Interface responsiva com Bootstrap 5

## 🛠 Tecnologias

- **Blazor WebAssembly** (.NET 10)
- **Bootstrap 5** + **Bootstrap Icons**
- **HttpClient** para consumo da API REST
- **JS Interop** para acesso ao `localStorage`

## 🚀 Como rodar localmente

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Passo a passo

```bash
git clone https://github.com/BotterPedro/TodoApi.Frontend.git
cd TodoApi.Frontend
dotnet run
```

A aplicação abre em `https://localhost:XXXX`.

> Por padrão, o front-end consome a **API pública no Render**. Se quiser apontar para uma API local, edite `Program.cs` e troque o `BaseAddress` do `HttpClient`.

## 📦 Deploy

Hospedado gratuitamente no **Cloudflare Pages**, com build automático a cada push na branch `main`.

## 📄 Licença

MIT.

## 👤 Autor

**Pedro Botter**

- GitHub: [@BotterPedro](https://github.com/BotterPedro)
- LinkedIn: [pedro-botter](https://www.linkedin.com/in/pedro-botter-22b936437/)
- E-mail: pedrobotter.s@gmail.com