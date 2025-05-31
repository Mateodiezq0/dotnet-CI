using dotnet_CI.Services;
using Xunit;

namespace dotnet_CI.Tests
{
    public class WordleServiceTests
    {
        [Fact]
        public void Verificar_DeberiaFallar()
        {
            var wordle = new WordleService();
            var resultado = wordle.Verificar("PERRO");

            // Este test está diseñado para fallar, PERRO no tiene ninguna ✔ en MANGO
            Assert.Equal("✔", resultado[0]);
        }
    }
}
