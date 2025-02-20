package proyectoCarreraCoche;

public class Carrera {
    private Coche coche1;
    private Coche coche2;
    private double kmTotales;
    private int numVueltas;
    private Coche ganador;

    // Constructor
    public Carrera(Coche coche1, Coche coche2, double kmTotales, int numVueltas) {
        this.coche1 = coche1;
        this.coche2 = coche2;
        this.kmTotales = kmTotales;
        this.numVueltas = numVueltas;
        this.ganador = null;
    }

    // Método para iniciar la carrera
    public void iniciarCarrera() {
        System.out.println("🔹 Carrera iniciada entre:");
        coche1.mostrarDatos();
        coche2.mostrarDatos();
        System.out.println("Distancia total: " + kmTotales + " km | Vueltas: " + numVueltas);

        int vuelta = 1; // Contador de vueltas

        // Se corre la cantidad de vueltas establecida
        while (true) {
            System.out.println("\n Vuelta " + vuelta);
            coche1.acelerar(30);
            coche2.acelerar(30);

            // Verificar si algún coche ha alcanzado o superado la meta
            if (coche1.getKmRecorridos() >= kmTotales || coche2.getKmRecorridos() >= kmTotales) {
                break; // Termina la carrera si uno ya llegó
            }

            vuelta++; // Incrementar vuelta

            // Si se han completado todas las vueltas sin alcanzar la meta, agregar vueltas extra
            if (vuelta > numVueltas) {
                System.out.println(" Ningún coche ha alcanzado la meta, agregando vueltas extra...");
                numVueltas++; // Aumenta el número de vueltas hasta que haya un ganador
            }
        }

        // Determinar el ganador después de finalizar la carrera
        if (coche1.getKmRecorridos() >= kmTotales && coche2.getKmRecorridos() >= kmTotales) {
            ganador = (coche1.getKmRecorridos() > coche2.getKmRecorridos()) ? coche1 : coche2;
        } else if (coche1.getKmRecorridos() >= kmTotales) {
            ganador = coche1;
        } else if (coche2.getKmRecorridos() >= kmTotales) {
            ganador = coche2;
        }

        // Mostrar mensaje de ganador
        if (ganador != null) {
            System.out.println("\n El ganador ha sido el coche con matrícula " + ganador.getMatricula());
        } else {
            System.out.println("\n No hubo un ganador."); // Esto ya no debería ocurrir con la nueva lógica
        }
    }

}
