package proyectoCarreraCoche;

public class Coche {
    // Atributos
    private String marca;
    private String modelo;
    private int cv;  // Caballos de fuerza
    private int cc;  // Cilindrada
    private String matricula;
    private double velocidad; // en km/h
    private double kmRecorridos;

    // Constructor
    public Coche(String marca, String modelo, int cv, int cc, String matricula) {
        this.marca = marca;
        this.modelo = modelo;
        this.cv = cv;
        this.cc = cc;
        this.matricula = matricula;
        this.velocidad = 0;
        this.kmRecorridos = 0;
    }

    // Método para acelerar
    public void acelerar(int velocidadDeseada) {
        double incremento;
        
        if (cv < 100) {
            incremento = Math.random() * velocidadDeseada;
        } else {
            incremento = Math.random() * (velocidadDeseada - 10) + 10;
        }

        // Asegurar un mínimo de 10 km/h
        if (incremento < 10) {
            incremento = 10;
        }

        this.velocidad += incremento;
        this.kmRecorridos += incremento * 0.5; // Incremento en km recorridos

        System.out.println(marca + " " + modelo + " aceleró a " + velocidad + " km/h y recorrió " + kmRecorridos + " km.");
    }

    // Método para mostrar datos del coche
    public void mostrarDatos() {
        System.out.println("Marca: " + marca + ", Modelo: " + modelo + ", CV: " + cv + 
                           ", CC: " + cc + ", Matrícula: " + matricula +
                           ", Velocidad: " + velocidad + " km/h, KM Recorridos: " + kmRecorridos);
    }

    // Getters
    public double getKmRecorridos() {
        return kmRecorridos;
    }

    public String getMatricula() {
        return matricula;
    }
}
