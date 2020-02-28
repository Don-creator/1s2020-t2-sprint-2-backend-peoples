CREATE DATABASE T_Peoples;

USE T_Peoples;

CREATE TABLE Funcionarios (
		IdFuncionarios INT PRIMARY KEY IDENTITY,
		NomeFuncionario VARCHAR (255),
		SobrenomeFuncionario VARCHAR (255)
); 

CREATE TABLE TipoUsuario (
		IdTipoUsuario INT PRIMARY KEY IDENTITY,
		Titulo		VARCHAR(255)
);

CREATE TABLE Usuario (
		IdUsuario INT PRIMARY KEY IDENTITY,
		Email	VARCHAR (255),
		Senha	VARCHAR (255),
		IdFuncionarios INT FOREIGN KEY REFERENCES Funcionarios (IdFuncionarios),
		IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);

DROP TABLE Usuario;
DROP TABLE TipoUsuario;
DROP TABLE Funcionarios;