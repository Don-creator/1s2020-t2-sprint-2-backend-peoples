USE T_Peoples;

INSERT INTO Funcionarios (NomeFuncionario, SobrenomeFuncionario)
VALUES			('Daniel','Araujo')
				,('Catarina','Estrada')
				,('Tadeu','Vitelli')
				,('Diego', 'Pings')
				,('Matheus', 'Pantera')
				,('Mateus', 'Pongs')
				,('Capao','Lucas')
				,('Saulo', 'X');

INSERT INTO TipoUsuario (Titulo)
VALUES		('Administrador')
			,('Funcionario');

INSERT INTO Usuario (Email, Senha, IdFuncionarios, IdTipoUsuario )
VALUES			('dan@email','dan123',1, 1)
				,('cat@email','cat123',2, 2)
				,('tad@email','tad123',3, 2)
				,('dig@email','dig123',4, 2 )
				,('mat@email','mat123',5, 2)
				,('mate@email','mate123',6,2)
				,('cap@email','cap123',7, 2)
				,('sau@email','sau123',8, 2);



