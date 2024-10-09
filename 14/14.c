#include <mpi.h>
#include <stdio.h>
#include <stdlib.h>

#define N 4 // Tamaño de las matrices (N x N)

void print_matrix(int matrix[N][N]) {
    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++) {
            printf("%d ", matrix[i][j]);
        }
        printf("\n");
    }
}

int main(int argc, char *argv[]) {
    int rank, size;
    int A[N][N], B[N][N], C[N][N];

    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    if (size != N) {
        if (rank == 0) {
            printf("Este programa necesita exactamente %d procesos.\n", N);
        }
        MPI_Finalize();
        return 1;
    }

    // Inicialización de las matrices en el procesador maestro (rank 0)
    if (rank == 0) {
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                A[i][j] = i + j;
                B[i][j] = i * j;
            }
        }
        printf("Matriz A:\n");
        print_matrix(A);
        printf("Matriz B:\n");
        print_matrix(B);
    }

    // Distribuir la matriz B a todos los procesos
    MPI_Bcast(B, N*N, MPI_INT, 0, MPI_COMM_WORLD);

    // Distribuir las filas de la matriz A a cada proceso
    int row[N];
    MPI_Scatter(A, N, MPI_INT, row, N, MPI_INT, 0, MPI_COMM_WORLD);

    // Cada proceso calcula su parte de la matriz C
    int result_row[N] = {0};
    for (int j = 0; j < N; j++) {
        for (int k = 0; k < N; k++) {
            result_row[j] += row[k] * B[k][j];
        }
    }

    // Recolectar los resultados en el procesador maestro
    MPI_Gather(result_row, N, MPI_INT, C, N, MPI_INT, 0, MPI_COMM_WORLD);

    // Imprimir la matriz resultante en el procesador maestro
    if (rank == 0) {
        printf("Matriz C (resultado de A x B):\n");
        print_matrix(C);
    }

    MPI_Finalize();
    return 0;
}
