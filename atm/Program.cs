/*
 * Created by SharpDevelop.
 * User: danie
 * Date: 28/03/2024
 * Time: 0:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
// hola
using System;

namespace atm
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Title = "Cajero Automático";
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Clear();
			
			// Se crea la variable de tipo struct.
			metodos metodos_atm;
			// Se crea un valor entero menor que 1200 y se asigna al saldo.
			Random rnd = new Random();
			metodos_atm.saldo = rnd.Next(1200);
			
			while (pin() != true) {
				// Ejecuta la función "pin" mientras retorne un valor diferente de verdadero.
			}
			
			do
			{
				switch (menu()) {
					case '1':
						// Opción 1: Consulta de saldo.
						metodos_atm.consulta_saldo();
						break;
					case '2':
						// Opción 2: retiro de efectivo.
						while (metodos_atm.retiro() != true) {
							// Ejecuta la función "retiro" mientras retorne un valor diferente de verdadero.
						}
						break;
					case '3':
						// Opción 3: depósito de efectivo.
						while (metodos_atm.deposito() != true) {
							// Ejecuta la función "deposito" mientras retorne un valor diferente de verdadero.
						}
						break;
					case '4':
						// Opción 4: salir.
						creditos();
						Environment.Exit(0);
						break;
					default:
						Console.Clear();
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("\n\tDebe ingresar una opción válida.");
						Console.ForegroundColor = ConsoleColor.White;
						break;
				}
			} while (salir());
		}
		
		// Método (funcion) para validar el pin ingresado por el ususario. Se verifica que sea una cantidad de cuatro dígitos numéricos.
		// Tipo de retorno: booleano
		static Boolean pin() {
			try {
				string entrada;
				int pin;
				
				Console.Write("\n\tIngrese su pin: ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
				Console.Write("");
				entrada = Console.ReadLine();
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				if (entrada.Length == 4 && int.TryParse(entrada, out pin)) {
					return true;
				} else {
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\n\tEl pin debe ser de cuatro dígitos numéricos.");
					Console.ForegroundColor = ConsoleColor.White;
					
					return false;
				}
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("\t");
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				
				return false;
			}
		}
		
		// Método (procedimiento) para imprimir el menú del cajero automático y capturar la opción ingresada por el usuario.
		static int menu()
		{
			Console.Clear();
			Console.WriteLine("\n\t\tMenú:");
			Console.WriteLine("\t|----------------------------|");
			Console.WriteLine("\t| 1.\tConsulta de saldo    |");
			Console.WriteLine("\t| 2.\tRetiro de efectivo   |");
			Console.WriteLine("\t| 3.\tDepósito             |");
			Console.WriteLine("\t| 4.\tSalir                |");
			Console.WriteLine("\t|----------------------------|");
			Console.Write("\n\tSeleccione la acción que desea realizar: ");
			char opcion = Console.ReadKey().KeyChar;
			
			return opcion;
		}
		
		// Estructura que contiene las acciones que puede realizar el cajero.
		public struct metodos
		{
			public int saldo;
			
			// Método (procedimiento) para conslutar el saldo ficticio que tiene el usuario.
			public void consulta_saldo()
			{
				Console.Clear();
				try {
					Console.WriteLine("\n\tOpción seleccionada: Consulta de saldo");
					Console.Write("\tEl saldo que posee su cuenta es: ");
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.DarkGray;
					Console.WriteLine("{0}", saldo);
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
				} catch (Exception e) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("\t");
					Console.WriteLine(e.Message);
					Console.ForegroundColor = ConsoleColor.White;
				}
			}
			
			// Método (funcion) para retirar efectivo de la cuenta del usuario.
			// Tipo de retorno: booleano
			public Boolean retiro()
			{
				Console.Clear();
				try {
					string entrada;
					int cantidad;
					
					Console.WriteLine("\n\tOpción seleccionada: Depósito");
					Console.WriteLine("\tEl saldo que posee su cuenta es: {0}", saldo);
					Console.Write("\n\tIngrese la cantidad que desea retirar: ");
					entrada = Console.ReadLine();
					Console.Clear();
					
					if (!int.TryParse(entrada, out cantidad)) {
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("\n\tDebe ingresar un carácter numérico.");
						Console.ForegroundColor = ConsoleColor.White;
						Console.ReadKey(true);
						return false;
					} else if (cantidad == 0) {
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("\n\tLa cantidad a retirar no puede ser cero.");
						Console.ForegroundColor = ConsoleColor.White;
						Console.ReadKey(true);
						return false;
					} else if (cantidad > saldo) {
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("\n\tLa cantidad a retirar no puede ser mayor que su saldo disponible.");
						Console.ForegroundColor = ConsoleColor.White;
						Console.ReadKey(true);
						return false;
					} else if (cantidad % 5 != 0) {
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("\n\tSolo se pueden retirar cantidades múltiplos de cinco.");
						Console.ForegroundColor = ConsoleColor.White;
						Console.ReadKey(true);
						return false;
					}
					
					Console.WriteLine("\n\tTransacción realizada exitosamente.");
					Console.Write("\tCantidad retirada: ");
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("{0}", cantidad);
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					
					Console.Write("\tEl saldo que posee su cuenta es: ");
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.DarkGray;
					Console.WriteLine("{0}", saldo - cantidad);
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					
					saldo = saldo - cantidad;
					return true;
				} catch (Exception e) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("\t");
					Console.WriteLine(e.Message);
					Console.ForegroundColor = ConsoleColor.White;
					
					return false;
				}
			}
			
			// Método (funcion) para depositar saldo en la cuenta del ususario.
			// Tipo de retorno: booleano
			public Boolean deposito()
			{
				Console.Clear();
				try {
					string entrada;
					int cantidad;
					
					Console.WriteLine("\n\tOpción seleccionada: Depósito");
					Console.WriteLine("\tEl saldo que posee su cuenta es: {0}", saldo);
					Console.Write("\n\tIngrese la cantidad que desea depositar: ");
					entrada = Console.ReadLine();
					Console.Clear();
					
					if (!int.TryParse(entrada, out cantidad)) {
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("\n\tDebe ingresar un carácter numérico.");
						Console.ForegroundColor = ConsoleColor.White;
						Console.ReadKey(true);
						return false;
					}
					
					Console.WriteLine("\n\tTransacción realizada exitosamente.");
					Console.Write("\tCantidad depositada: ");
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.Green;
					Console.WriteLine("{0}", cantidad);
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					
					Console.Write("\tEl saldo que posee su cuenta es: ");
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.DarkGray;
					Console.WriteLine("{0}", saldo + cantidad);
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					
					saldo = saldo + cantidad;
					return true;
				} catch (Exception e) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("\t");
					Console.Write(e.Message);
					Console.ForegroundColor = ConsoleColor.White;
					
					return false;
				}
			}
		}
		
		// Método (procedimiento) para consultar al usuario si desea salir del programa.
		static Boolean salir()
		{
			try {
				Console.Write("\n\t¿Desea realizar otra acción? [Y/N]: ");
				char resp = Console.ReadKey().KeyChar;
				
				if (resp == 'Y' || resp == 'y') {
					return true;
				} else {
					creditos();
					return false;
				}
			} catch (Exception e) {
				Console.Write("\t");
				Console.WriteLine(e.Message);
				
				return false;
			}
		}
		
		// Método (procedimiento) para despedir al usuario y mostrar información del desarrollador.
		static void creditos()
		{
			Console.Clear();
			Console.WriteLine("\n\tGracias por su preferencia.");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("\tig:\thttps://www.instagram.com/dnlhernandez_/");
			Console.WriteLine("\tgithub:\thttps://github.com/ryukomvp");
			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.White;
			Console.WriteLine("\n-> Fin del programa.");
			Console.ReadKey();
		}
	}
}