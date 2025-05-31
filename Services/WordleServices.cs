namespace dotnet_CI.Services
{
    public class WordleService
    {
        private readonly string palabraSecreta = "MANGO";

        public string[] Verificar(string intento)
        {
            intento = intento.ToUpper();
            var resultado = new string[5];

            for (int i = 0; i < 5; i++)
            {
                if (intento[i] == palabraSecreta[i])
                    resultado[i] = "✔"; // letra correcta y en posición correcta
                else if (palabraSecreta.Contains(intento[i]))
                    resultado[i] = "~"; // letra correcta en lugar incorrecto
                else
                    resultado[i] = "✘"; // letra incorrecta
            }

            return resultado;
        }
    }
}
