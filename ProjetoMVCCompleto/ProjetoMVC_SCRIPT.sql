CREATE DATABASE ProjetoMVC;

USE ProjetoMVC;

CREATE TABLE Usuario
(
	usuario_id INT IDENTITY PRIMARY KEY,
	nome VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL,
	senha VARCHAR(250) NOT NULL
);

SELECT * FROM Usuario;

CREATE TABLE Uniforme
(
	uniforme_id INT IDENTITY PRIMARY KEY,
	descricao VARCHAR(250) NOT NULL,
	cor VARCHAR(250) NOT NULL,
	tamanho VARCHAR(10) NOT NULL,
	categoria VARCHAR(250) NOT NULL
);

SELECT * FROM Uniforme;

DROP TABLE IF EXISTS Pedido_item;
DROP TABLE IF EXISTS Pedido;
CREATE TABLE Pedido (
	pedido_id INT IDENTITY PRIMARY KEY,
	data_hora DATETIME NOT NULL,
	usuario_id INT NOT NULL,
	status CHAR(1) NOT NULL DEFAULT 'P',
	FOREIGN KEY (usuario_id) REFERENCES Usuario (usuario_id)
);

CREATE TABLE Pedido_item (
	pedido_item_id INT IDENTITY PRIMARY KEY,
	pedido_id INT NOT NULL,
	uniforme_id INT NOT NULL,
	quantidade INT NOT NULL,
	FOREIGN KEY (pedido_id) REFERENCES Pedido (pedido_id),
	FOREIGN KEY (uniforme_id) REFERENCES Uniforme (uniforme_id)
);