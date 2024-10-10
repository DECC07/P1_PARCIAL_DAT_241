#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <mpi.h>

#define MAX_STRING_LENGTH 100
#define VECTOR_SIZE 10

int main(int argc, char *argv[]) {
    int rank, size;
    char vector[VECTOR_SIZE][MAX_STRING_LENGTH];
    char received_string[MAX_STRING_LENGTH];
    
    // Inicializar MPI
    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    if (size < 3) {
        if (rank == 0) {
            fprintf(stderr, "Este programa requiere al menos 3 procesos.\n");
        }
        MPI_Finalize();
        return EXIT_FAILURE;
    }

    if (rank == 0) {
        // Procesador 0: Inicializa el vector de cadenas
        for (int i = 0; i < VECTOR_SIZE; i++) {
            snprintf(vector[i], MAX_STRING_LENGTH, "Cadena %d", i);
        }

        // Enviar las cadenas a los procesadores 1 y 2
        for (int i = 0; i < VECTOR_SIZE; i++) {
            if (i % 2 == 0) {
                MPI_Send(vector[i], MAX_STRING_LENGTH, MPI_CHAR, 1, 0, MPI_COMM_WORLD);
            } else {
                MPI_Send(vector[i], MAX_STRING_LENGTH, MPI_CHAR, 2, 0, MPI_COMM_WORLD);
            }
        }

        // Imprimir el vector original
        printf("Procesador 0 envió las siguientes cadenas:\n");
        for (int i = 0; i < VECTOR_SIZE; i++) {
            printf("  %s\n", vector[i]);
        }
    } else if (rank == 1) {
        // Procesador 1: Recibe y despliega cadenas en posiciones pares
        printf("Procesador 1:\n");
        for (int i = 0; i < (VECTOR_SIZE + 1) / 2; i++) {
            MPI_Recv(received_string, MAX_STRING_LENGTH, MPI_CHAR, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
            printf("  Recibió: %s\n", received_string);
        }
    } else if (rank == 2) {
        // Procesador 2: Recibe y despliega cadenas en posiciones impares
        printf("Procesador 2:\n");
        for (int i = 0; i < VECTOR_SIZE / 2; i++) {
            MPI_Recv(received_string, MAX_STRING_LENGTH, MPI_CHAR, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
            printf("  Recibió: %s\n", received_string);
        }
    }

    // Finalizar MPI
    MPI_Finalize();
    return 0;
}
