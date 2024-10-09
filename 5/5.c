#include <stdio.h>
#include <stdlib.h>
#include <omp.h>
#include <math.h>

#define MAX_TERMS 100 


long long factorial(int n) {
    if (n == 0 || n == 1) return 1;
    long long f = 1;
    for (int i = 2; i <= n; i++) {
        f *= i;
    }
    return f;
}


int main() {
    double sum = 0.0;
    double pi;

    #pragma omp parallel reduction(+:sum)
    {
        #pragma omp for
        for (int k = 0; k < MAX_TERMS; k++) {
            long long numerator = factorial(4 * k) * (1103 + 26390 * k);
            long long denominator = pow(factorial(k), 4) * pow(396, 4 * k);

            sum += (double) numerator / denominator;
        }
    }

    pi = (double)(2 * sqrt(2) / 9801) / sum; // Cálculo de pi
    printf("Estimación de pi: %.10f\n", pi);

    return 0;
}
