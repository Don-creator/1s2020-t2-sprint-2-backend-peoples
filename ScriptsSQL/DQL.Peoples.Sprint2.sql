USE T_Peoples;

SELECT NomeFuncionario FROM Funcionarios;
SELECT SobrenomeFuncionario FROM Funcionarios;
SELECT * FROM Funcionarios;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;

SELECT IdFuncionarios, NomeFuncionario, SobrenomeFuncionario FROM Funcionarios;
UPDATE Funcionarios SET NomeFuncionario = 'Daniel', SobrenomeFuncionario = 'Araujo' WHERE IdFuncionarios = 1;

INSERT INTO Funcionarios (NomeFuncionario, SobrenomeFuncionario) VALUES	('Tapa', 'Pantera');

SELECT IdUsuario, IdFuncionarios, TipoUsuario.Titulo FROM Usuario
INNER JOIN TipoUsuario
ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario

SELECT IdUsuario


SELECT IdUsuario, IdFuncionarios, Funcionarios.NomeFuncionario FROM Usuario
INNER JOIN Funcionarios
ON Usuario.IdFuncionarios = Funcionarios.NomeFuncionario