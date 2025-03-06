Feature: Edit

Proceso de realizar Unit testing BDD en Edit

@EditarUnCliente
Scenario: Edicion exitosa de cliente
    Given Verificar si el cliente existe en la BDD
        | Cedula    | Apellidos     | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Gutierrez     | Fernando | 2002-08-15      | fernando.gomez@gmail.com    | 0998765432 | Quito           | true   |
    When Actualizar el usuario en la BDD
        | Cedula    | Apellidos    | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237763| Maradona     | Diego    | 2002-08-15      | fernando.flores@gmail.com   | 0991234567 | Ambato          | true   |
    Then El resultado de la actualización en la BDD
        | Cedula    | Apellidos    | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237763| Maradona     | Diego    | 2002-08-15      | fernando.flores@gmail.com   | 0991234567 | Ambato          | true   |

@EditarUnClienteFallido
Scenario: Edicion fallida de cliente
    Given Verificar si el cliente existe en la BDD
        | Cedula    | Apellidos     | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Gutierrez     | Fernando | 2002-08-15      | fernando.gomez@gmail.com    | 0998765432 | Quito           | true   |
    When Actualizar el usuario en la BDD
        | Cedula    | Apellidos     | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Gutierrez     | Fernando | 2002-08-15      | fernando.gomez@gmail.com    | 0998765432 | Quito           | true   |
    Then El resultado de la actualización en la BDD
        | Cedula    | Apellidos    | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237   | Galga        | Maradona | 2002-08-15      | flores@gmail.com            | 0991234567 | Ambato          | true   |
