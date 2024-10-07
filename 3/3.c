#include <stdio.h>

// Funciones para las operaciones usando punteros
void suma(int a, int b, int *c) {
    *c = a + b;
}

void resta(int a, int b, int *c) {
    *c = a - b;
}

void multiplicacion(int a, int b, int *c) {
    *c = a * b;
}

void division(int a, int b, float *c) {
    if (b != 0) {
        *c = (float)a / b; 
    } else {
        printf("Error: División por cero.\n");
        *c = 0; 
    }
}

int main() {
    int a, b;
    int cInt;
    float cFloat;

    printf("Introducir a: ");
    scanf("%d", &a);
    printf("Introducir b: ");
    scanf("%d", &b);

    suma(a, b, &cInt);
    printf("Suma: %d + %d = %d\n", a, b, cInt);

    resta(a, b, &cInt);
    printf("Resta: %d - %d = %d\n", a, b, cInt);

    multiplicacion(a, b, &cInt);
    printf("Multiplicación: %d * %d = %d\n", a, b, cInt);

    division(a, b, &cFloat);
    printf("División: %d / %d = %.2f\n", a, b, cFloat);

    return 0;
}
