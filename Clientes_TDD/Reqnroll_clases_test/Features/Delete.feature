Feature: Delete

Proceso de realizar Unit testing BDD en Eliminar

@EliminarClient
Scenario: Eliminar Data
    Given Llenar los campos del formulario para eliminar
        | Cedula    | Apellidos | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Flores    | Fernando | 2002-08-15      | fernando.flores@gmail.com   | 0991234567 | Ambato          | true   |
    When Eliminar el usuario de la BDD
        | Cedula    | Apellidos | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Flores    | Fernando | 2002-08-15      | fernando.flores@gmail.com   | 0991234567 | Ambato          | true   |
    Then El resultado de la eliminación en la BDD
        | Cedula    | Apellidos | Nombres  | FechaNacimiento | Mail                        | Telefono   | Direccion       | Estado |
        | 1002237765| Flores    | Fernando | 2002-08-15      | fernando.flores@gmail.com   | 0991234567 | Ambato          | true   |
