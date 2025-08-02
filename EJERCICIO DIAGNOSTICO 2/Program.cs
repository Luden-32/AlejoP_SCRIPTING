using System;
using System.Linq;

public class ChanceCuatroCifras
{
    public static bool Gano(int num, int resultado)
    {
        return num == resultado;
    }

    public static int CalcularPremio(int num, int resultado, int apuesta)
    {
        string sNum = num.ToString("D4");
        string sRes = resultado.ToString("D4");

        if (sNum == sRes)
            return apuesta * 4500;

        if (sNum.OrderBy(c => c).SequenceEqual(sRes.OrderBy(c => c)))
            return apuesta * 200;

        if (sNum.Substring(1, 3) == sRes.Substring(1, 3))
            return apuesta * 400;

        if (sNum.Substring(2, 2) == sRes.Substring(2, 2))
            return apuesta * 50;

        if (sNum[3] == sRes[3])
            return apuesta * 5;

        return 0;
    }

    public static void Main()
    {
        int apuesta = 1000;
        Console.Write("Número jugado (0–9999): ");
        int num = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Número resultado (0–9999): ");
        int res = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine();
        Console.WriteLine(Gano(num, res)
            ? "¡Felicidades! Acertaste las 4 cifras exactas."
            : "No acertaste las 4 cifras exactas.");

        int premio = CalcularPremio(num, res, apuesta);
        if (premio > 0)
            Console.WriteLine($"¡Ganaste ${premio:N0}!");
        else
            Console.WriteLine("Conoces a yaper?");
    }
}
