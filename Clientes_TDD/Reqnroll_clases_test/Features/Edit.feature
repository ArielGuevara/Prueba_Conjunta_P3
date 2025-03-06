Feature: Edit

Proceso de realizar Unit testing BDD en Edit

@EditarUnCliente
Scenario: Edit Data
    Given Verificar si el cliente existe en la BDD
        | Cedula    | Apellidos | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Flores    | Fernando | 2002-08-15      | fernando.flores@gmail.com   | 0991234567 | Ambato          | true   |
    When Actualizar el usuario en la BDD
        | Cedula    | Apellidos | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Perez     | Fernando | 2002-08-15      | fernando.perez@gmail.com    | 0998765432 | Quito           | true   |
    Then El resultado de la actualización en la BDD
        | Cedula    | Apellidos | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Perez     | Fernando | 2002-08-15      | fernando.perez@gmail.com    | 0998765432 | Quito           | true   |
