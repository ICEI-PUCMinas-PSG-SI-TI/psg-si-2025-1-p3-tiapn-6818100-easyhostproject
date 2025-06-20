-- 1) Criação da base de dados
CREATE DATABASE [EasyHostDb];
GO

USE [EasyHostDb];
GO

-- 2) Tabela TipoUsuario
CREATE TABLE TipoUsuario (
    tipoUsuarioId INT           NOT NULL PRIMARY KEY,
    descricao     NVARCHAR(20)  NOT NULL
);
GO

-- 3) Tabela StatusReserva
CREATE TABLE StatusReserva (
    statusReservaId INT           NOT NULL PRIMARY KEY,
    descricao        NVARCHAR(20)  NOT NULL
);
GO

-- 4) Tabela Hotel
CREATE TABLE Hotel (
    id        UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    nomeHotel NVARCHAR(255)    NOT NULL
);
GO

-- 5) Tabela Usuario
CREATE TABLE Usuario (
    id             UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    nome           NVARCHAR(100)     NOT NULL,
    cpf            CHAR(11)          NOT NULL,
    salario        DECIMAL(10,2)     NOT NULL,
    ativo          BIT               NOT NULL,
    tipoUsuarioId  INT               NOT NULL,
    hotelIdFk      UNIQUEIDENTIFIER  NOT NULL,
    email          NVARCHAR(200)     NOT NULL,
    senha          NVARCHAR(256)     NOT NULL,
    CONSTRAINT FK_Usuario_TipoUsuario FOREIGN KEY (tipoUsuarioId)
        REFERENCES TipoUsuario(tipoUsuarioId),
    CONSTRAINT FK_Usuario_Hotel       FOREIGN KEY (hotelIdFk)
        REFERENCES Hotel(id)
);
GO

-- 6) Tabela Quarto
CREATE TABLE Quarto (
    id               UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    numQuarto        INT               NOT NULL,
    numCamasSolteiro INT               NOT NULL,
    numCamasCasal    INT               NOT NULL,
    maxPessoas       INT               NOT NULL,
    hotelIdFk        UNIQUEIDENTIFIER  NOT NULL,
    precoDiaria      DECIMAL(18,2)     NOT NULL,
    CONSTRAINT FK_Quarto_Hotel FOREIGN KEY (hotelIdFk)
        REFERENCES Hotel(id)
);
GO

-- 7) Tabela Hospede
CREATE TABLE Hospede (
    id        UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    nome      NVARCHAR(255)    NOT NULL,
    cpf       CHAR(11)         NOT NULL,
    hotelIdFk UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_Hospede_Hotel FOREIGN KEY (hotelIdFk)
        REFERENCES Hotel(id)
);
GO

-- 8) Tabela Reserva
CREATE TABLE Reserva (
    id                UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    hospedeIdFk       UNIQUEIDENTIFIER NULL,
    quartoIdFk        UNIQUEIDENTIFIER NOT NULL,
    dataEntrada       DATE              NOT NULL,
    dataSaida         DATE              NOT NULL,
    statusReservaIdFk INT               NOT NULL,
    hotelIdFk         UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_Reserva_Hospede       FOREIGN KEY (hospedeIdFk)
        REFERENCES Hospede(id),
    CONSTRAINT FK_Reserva_Quarto        FOREIGN KEY (quartoIdFk)
        REFERENCES Quarto(id),
    CONSTRAINT FK_Reserva_StatusReserva FOREIGN KEY (statusReservaIdFk)
        REFERENCES StatusReserva(statusReservaId),
    CONSTRAINT FK_Reserva_Hotel         FOREIGN KEY (hotelIdFk)
        REFERENCES Hotel(id)
);
GO

-- 9) Tabela Consumo
CREATE TABLE Consumo (
    id          UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    nome        NVARCHAR(200)    NOT NULL,
    preco       DECIMAL(18,2)    NOT NULL,
    hospedeIdFk UNIQUEIDENTIFIER NOT NULL,
    hotelIdFk   UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_Consumo_Hospede FOREIGN KEY (hospedeIdFk)
        REFERENCES Hospede(id),
    CONSTRAINT FK_Consumo_Hotel   FOREIGN KEY (hotelIdFk)
        REFERENCES Hotel(id)
);
GO

--  Inserindo enums TipoUsuario 
INSERT INTO TipoUsuario (tipoUsuarioId, descricao) VALUES
    (1, 'Funcionario'), 
    (2, 'Administrador'); 
GO

-- Inserindo enums StatusReserva 
INSERT INTO StatusReserva (statusReservaId, descricao) VALUES
    (1, 'Reservada'), 
    (2, 'Confirmada'), 
    (3, 'Andamento'), 
    (4, 'Concluida'), 
    (5, 'Cancelada'); 
GO
