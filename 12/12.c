#include <stdio.h>
#include <stdlib.h>
#include <omp.h>

void fibonacci(int n, long long *fib) {
    // Manejo de los casos base
    if (n >= 0) fib[0] = 0;
    if (n >= 1) fib[1] = 1;

    // Uso de OpenMP para calcular los valores de Fibonacci
    #pragma omp parallel for
    for (int i = 2; i <= n; i++) {
        fib[i] = fib[i - 1] + fib[i - 2];
    }
}

int main() {
    int n;
    printf("Ingrese el número de términos de la serie Fibonacci que desea calcular: ");
    scanf("%d", &n);

    // Validar entrada
    if (n < 0) {
        printf("Por favor, ingrese un número entero no negativo.\n");
        return 1;
    }

    // Arreglo para almacenar los términos de Fibonacci
    long long *fib = malloc((n + 1) * sizeof(long long));
    if (fib == NULL) {
        printf("Error al asignar memoria.\n");
        return 1;
    }

    // Calcular la serie de Fibonacci
    fibonacci(n, fib);

    // Mostrar los resultados
    printf("Serie de Fibonacci hasta el término %d:\n", n);
    for (int i = 0; i <= n; i++) {
        printf("F(%d) = %lld\n", i, fib[i]);
    }

    // Liberar la memoria
    free(fib);
    return 0;
}
