#include <stdio.h>

double calcularPiRecursivo(int n, int i) {
    if (i >= n) {
        return 0.0; 
    }
    double term = (i % 2 == 0 ? 1.0 : -1.0) / (2.0 * i + 1.0);
    return term + calcularPiRecursivo(n, i + 1); 
}

int main() {
    int n;
    double pi;

    printf("Ingrese el número de términos para el cálculo de pi (recursivo): ");
    scanf("%d", &n);

    pi = calcularPiRecursivo(n, 0) * 4; // Multiplicamos el resultado por 4
    printf("Valor aproximado de pi (recursivo): %.10f\n", pi);

    return 0;
}
