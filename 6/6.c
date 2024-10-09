import multiprocessing as mp
from multiprocessing import Pool

def fibo(inicial, limite):
    vector = []
    ro = (1 + pow(5, 0.5)) / 2  # Raíz de oro
    for i in range(inicial, limite):
        fn = (pow(ro, i) - pow(-ro, -i)) / pow(5, 0.5)  # Fórmula de Binet
        vector.append(round(fn))  
    return vector

if __name__ == '__main__':
    cpu_count = mp.cpu_count()  
    limite = round(1200 / cpu_count) 
    print(f"Términos por proceso: {limite}")


    entradas = [(i * limite, (i + 1) * limite) for i in range(cpu_count)]
    

    with Pool() as pool:
        resultado = pool.starmap(fibo, entradas)  

    
    fibo_total = []
    for res in resultado:
        fibo_total.extend(res)

    
    print(fibo_total)
