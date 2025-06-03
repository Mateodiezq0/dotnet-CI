using System;

namespace dotnet_ci;

public class Calculadora
{
    public int Sumar(int a, int b) => a + b;
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hola CI!");
    }
}
