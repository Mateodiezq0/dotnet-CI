using dotnet_ci;
using Xunit;

public class CalculadoraTests
{
    [Fact]
    public void Sumar_DebeSumarCorrectamente()
    {
        var calc = new Calculadora();
        Assert.Equal(7, calc.Sumar(2, 2));
    }
}
