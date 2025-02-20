package proyectoCarreraCoche;

public class Main {
    public static void main(String[] args) {
        // Crear dos coches
        Coche coche1 = new Coche("Toyota", "Supra", 120, 3000, "ABC123");
        Coche coche2 = new Coche("Ford", "Mustang", 95, 5000, "XYZ789");

        // Crear la carrera
        Carrera carrera = new Carrera(coche1, coche2, 100, 5);

        // Iniciar la carrera
        carrera.iniciarCarrera();
    }
}

