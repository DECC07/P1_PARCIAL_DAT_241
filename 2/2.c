#include <stdio.h>

// Funciones para las operaciones
// Suma
int suma(int a, int b) {
    return a + b;
}
// Resta
int resta(int a, int b) {
    return a - b;
}
// multiplicacion
int multiplicacion(int a, int b) {
    return a * b;
}
// Division
float division(int a, int b) {
    if (b != 0) {
        return (float)a / b; 
    } else {
        printf("Error: División por cero.\n");
        return 0; 
    }
}

int main() {
    int a, b;

    printf("Introducir a: ");
    scanf("%d", &a);
    printf("Introducir b: ");
    scanf("%d", &b);

    printf("Suma: %d + %d = %d\n", a, b, suma(a, b));
    printf("Resta: %d - %d = %d\n", a, b, resta(a, b));
    printf("Multiplicación: %d * %d = %d\n", a, b, multiplicacion(a, b));
    printf("División: %d / %d = %.2f\n", a, b, division(a, b));

    return 0;
}
