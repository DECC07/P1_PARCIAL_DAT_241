#include <stdio.h>
#include <stdlib.h>
#include <mpi.h>

#define VECTOR_SIZE 10

int main(int argc, char *argv[]) {
    int rank, size;
    int vectorA[VECTOR_SIZE], vectorB[VECTOR_SIZE];
    int result[2] = {0, 0}; // result[0] para impares, result[1] para pares
    int finalResult[2] = {0, 0}; // Suma total en el maestro
    int i;

    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    // Inicializar vectores en el proceso maestro
    if (rank == 0) {
        // Llenar los vectores con valores de ejemplo
        for (i = 0; i < VECTOR_SIZE; i++) {
            vectorA[i] = i + 1;  // Valores 1, 2, ..., 10
            vectorB[i] = (i + 1) * 2;  // Valores 2, 4, ..., 20
        }

        // Mostrar los vectores en el proceso maestro
        printf("Vector A: ");
        for (i = 0; i < VECTOR_SIZE; i++) {
            printf("%d ", vectorA[i]);
        }
        printf("\n");

        printf("Vector B: ");
        for (i = 0; i < VECTOR_SIZE; i++) {
            printf("%d ", vectorB[i]);
        }
        printf("\n");
    }

    // Broadcast de los vectores al resto de los procesos
    MPI_Bcast(vectorA, VECTOR_SIZE, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Bcast(vectorB, VECTOR_SIZE, MPI_INT, 0, MPI_COMM_WORLD);

    // Procesadores 1 y 2 suman posiciones impares y pares
    if (rank == 1) {
        for (i = 1; i < VECTOR_SIZE; i += 2) {
            result[0] += vectorA[i] + vectorB[i];
            printf("Procesador 1 sumando posiciones impares: %d + %d = %d\n", vectorA[i], vectorB[i], vectorA[i] + vectorB[i]);
        }
    } else if (rank == 2) {
        for (i = 0; i < VECTOR_SIZE; i += 2) {
            result[1] += vectorA[i] + vectorB[i];
            printf("Procesador 2 sumando posiciones pares: %d + %d = %d\n", vectorA[i], vectorB[i], vectorA[i] + vectorB[i]);
        }
    }

    // Recopilar resultados en el proceso maestro
    MPI_Reduce(result, finalResult, 2, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

    // El proceso maestro imprime el resultado total
    if (rank == 0) {
        printf("Resultado total:\n");
        printf("Suma de posiciones impares: %d\n", finalResult[0]);
        printf("Suma de posiciones pares: %d\n", finalResult[1]);
        printf("Suma total: %d\n", finalResult[0] + finalResult[1]);
    }

    MPI_Finalize();
    return 0;
}
