## 4. Projeto da Solução

<span style="color:red">Pré-requisitos: <a href="03-Modelagem do Processo de Negocio.md"> Modelagem do Processo de Negocio</a></span>

## 4.1. Arquitetura da solução

O sistema Easy Host foi pensado para ser uma solução prática, organizada e fácil de usar, voltada especialmente para pequenos hotéis e pousadas. Para isso, adotamos uma arquitetura em camadas, separando o que é interface, o que é processamento e o que é armazenamento de dados. Isso torna o sistema mais organizado e fácil de manter.

Abaixo, apresentamos o diagrama da estrutura do sistema:

Descrição dos Módulos e Tecnologias
Usuário: O sistema pode ser acessado diretamente pelo navegador, tanto no computador quanto no celular, permitindo maior praticidade para os usuários.

Frontend (Angular): Escolhemos o Angular para construir a parte visual do sistema, por ser uma tecnologia moderna que permite criar páginas rápidas e responsivas. O frontend se comunica com o backend usando requisições HTTP.

Backend (C# .NET): Para cuidar das regras do sistema e do funcionamento das funções, usamos C# com .NET, uma tecnologia robusta e eficiente, muito utilizada no mercado.

Banco de Dados (SQL Server): Todas as informações, como reservas e dados dos hóspedes, serão armazenadas em um banco de dados SQL Server, facilitando o acesso rápido e seguro às informações.

Hospedagem (a definir): Pretendemos usar Docker para empacotar e hospedar o sistema, o que nos permite mais flexibilidade para instalar tanto em servidores locais quanto em nuvens, dependendo da necessidade do cliente.

Justificativa da Arquitetura
Organizamos o sistema dessa forma para facilitar futuras melhorias, como adicionar novas funcionalidades sem precisar refazer o que já foi construído. Separar a interface, o processamento e o banco de dados também facilita o trabalho em equipe e deixa o sistema mais estável e confiável.

 ![Arquitetura da Solução](images/arquitetura_solucao.png)


### 4.2. Protótipos de telas

### <p align="center">Login</p>

![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20login.png)
### <p align="center">HOME (FUNCIONÁRIO)</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20HOME%20(FUNCIONARIO).png)
### <p align="center">HOME (ADMIN)</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20HOME%20(ADMIN).png)
### <p align="center">MENU DE QUARTOS</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20MENU%20DE%20QUARTOS.png)
### <p align="center">PÁGINA QUARTOS (DISPONÍVEL)</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20P%C3%81GINA%20QUARTO%20(DISPONIVEL).png)
### <p align="center">PÁGINA QUARTOS (OCUPADO)</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20P%C3%81GINA%20QUARTO%20(HOSPEDADO).png)
### <p align="center">CRUD (FUNCIONÁRIO)</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20CRUD%20(FUNCIONARIOS).png)
### <p align="center">CRUD (QUARTOS)</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20CRUD%20(QUARTOS).png)
### <p align="center">CRUD (SERVIÇOS)</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20CRUD%20(SERVI%C3%87OS).png)
### <p align="center">SERVIÇOS INTERNOS</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20SERVI%C3%87OS%20INTERNOS.png)
### <p align="center">RELATÓRIO GERAL</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20RELAT%C3%93RIO%20GERAL.png)


## Diagrama de Classes

 ![UML](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/UML-EASYHost.png)

## Modelo ER


### 4.3. Modelo de dados


#### 4.3.1 Modelo ER


![Exemplo de um modelo relacional](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Modelo%20ER.jpeg)

#### 4.3.2 Esquema Relacional


![Exemplo de um modelo relacional](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Modelo%20Relacional.jpeg)
---


#### 4.3.3 Modelo Físico

Script de criação das tabelas do banco de dados.

<code>

CREATE DATABASE EasyHostBd;
USE EasyHostBd;

----------------------------------------
-- 1) Lookup tables de enumerações
----------------------------------------

CREATE TABLE TipoUsuario (
  tipoUsuarioId        INT IDENTITY(1,1) PRIMARY KEY,
  descricao      NVARCHAR(20)  NOT NULL
);

CREATE TABLE StatusReserva (
  statusReservaId INT IDENTITY(1,1) PRIMARY KEY,
  descricao       NVARCHAR(20) NOT NULL
);

CREATE TABLE StatusServico (
  statusServicoId INT IDENTITY(1,1) PRIMARY KEY,
  descricao       NVARCHAR(50) NOT NULL
);

INSERT INTO TipoUsuario (descricao) VALUES
  ('Funcionario'),
  ('Administrador');

INSERT INTO StatusReserva (descricao) VALUES
  ('Reservada'),
  ('Confirmada'),
  ('Em Andamento'),
  ('Concluida'),
  ('Cancelada');

INSERT INTO StatusServico (descricao) VALUES
  ('Pendente'),
  ('Em Andamento'),
  ('Concluido'),
  ('Cancelado');


----------------------------------------
-- 2) Tabela principal de hotéis
----------------------------------------
CREATE TABLE Hotel (
  id             INT IDENTITY(1,1) PRIMARY KEY,
  nomeHotel      NVARCHAR(255) NOT NULL
);

----------------------------------------
-- 3) Usuários (apenas FK para hotel)
----------------------------------------
CREATE TABLE Usuario (
  id             INT IDENTITY(1,1) PRIMARY KEY,
  nome		     NVARCHAR(100) NOT NULL,
  cpf            CHAR(11)      NOT NULL UNIQUE,
  salario        DECIMAL(10,2) NOT NULL,
  ativo          BIT NOT NULL DEFAULT(1),
  TipoUsuario    INT NOT NULL REFERENCES TipoUsuario(tipoUsuarioId) ON DELETE NO ACTION,
  hotelIdFk      INT NOT NULL REFERENCES Hotel(id) ON DELETE CASCADE
);

----------------------------------------
-- 4) log de alterações
----------------------------------------
CREATE TABLE Alteracoes (
  id             INT IDENTITY(1,1) PRIMARY KEY,
  usuarioIdFk    INT NULL REFERENCES Usuario(id) ON DELETE SET NULL,
  dataHora       DATETIME2   NOT NULL DEFAULT SYSUTCDATETIME(),
  descricao      NVARCHAR(100) NOT NULL,
  detalhes       NVARCHAR(MAX) NULL
);

----------------------------------------
-- 5) Hóspedes
----------------------------------------
CREATE TABLE Hospede (
  id             INT IDENTITY(1,1) PRIMARY KEY,
  nome           NVARCHAR(255) NOT NULL,
  cpf            CHAR(11) NOT NULL UNIQUE,
  hotelIdFk      INT NOT NULL REFERENCES Hotel(id) ON DELETE CASCADE
);

----------------------------------------
-- 6) Quartos
----------------------------------------
CREATE TABLE Quarto (
  id               INT IDENTITY(1,1) PRIMARY KEY,
  numQuarto        INT NOT NULL,
  numCamasSolteiro INT NOT NULL DEFAULT(0),
  numCamasCasal    INT NOT NULL DEFAULT(0),
  maxPessoas       INT NOT NULL DEFAULT(1),
  adicionais       NVARCHAR(MAX) NULL,
  hotelIdFk        INT NOT NULL REFERENCES Hotel(id) ON DELETE CASCADE
  );

----------------------------------------
-- 7) Reservas
----------------------------------------
CREATE TABLE Reserva (
  id                 INT IDENTITY(1,1) PRIMARY KEY,
  hospedeIdFk        INT NULL REFERENCES Hospede(id) ON DELETE CASCADE,
  quartoIdFk         INT NOT NULL REFERENCES Quarto(id) ON DELETE CASCADE,
  dataEntrada        DATE NOT NULL,
  dataSaida          DATE NOT NULL,
  statusReservaIdFk  INT NOT NULL DEFAULT 1 REFERENCES StatusReserva(statusReservaId) ON DELETE NO ACTION,
);

----------------------------------------
-- 8) Serviços vinculados a reserva
----------------------------------------
CREATE TABLE Servico (
  id                     INT IDENTITY(1,1) PRIMARY KEY,
  funcionarioResponsavel NVARCHAR(100) NOT NULL,
  descricao              NVARCHAR(MAX) NULL,
  statusServicoIdFk      INT NOT NULL DEFAULT 1 REFERENCES StatusServico(statusServicoId) ON DELETE NO ACTION,
  criadoEm               DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  concluidoEm            DATETIME2 NULL,
  reservaIdFk            INT NOT NULL REFERENCES Reserva(id) ON DELETE CASCADE
);


</code>

### 4.4. Tecnologias

![Representação Integração Usuario Com Sistema](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Interacao_User_System.png)


|**Dimensão**     | **Tecnologia**  |
| --------------- | --------------- |
| SGBD            | SQL Server      |
| Front end       | React Framework |
| Back end        | .NET            |
| Deploy          | GitHub Pages    |
| Containerização | Docker          |

