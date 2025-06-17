# EasyHost DB – Imagem Docker

SQL Server 2022 **Developer** já com o banco **EasyHostBd** criado e populado.

| Repositório DockerHub |
|-----------------------|
| `tvillani11/easyhostdb` |

---

## 1 Baixar a imagem

`docker pull tvillani11/easyhostdb:1.3`

# 2 Rodar o conteiner na porta 1433
`docker run -d --name easyHostDb -p 1433:1433 -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=EasyHost123" tvillani11/easyhostdb:1.3`


# 3 Conectar pelo Azure Data Studio o u SQL server para ver o banco e poder fazer consultas, inserts manuais
 Abaixo o passo a passo para o Azure Data Studio, primeiro clique em New Connection (Ctrl + N).

Preencha os campos:

**Connection type:** Microsoft SQL Server

**Input Type:** Param

**Server:** localhost

**Authentication type:** SQL Login

**User name:** sa

**Password:** EasyHost123


Após preenchido clieque em 'Connect' e depois no botão 'Trust server' que aparecera depois do load.

Depois disso o banco aparecera em Databases → EasyHostBd com todas as tabelas e dados de exemplo.
