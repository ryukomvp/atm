/*
 * Created by SharpDevelop.
 * User: danie
 * Date: 28/03/2024
 * Time: 0:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
			
			int saldo;
			Random rnd = new Random();
			saldo = rnd.Next(1000);
			
			while (pin() != true) {
				// ejecuta la función "pin" mientras retorne un valor diferente de verdadero.
			}
			
			do
			{
				switch (menu()) {
					case 1:
						consulta_saldo(saldo);
						break;
					case 2:
						while (retiro(saldo) != true) {
							// ejecuta la función "retiro" mientras retorne un valor diferente de verdadero.
						}
						break;
					case 3:
						while (deposito(saldo) != true) {
							// ejecuta la función "deposito" mientras retorne un valor diferente de verdadero.
						}
						break;
					case 4:
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
		
		static Boolean pin() {
			try {
				string entrada;
				int pin;
				
				Console.Write("\n\tIngrese su pin: ");
				entrada = Console.ReadLine();
				if (entrada.Length == 4 && int.TryParse(entrada, out pin)) {
					return true;
				} else {
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\n\tEl pin debe ser de cuatro dígitos númericos.");
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
		
		static int menu()
		{
			Console.Clear();
			int opcion;
			Console.WriteLine("\n\t\tMenú:");
			Console.WriteLine("\t|----------------------------|");
			Console.WriteLine("\t| 1.\tConsulta de saldo    |");
			Console.WriteLine("\t| 2.\tRetiro de efectivo   |");
			Console.WriteLine("\t| 3.\tDepósito             |");
			Console.WriteLine("\t| 4.\tSalir                |");
			Console.WriteLine("\t|----------------------------|");
			Console.Write("\n\tSeleccione la acción que desea realizar: ");
			opcion = int.Parse(Console.ReadLine());
			
			return opcion;
		}
		
		static void consulta_saldo(int saldo)
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
		
		static Boolean retiro(int saldo)
		{
			Console.Clear();
			try {
				int cantidad;
				
				Console.WriteLine("\n\tOpción seleccionada: Depósito");
				Console.WriteLine("\tEl saldo que posee su cuenta es: {0}", saldo);
				Console.Write("\n\tIngrese la cantidad que desea retirar: ");
				int.TryParse(Console.ReadLine(), out cantidad);
				Console.Clear();
				
				if (cantidad == 0) {
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
				
				return true;
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("\t");
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				
				return false;
			}
		}
		
		static Boolean deposito(int saldo)
		{
			Console.Clear();
			try {
				int cantidad;
				
				Console.WriteLine("\n\tOpción seleccionada: Depósito");
				Console.WriteLine("\tEl saldo que posee su cuenta es: {0}", saldo);
				Console.Write("\n\tIngrese la cantidad que desea depositar: ");
				int.TryParse(Console.ReadLine(), out cantidad);
				Console.Clear();
				
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
				
				return true;
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("\t");
				Console.Write(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				
				return false;
			}
		}
		
		static Boolean salir()
		{
			try {
				string resp;
				Console.Write("\n\t¿Desea realizar otra acción? [Y/N]: ");
				resp = Console.ReadLine();
				
				if (resp == "Y" || resp == "y") {
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