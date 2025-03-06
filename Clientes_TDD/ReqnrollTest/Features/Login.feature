Feature: Login

Login hacia el sistema de automation excercise .Login

@tag1
Scenario: Usuario ingresa credenciales incorrectas
	Given que el usuario esta en la pagina del login
	When ingresa el correo "testuser@gmail.com" y la contraseña "pass123"
	And hacer clic en el boton de inicio de sesión
	Then deberia mostrarse un mensaje de error

@LoginCorrecto
Scenario: Usuario ingresa credenciales correctas
	Given que el usuario esta en la pagina del login
	When ingresa el correo "adguevara7@espe.edu.ec" y la contraseña "admin123"
	And hacer clic en el boton de inicio de sesión
	Then deberia mostrarse un mensaje de error