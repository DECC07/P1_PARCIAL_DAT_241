#include <mpi.h>
#include <stdio.h>
#include <stdlib.h>

#define N 10 // Tamaño de los vectores

int main(int argc, char *argv[]) {
    int rank, size;
    int a[N], b[N], c[N];

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

    // Inicialización de los vectores en el procesador maestro (rank 0)
    if (rank == 0) {
        for (int i = 0; i < N; i++) {
            a[i] = i;
            b[i] = i * 2;
        }
    }

    // Distribuir los vectores a todos los procesos
    MPI_Bcast(a, N, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Bcast(b, N, MPI_INT, 0, MPI_COMM_WORLD);

    // Sumar las posiciones pares e impares
    if (rank == 1) {
        for (int i = 1; i < N; i += 2) {
            c[i] = a[i] + b[i];
        }
    } else if (rank == 2) {
        for (int i = 0; i < N; i += 2) {
            c[i] = a[i] + b[i];
        }
    }

    // Recolectar los resultados en el procesador maestro
    MPI_Reduce(rank == 1 ? MPI_IN_PLACE : c, c, N, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

    // Imprimir el resultado en el procesador maestro
    if (rank == 0) {
        printf("Vector resultante:\n");
        for (int i = 0; i < N; i++) {
            printf("%d ", c[i]);
        }
        printf("\n");
    }

    MPI_Finalize();
    return 0;
}
