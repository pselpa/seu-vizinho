-- Criar banco de dados
CREATE DATABASE SeuVizinho

-- Deletar banco de dados
USE master;
DROP DATABASE SeuVizinho

-- Criar uma tabela de usuários
CREATE TABLE Users (
  Id UNIQUEIDENTIFIER NOT NULL,
  Name VARCHAR(100) NOT NULL,
  Profile INT NOT NULL,
  PRIMARY KEY (Id)
)

-- Deletar uma tabela
DROP TABLE Users

-- Criar um novo jogador (informando o id do time)
INSERT INTO Players VALUES (
    NEWID(),
    10,
    'fe4e52ce-b8db-4cf6-bdaa-7adecb242b0e',
    'Torcedor Torcedor'
)

-- Criar um novo Usuário
INSERT INTO Users VALUES(  -- Arrumar dados
    NEWID(),
    0,
    'Patricia Selpa',
    'patricia.selpa@gmail.com',
    'admin@123'
)

-- Deletar todos registros de uma tabela
DELETE FROM Users

-- Atualizar o nome do jogador que corresponde ao Id informado
UPDATE Players
    SET Name='Rony'
    WHERE Id='fdab7bd9-55cf-492d-b4d0-03a6ca7df2dc'


-- Obter todas as colunas dos jogadores
SELECT * FROM Players

-- Obter todas as colunas do jogador com o Id correspondente
SELECT * FROM Teams WHERE Id='fe4e52ce-b8db-4cf6-bdaa-7adecb242b0e'

-- Obter colunas de tuas tabelas que possuem vinculo
SELECT player.Id, player.Name, team.Id, team.Name
    FROM Players player
    LEFT JOIN Teams team
    ON player.TeamId = team.Id