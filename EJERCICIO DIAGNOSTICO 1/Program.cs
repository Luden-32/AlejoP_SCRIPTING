using System;
using System.Runtime.Serialization.Formatters;
class FibonacciPrimos
{
    static bool EsPrimo(long x)
    {
        if (x < 2 ) return false;
        if (x % 2 == 0) return x == 2; 
        long limite  =  (long)Math.Sqrt(x);
        for (long i = 3 ; i < limite; i += 2)
        {
            if (x % i == 0)
                return false; 
        }
        return true;

    }

    public static void ImprimirPrimosFibonacci(int n)
    {
        if (n <= 0)
        {
            Console.WriteLine("Debe pedir al menos 1 término.");
            return;
        }

        long a = 0, b = 1;
        for (int i = 1; i <= n; i++)
        {
            long fib = (i == 1) ? a : (i == 2) ? b : a + b;

            
            if (i > 2)
            {
                a = b;
                b = fib;
            }

            
            if (EsPrimo(fib))
                Console.WriteLine($"F({i}) = {fib} es primo.");
        }
    }

    
    static void Main()
    {
        Console.Write("¿Hasta cuántos términos de Fibonacci quieres revisar? ");
        int n = int.Parse(Console.ReadLine());
        ImprimirPrimosFibonacci(n);
    }
}
