
# EasyHost

Guia rápido para inicializar o projeto EasyHost (frontend, backend e banco de dados).

---

## Pré-requisitos

- [Docker](https://www.docker.com/)  
- [.NET SDK 7.0+](https://dotnet.microsoft.com/)  
- [Node.js LTS](https://nodejs.org/)  
- (Opcional) Azure Data Studio ou SQL Server Management Studio  

---

## 1. Banco de Dados

# Baixar a imagem

'docker pull tvillani11/easyhostdb:1.3'

# Executar o container na porta 1433
docker run -d --name easyHostDb -p 1433:1433 -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=EasyHost123" tvillani11/easyhostdb:1.3

2. Frontend

Abra um terminal na raiz do repositório e entre em frontend/:

´cd frontend´

Instale as dependências e inicie:

´npm install´
´npm run´

3. Backend
Abra outro terminal na raiz e entre em backend/easyhost.api/:

´cd backend/easyhost.api´

Execute a API:

´dotnet run´


4. Acessando a Aplicação
Frontend: http://localhost:3000 
Backend: http://localhost:5100

Estrutura de Pastas

/
├─ src/
│  ├─ db/                ← scripts e README do container SQL
│  ├─ frontend/          ← código React/Angular/etc.
│  └─ backend/
│     └─ Easyhost.api/   ← projeto .NET Web API
└─ README.md
