# EasyHost DB – Imagem Docker

SQL Server 2022 **Developer** já com o banco **EasyHostBd** criado e populado.

| Repositório DockerHub |
|-----------------------|
| `tvillani11/easyhostdb` |

---

## 1 Baixar a imagem

`docker pull tvillani11/easyhostdb:1.2`

# 2 Rodar o conteiner na porta 1433
`docker run -d --name easyHostDb -p 1433:1433 -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=EasyHost123" tvillani11/easyhostdb:1.2`


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

# 4 Publicar alterações no banco (opcional)
Caso você insira dados ou altere a estrutura e deseje subir essas mudanças via Docker Hub:

# 4.1 Pare o contêiner
docker stop easyHostDb

# 4.2 Crie o commit da nova imagem com a tag
docker commit easyHostDb tvillani11/easyhostdb:1.1   --> troque somente o 1.1 para a proxima versão que estiver o hub

# 4.3. Envie a nova tag para o Hub
docker push 'nome que vc colocou no commit, o que vem depois do docker commit easyHostDb'

# 4.4 Reinicie seu contêiner se quiser continuar usando
docker start easyHostDb
