#include <stdio.h>
#include <omp.h>

void fibonacci(int n) {
    int fib[n];
    fib = 0;
    fib = 1;

    #pragma omp parallel for shared(fib) private(i)
    for (int i = 2; i < n; i++) {
        fib[i] = fib[i-1] + fib[i-2];
    }

    // Imprimir la serie Fibonacci
    for (int i = 0; i < n; i++) {
        printf("%d ", fib[i]);
    }
    printf("\n");
}

int main() {
    int n = 10; // Número de términos de la serie Fibonacci
    fibonacci(n);
    return 0;
}
