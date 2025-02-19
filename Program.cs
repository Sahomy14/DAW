// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

// Definimos la clase Usuario para almacenar información del usuario y sus entrenamientos
class Usuario {
    public string Correo { get; set; } // Propiedad para guardar el correo del usuario
    public string Contraseña { get; set; } // Propiedad para guardar la contraseña del usuario
    public List<Entrenamiento> Entrenamientos { get; set; } = new List<Entrenamiento>(); // Lista de entrenamientos del usuario
}

// Definimos la clase Entrenamiento para guardar datos de cada entrenamiento
class Entrenamiento {
    public double Distancia { get; set; } // Propiedad para la distancia recorrida
    public TimeSpan Tiempo { get; set; } // Propiedad para el tiempo empleado
}

// Clase principal donde se ejecuta el programa
class Program {
    static List<Usuario> usuarios = new List<Usuario>(); // Lista que almacena todos los usuarios registrados
    static Usuario usuarioActual = null; // Variable para guardar el usuario que ha iniciado sesión

    static void Main() {
        while (true) { // Bucle infinito para que el menú siempre se muestre
            Console.Clear(); // Limpia la pantalla en cada iteración
            Console.WriteLine("\n--- RunningApp ---"); // Muestra el título de la aplicación
            Console.WriteLine("1. Registrar usuario"); // Opción para registrar usuario
            Console.WriteLine("2. Iniciar sesión"); // Opción para iniciar sesión
            Console.WriteLine("3. Salir"); // Opción para salir del programa
            Console.Write("Selecciona una opción: "); // Pide al usuario que elija una opción
            
            string opcion = Console.ReadLine(); // Captura la opción ingresada por el usuario
            switch (opcion) { // Evalúa la opción ingresada
                case "1": RegistrarUsuario(); break; // Llama a la función de registrar usuario
                case "2": IniciarSesion(); break; // Llama a la función de iniciar sesión
                case "3": return; // Sale del programa
                default: Console.WriteLine("Opción no válida"); break; // Mensaje de error si la opción no es válida
            }
        }
    }

    static void RegistrarUsuario() {
        Console.Write("Correo: ");
        string correo = Console.ReadLine(); // Captura el correo ingresado por el usuario
        if (usuarios.Exists(u => u.Correo == correo)) { // Verifica si el correo ya existe en la lista
            Console.WriteLine("El correo ya está registrado."); // Muestra mensaje si el correo ya está registrado
            return;
        }

        Console.Write("Contraseña: ");
        string contraseña = Console.ReadLine(); // Captura la contraseña ingresada por el usuario
        usuarios.Add(new Usuario { Correo = correo, Contraseña = contraseña }); // Agrega un nuevo usuario a la lista
        Console.WriteLine("Usuario registrado con éxito!"); // Mensaje de confirmación
    }

    static void IniciarSesion() {
        Console.Write("Correo: ");
        string correo = Console.ReadLine(); // Captura el correo ingresado
        Console.Write("Contraseña: ");
        string contraseña = Console.ReadLine(); // Captura la contraseña ingresada
        usuarioActual = usuarios.Find(u => u.Correo == correo && u.Contraseña == contraseña); // Busca el usuario en la lista
        
        if (usuarioActual != null) { // Si el usuario existe
            Console.WriteLine("Inicio de sesión exitoso!"); // Mensaje de éxito
            MenuUsuario(); // Llama al menú del usuario
        } else {
            Console.WriteLine("Credenciales incorrectas."); // Mensaje de error si los datos no coinciden
        }
    }

    static void MenuUsuario() {
        while (true) { // Menú en bucle para el usuario autenticado
            Console.Clear(); // Limpia la pantalla
            Console.WriteLine("\n--- Menú de Usuario ---"); // Muestra título del menú
            Console.WriteLine("1. Registrar entrenamiento"); // Opción para registrar entrenamiento
            Console.WriteLine("2. Listar entrenamientos"); // Opción para mostrar entrenamientos
            Console.WriteLine("3. Vaciar entrenamientos"); // Opción para eliminar todos los entrenamientos
            Console.WriteLine("4. Cerrar sesión"); // Opción para cerrar sesión
            Console.Write("Selecciona una opción: "); // Pide una opción
            
            string opcion = Console.ReadLine(); // Captura la opción elegida
            switch (opcion) {
                case "1": RegistrarEntrenamiento(); break; // Llama a la función de registrar entrenamiento
                case "2": ListarEntrenamientos(); break; // Llama a la función de listar entrenamientos
                case "3": VaciarEntrenamientos(); break; // Llama a la función de vaciar entrenamientos
                case "4": return; // Sale del menú y cierra sesión
                default: Console.WriteLine("Opción no válida"); break; // Mensaje de error si la opción no es válida
            }
        }
    }

    static void RegistrarEntrenamiento() {
        Console.Write("Distancia (km): ");
        double distancia = double.Parse(Console.ReadLine()); // Captura la distancia ingresada
        Console.Write("Tiempo (minutos): ");
        int minutos = int.Parse(Console.ReadLine()); // Captura el tiempo ingresado
        usuarioActual.Entrenamientos.Add(new Entrenamiento { Distancia = distancia, Tiempo = TimeSpan.FromMinutes(minutos) }); // Guarda el entrenamiento en la lista del usuario
        Console.WriteLine("Entrenamiento registrado!"); // Mensaje de confirmación
    }

    static void ListarEntrenamientos() {
        Console.WriteLine("\n--- Lista de Entrenamientos ---"); // Muestra el título de la lista
        foreach (var e in usuarioActual.Entrenamientos) { // Recorre la lista de entrenamientos
            Console.WriteLine($"Distancia: {e.Distancia} km - Tiempo: {e.Tiempo.TotalMinutes} min"); // Muestra cada entrenamiento
        }
        Console.WriteLine("Presiona una tecla para continuar..."); // Mensaje para continuar
        Console.ReadKey(); // Espera a que el usuario presione una tecla
    }

    static void VaciarEntrenamientos() {
        usuarioActual.Entrenamientos.Clear(); // Elimina todos los entrenamientos de la lista
        Console.WriteLine("Todos los entrenamientos han sido eliminados."); // Mensaje de confirmación
    }
}
