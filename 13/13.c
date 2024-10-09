#include <mpi.h>
#include <stdio.h>
#include <string.h>

#define N 10 // Número de cadenas
#define MAX_LEN 100 // Longitud máxima de cada cadena

int main(int argc, char *argv[]) {
    int rank, size;
    char data[N][MAX_LEN];

    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    if (size != 3) {
        if (rank == 0) {
            printf("Este programa necesita exactamente 3 procesos.\n");
        }
        MPI_Finalize();
        return 1;
    }

    // Inicialización del vector de cadenas en el procesador maestro (rank 0)
    if (rank == 0) {
        for (int i = 0; i < N; i++) {
            snprintf(data[i], MAX_LEN, "Cadena %d", i);
        }
    }

    // Distribuir el vector de cadenas a todos los procesos
    MPI_Bcast(data, N * MAX_LEN, MPI_CHAR, 0, MPI_COMM_WORLD);

    // Desplegar las posiciones pares e impares
    if (rank == 1) {
        printf("Procesador 1 (posiciones pares):\n");
        for (int i = 0; i < N; i += 2) {
            printf("%s\n", data[i]);
        }
    } else if (rank == 2) {
        printf("Procesador 2 (posiciones impares):\n");
        for (int i = 1; i < N; i += 2) {
            printf("%s\n", data[i]);
        }
    }

    MPI_Finalize();
    return 0;
}
