CREATE DATABASE EasyHostBd;
GO

USE EasyHostBd;
GO

-- 1) Lookup tables de enumerações
CREATE TABLE TipoUsuario (
  tipoUsuarioId INT IDENTITY(1,1) PRIMARY KEY,
  descricao     NVARCHAR(20) NOT NULL
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
GO

-- 2) Tabela principal de hotéis
CREATE TABLE Hotel (
  id        INT IDENTITY(1,1) PRIMARY KEY,
  nomeHotel NVARCHAR(255) NOT NULL
);
GO

-- 3) Usuário
CREATE TABLE Usuario (
  id             INT IDENTITY(1,1) PRIMARY KEY,
  nome           NVARCHAR(100) NOT NULL,
  cpf            CHAR(11) NOT NULL UNIQUE,
  salario        DECIMAL(10,2) NOT NULL,
  ativo          BIT NOT NULL DEFAULT 1,
  TipoUsuario    INT NOT NULL REFERENCES TipoUsuario(tipoUsuarioId) ON DELETE NO ACTION,
  hotelIdFk      INT NOT NULL REFERENCES Hotel(id) ON DELETE CASCADE
);
GO

-- 4) Alterações
CREATE TABLE Alteracoes (
  id             INT IDENTITY(1,1) PRIMARY KEY,
  usuarioIdFk    INT NULL REFERENCES Usuario(id) ON DELETE SET NULL,
  dataHora       DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  descricao      NVARCHAR(100) NOT NULL,
  detalhes       NVARCHAR(MAX) NULL
);
GO

-- 5) Hóspede
CREATE TABLE Hospede (
  id        INT IDENTITY(1,1) PRIMARY KEY,
  nome      NVARCHAR(255) NOT NULL,
  cpf       CHAR(11) NOT NULL UNIQUE,
  hotelIdFk INT NOT NULL REFERENCES Hotel(id) ON DELETE CASCADE
);
GO

-- 6) Quarto
CREATE TABLE Quarto (
  id               INT IDENTITY(1,1) PRIMARY KEY,
  numQuarto        INT NOT NULL,
  numCamasSolteiro INT NOT NULL DEFAULT 0,
  numCamasCasal    INT NOT NULL DEFAULT 0,
  maxPessoas       INT NOT NULL DEFAULT 1,
  adicionais       NVARCHAR(MAX) NULL,
  hotelIdFk        INT NOT NULL REFERENCES Hotel(id) ON DELETE CASCADE
);
GO

-- 7) Reserva
CREATE TABLE Reserva (
  id                INT IDENTITY(1,1) PRIMARY KEY,
  hospedeIdFk       INT NULL    REFERENCES Hospede(id) ON DELETE CASCADE,
  quartoIdFk        INT NOT NULL REFERENCES Quarto(id) ON DELETE NO ACTION,
  dataEntrada       DATE NOT NULL,
  dataSaida         DATE NOT NULL,
  statusReservaIdFk INT NOT NULL DEFAULT 1 REFERENCES StatusReserva(statusReservaId) ON DELETE NO ACTION
);
GO

-- 8) Serviço
CREATE TABLE Servico (
  id                     INT IDENTITY(1,1) PRIMARY KEY,
  funcionarioResponsavel NVARCHAR(100) NOT NULL,
  descricao              NVARCHAR(MAX) NULL,
  statusServicoIdFk      INT NOT NULL DEFAULT 1 REFERENCES StatusServico(statusServicoId) ON DELETE NO ACTION,
  criadoEm               DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  concluidoEm            DATETIME2 NULL,
  reservaIdFk            INT NOT NULL REFERENCES Reserva(id) ON DELETE CASCADE
);
GO
