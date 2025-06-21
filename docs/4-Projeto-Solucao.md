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

### <p align="center">CADASTRO USUARIO</p>
![Cadastro](docs/images/WIREFRAMES/WIREFRAME - CADASTRO DE HOSPEDE.png)

### <p align="center">LOGIN</p>
![Login](docs/images/WIREFRAMES/WIREFRAME - LOGIN DE USUARIO.png)

### <p align="center">HOME</p>
![Home](docs/images/WIREFRAMES/Wireframes - HOME.png)

### <p align="center">MENU DE QUARTOS (Admin)</p>
![MenuQuarto](docs/images/WIREFRAMES/Wireframes - MENU DE QUARTOS.png)

### <p align="center">CADASTRO DE QUARTOS (Admin)</p>
![CadastroQuarto](docs/images/WIREFRAMES/Wireframes - CADASTRO DE QUARTOS.png)

### <p align="center">EDIÇÃO DE QUARTOS</p>
![EditarQuarto](docs/images/WIREFRAMES/Wireframes - EDIÇÃO DE QUARTO (ADMIN).png)

### <p align="center">MENU DE HOSPEDES</p>
![MenuHospede](docs/images/WIREFRAMES/WIREFRAME - MENU DE HOSPEDES.jpg)

### <p align="center">CADASTRO DE HOSPEDES</p>
![CadastroHospede](docs/images/WIREFRAMES/Wireframes - CADASTRO DE HOSPEDE.jpg)

### <p align="center">CADASTRO CONSUMO DO HOSPEDE</p>
![CadastroConsumo](docs/images/WIREFRAMES/Wireframes - CADASTRO DE CONSUMO.png)

### <p align="center">LISTA CONSUMO DE HOSPEDE</p>
![ListaConsumo](docs/images/WIREFRAMES/Wireframes - LISTA DE CONSUMO HOSPODES.jpg)

### <p align="center">MENU RESERVAS</p>
![MenuReservas](docs/images/WIREFRAMES/Wireframes - PAGINA DE RESERVAS.jpg)

### <p align="center">CADASTRO RESERVA</p>
![CadastrorReserva](docs/images/WIREFRAMES/Wireframes - CADASTRO DE RESERVAS.png)

### <p align="center">CONSUMO TOTAL RESERVA</p>
![ConsumoTotalReserva](docs/images/WIREFRAMES/Wireframes - VISUALIZAR O CONSUMO TOTAL DA RESERVA.jpg)

### <p align="center">RELATÓRIO GERAL</p>
![Relatorio](docs/images/WIREFRAMES/Wireframes - MENU DE RELATORIOS.jpg)


## Diagrama de Classes

 ![UML](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/UML-EASYHost.png)

## Modelo ER


### 4.3. Modelo de dados


#### 4.3.1 Modelo ER


![Exemplo de um modelo relacional](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Modelo%20ER%20EasyHost.png)

#### 4.3.2 Esquema Relacional


![Exemplo de um modelo relacional](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Esquema%20relacional.png)
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
  tipoUsuarioId         UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
  descricao      NVARCHAR(20)  NOT NULL
);

CREATE TABLE StatusReserva (
  statusReservaId  UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
  descricao       NVARCHAR(20) NOT NULL
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
  id              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
  nomeHotel      NVARCHAR(255) NOT NULL
);

----------------------------------------
-- 3) Usuários (apenas FK para hotel)
----------------------------------------
CREATE TABLE Usuario (
  id              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
  nome		     NVARCHAR(100) NOT NULL,
  senha		     NVARCHAR(30) NOT NULL,
  email		     NVARCHAR(100) NOT NULL,
  cpf            CHAR(11)      NOT NULL UNIQUE,
  salario        DECIMAL(10,2) NOT NULL,
  ativo          BIT NOT NULL DEFAULT(1),
  TipoUsuario    INT NOT NULL REFERENCES TipoUsuario(tipoUsuarioId) ON DELETE NO ACTION,
  hotelIdFk      INT NOT NULL REFERENCES Hotel(id) ON DELETE CASCADE
);


----------------------------------------
-- 5) Hóspedes
----------------------------------------
CREATE TABLE Hospede (
  id              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
  nome           NVARCHAR(255) NOT NULL,
  cpf            CHAR(11) NOT NULL UNIQUE,
  hotelIdFk      INT NOT NULL REFERENCES Hotel(id) ON DELETE CASCADE
);

----------------------------------------
-- 6) Quartos
----------------------------------------
CREATE TABLE Quarto (
  id                UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
  numQuarto        INT NOT NULL,
  numCamasSolteiro INT NOT NULL DEFAULT(0),
  numCamasCasal    INT NOT NULL DEFAULT(0),
  maxPessoas       INT NOT NULL DEFAULT(1),
  hotelIdFk        INT NOT NULL REFERENCES Hotel(id) ON DELETE CASCADE
  );

----------------------------------------
-- 7) Reservas
----------------------------------------
CREATE TABLE Reserva (
  id                  UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
  hospedeIdFk        INT NULL REFERENCES Hospede(id) ON DELETE CASCADE,
  quartoIdFk         INT NOT NULL REFERENCES Quarto(id) ON DELETE CASCADE,
  dataEntrada        DATE NOT NULL,
  dataSaida          DATE NOT NULL,
  statusReservaIdFk  INT NOT NULL DEFAULT 1 REFERENCES StatusReserva(statusReservaId) ON DELETE NO ACTION,
);

----------------------------------------
-- 8) Consumo
----------------------------------------
CREATE TABLE Consumo (
  id             UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
  nome           NVARCHAR(200)   NOT NULL,
  preco          DECIMAL(18,2)   NOT NULL,
  hospedeIdFk    UNIQUEIDENTIFIER NOT NULL,
  CONSTRAINT FK_Despesa_Hospede
  FOREIGN KEY (hospedeIdFk)
  REFERENCES Hospede(id)
  ON DELETE CASCADE
);


</code>

### 4.4. Tecnologias

![Representação Integração Usuario Com Sistema](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/Interacao_User_System.png)


|**Dimensão**     | **Tecnologia**  |
| --------------- | --------------- |
| SGBD            | SQL Server      |
| Front end       | React           |
| Back end        | .NET            |
| Deploy          | LocalHost   |
| Containerização | Docker          |

