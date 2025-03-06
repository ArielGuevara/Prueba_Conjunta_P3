Feature: Insert

Proceso de realizar Unit testing BDD en Insert

@InsertClient
Scenario: Insert Data
	Given Llenar los campos del formulario
		| Cedula	| Apellidos | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Flores    | Fernando | 2002-08-15      | fernando.flores@gmail.com   | 0991234567 | Ambato          | true   |
	When Registro del usuario en la BDD
		| Cedula	| Apellidos | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Flores    | Fernando | 2002-08-15      | fernando.flores@gmail.com   | 0991234567 | Ambato          | true   |
	Then El resultado del registro en la BDD
		| Cedula	| Apellidos | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Flores    | Fernando | 2002-08-15      | fernando.flores@gmail.com   | 0991234567 | Ambato          | true   |

