Feature: Delete

Proceso de realizar Unit testing BDD en Eliminar

@EliminarClient
Scenario: Eliminar cliente de forma correcta
    Given Llenar los campos del formulario para eliminar
        | Cedula    | Apellidos     | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Gutierrez     | Fernando | 2002-08-15      | fernando.gomez@gmail.com    | 0991234567 | Quito           | true   |
    When Eliminar el usuario de la BDD
        | Cedula    | Apellidos     | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Gutierrez     | Fernando | 2002-08-15      | fernando.gomez@gmail.com    | 0991234567 | Quito           | true   |
    Then El resultado de la eliminación en la BDD
        | Cedula    | Apellidos     | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Gutierrez     | Fernando | 2002-08-15      | fernando.gomez@gmail.com    | 0991234567 | Quito           | true   |

@EliminarClientFalllido
Scenario: Eliminar cliente no se elimina
    Given Llenar los campos del formulario para eliminar
        | Cedula    | Apellidos     | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 10022     | Gutierrez     | Fernando | 2002-08-15      | fernando.gomez@gmail.com    | 0991234567 | Quito           | true   |
    When Eliminar el usuario de la BDD
        | Cedula    | Apellidos     | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 10022     | Gutierrez     | Fernando | 2002-08-15      | fernando.gomez@gmail.com    | 0991234567 | Quito           | true   |
    Then El resultado de la eliminación en la BDD
        | Cedula    | Apellidos     | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 10022     | Gutierrez     | Fernando | 2002-08-15      | fernando.gomez@gmail.com    | 0991234567 | Quito           | true   |
