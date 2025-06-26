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
![Cadastro](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20CADASTRO%20DE%20USUARIO.jpg)

### <p align="center">LOGIN</p>
![Login](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/WIREFRAME%20-%20LOGIN%20DE%20USUARIO.png)

### <p align="center">HOME</p>
![Home](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20HOME.png)

### <p align="center">MENU DE QUARTOS (Admin)</p>
![MenuQuarto](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20MENU%20DE%20QUARTOS.png)

### <p align="center">CADASTRO DE QUARTOS (Admin)</p>
![CadastroQuarto](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20CADASTRO%20DE%20QUARTOS.png)

### <p align="center">EDIÇÃO DE QUARTOS</p>
![EditarQuarto](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20EDI%C3%87%C3%83O%20DE%20QUARTO%20(ADMIN).png)

### <p align="center">MENU DE HOSPEDES</p>
![MenuHospede](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/WIREFRAME%20-%20MENU%20DE%20HOSPEDES.jpg)

### <p align="center">CADASTRO DE HOSPEDES</p>
![CadastroHospede](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/WIREFRAME%20-%20CADASTRO%20DE%20HOSPEDE.png)

### <p align="center">CADASTRO CONSUMO</p>
![CadastroConsumo](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20CADASTRO%20DE%20CONSUMO.png)

### <p align="center">LISTA CONSUMO DE HOSPEDE</p>
![ListaConsumo](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20LISTA%20DE%20CONSUMO%20HOSPODES.jpg)

### <p align="center">MENU RESERVAS</p>
![MenuReservas](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20PAGINA%20DE%20RESERVAS.jpg)

### <p align="center">CADASTRO RESERVA</p>
![CadastrorReserva](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20CADASTRO%20DE%20RESERVAS.png)

### <p align="center">CONSUMO TOTAL RESERVA</p>
![ConsumoTotalReserva](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20VISUALIZAR%20O%20CONSUMO%20TOTAL%20DA%20RESERVA.jpg)

### <p align="center">RELATÓRIO GERAL</p>
![Relatorio](https://github.com/ICEI-PUCMinas-PSG-SI-TI/psg-si-2025-1-p3-tiapn-6818100-easyhostproject/blob/main/docs/images/WIREFRAMES/Wireframes%20-%20MENU%20DE%20RELATORIOS.jpg)


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

-- 1) Criação da base de dados
CREATE DATABASE [EasyHostDb];

USE [EasyHostDb];

-- 2) Tabela TipoUsuario
CREATE TABLE TipoUsuario (
    tipoUsuarioId INT           NOT NULL PRIMARY KEY,
    descricao     NVARCHAR(20)  NOT NULL
);

-- 3) Tabela StatusReserva
CREATE TABLE StatusReserva (
    statusReservaId INT           NOT NULL PRIMARY KEY,
    descricao        NVARCHAR(20) NOT NULL
);

-- 4) Tabela Hotel
CREATE TABLE Hotel (
    id        UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    nomeHotel NVARCHAR(255)    NOT NULL
);

-- 5) Tabela Usuario
CREATE TABLE Usuario (
    id             UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    nome           NVARCHAR(100)     NOT NULL,
    cpf            CHAR(11)          NOT NULL UNIQUE,
    salario        DECIMAL(10,2)     NOT NULL,
    ativo          BIT               NOT NULL DEFAULT 1,
    tipoUsuarioId  INT               NOT NULL,
    hotelIdFk      UNIQUEIDENTIFIER  NOT NULL,
    email          NVARCHAR(200)     NOT NULL,
    senha          NVARCHAR(256)     NOT NULL,
    CONSTRAINT FK_Usuario_TipoUsuario FOREIGN KEY (tipoUsuarioId) REFERENCES TipoUsuario(tipoUsuarioId),
    CONSTRAINT FK_Usuario_Hotel FOREIGN KEY (hotelIdFk) REFERENCES Hotel(id)
);

-- 6) Tabela Quarto
CREATE TABLE Quarto (
    id               UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    numQuarto        INT               NOT NULL,
    numCamasSolteiro INT               NOT NULL DEFAULT 0,
    numCamasCasal    INT               NOT NULL DEFAULT 0,
    maxPessoas       INT               NOT NULL DEFAULT 1,
    hotelIdFk        UNIQUEIDENTIFIER  NOT NULL,
    precoDiaria      DECIMAL(18,2)     NOT NULL,
    CONSTRAINT FK_Quarto_Hotel FOREIGN KEY (hotelIdFk) REFERENCES Hotel(id)
);

-- 7) Tabela Hospede
CREATE TABLE Hospede (
    id        UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    nome      NVARCHAR(255)    NOT NULL,
    cpf       CHAR(11)         NOT NULL UNIQUE,
    hotelIdFk UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_Hospede_Hotel FOREIGN KEY (hotelIdFk) REFERENCES Hotel(id)
);

-- 8) Tabela Reserva
CREATE TABLE Reserva (
    id                UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    hospedeIdFk       UNIQUEIDENTIFIER NULL,
    quartoIdFk        UNIQUEIDENTIFIER NOT NULL,
    dataEntrada       DATE              NOT NULL,
    dataSaida         DATE              NOT NULL,
    statusReservaIdFk INT               NOT NULL DEFAULT 1,
    hotelIdFk         UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_Reserva_Hospede FOREIGN KEY (hospedeIdFk) REFERENCES Hospede(id),
    CONSTRAINT FK_Reserva_Quarto FOREIGN KEY (quartoIdFk) REFERENCES Quarto(id),
    CONSTRAINT FK_Reserva_StatusReserva FOREIGN KEY (statusReservaIdFk) 
    REFERENCES StatusReserva(statusReservaId),
    CONSTRAINT FK_Reserva_Hotel FOREIGN KEY (hotelIdFk) REFERENCES Hotel(id)
);

-- 9) Tabela Consumo
    CREATE TABLE Consumo (
    id          UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    nome        NVARCHAR(200)    NOT NULL,
    preco       DECIMAL(18,2)    NOT NULL,
    hospedeIdFk UNIQUEIDENTIFIER NOT NULL,
    hotelIdFk   UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_Consumo_Hospede FOREIGN KEY (hospedeIdFk) REFERENCES Hospede(id),
    CONSTRAINT FK_Consumo_Hotel FOREIGN KEY (hotelIdFk) REFERENCES Hotel(id)
    );

-- 10) Inserts: TipoUsuario
    INSERT INTO TipoUsuario (tipoUsuarioId, descricao) VALUES
    (1, 'Funcionario'), 
    (2, 'Administrador');

-- 11) Inserts: StatusReserva
    INSERT INTO StatusReserva (statusReservaId, descricao) VALUES
    (1, 'Reservada'), 
    (2, 'Confirmada'), 
    (3, 'Em Andamento'), 
    (4, 'Concluida'), 
    (5, 'Cancelada');


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

