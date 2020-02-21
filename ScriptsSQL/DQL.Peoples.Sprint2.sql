USE T_Peoples;

SELECT NomeFuncionario FROM Funcionarios;
SELECT SobrenomeFuncionario FROM Funcionarios;
SELECT * FROM Funcionarios;

SELECT IdFuncionarios, NomeFuncionario, SobrenomeFuncionario FROM Funcionarios;
UPDATE Funcionarios SET NomeFuncionario = 'Daniel', SobrenomeFuncionario = 'Araujo' WHERE IdFuncionarios = 1;

INSERT INTO Funcionarios (NomeFuncionario, SobrenomeFuncionario) VALUES	('Tapa', 'Pantera');
