#include <stdio.h>

void fibonacci(int n, int fib[]) {
    if (n <= 0) return;  // No hay términos que calcular
    if (n >= 1) fib[0] = 0;  // Primer término
    if (n >= 2) fib[1] = 1;  // Segundo término

    // Calcular los términos de Fibonacci
    for (int i = 2; i < n; i++) {
        fib[i] = fib[i - 1] + fib[i - 2];
    }
}

int main() {
    int n;

    printf("Ingrese el número de términos de la secuencia de Fibonacci a calcular: ");
    scanf("%d", &n);

    // Definir el tamaño del vector según n
    int fib[n];

    // Calcular la secuencia de Fibonacci
    fibonacci(n, fib);

    // Mostrar los términos de la secuencia
    printf("Los primeros %d términos de la secuencia de Fibonacci son:\n", n);
    for (int i = 0; i < n; i++) {
        printf("%d ", fib[i]);
    }
    printf("\n");

    return 0;
}
