#include <stdio.h>

void calcularPiIterativo(int n, double *pi) {
    *pi = 0.0; 
    for (int i = 0; i < n; i++) {
        double term = (i % 2 == 0 ? 1.0 : -1.0) / (2.0 * i + 1.0);
        *pi += term;
    }
    *pi *= 4; 
}

int main() {
    int n;
    double pi;

    printf("Ingrese el número de términos para el cálculo de pi (iterativo): ");
    scanf("%d", &n);

    calcularPiIterativo(n, &pi);
    printf("Valor aproximado de pi (iterativo): %.10f\n", pi);

    return 0;
}
