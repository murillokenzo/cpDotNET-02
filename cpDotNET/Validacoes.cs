// Murillo Kenzo Loureiro Kacinvazaki - RM566948

namespace Classes
{
    public static class Validacoes
    {
        public static string LerTextoObrigatorio(string pergunta)
        {
            while (true)
            {
                Console.WriteLine(pergunta);
                string entrada = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    return entrada.Trim();
                }

                Console.WriteLine("Este campo não pode ficar vazio!");
            }
        }

        public static int LerInteiro(string pergunta)
        {
            while (true)
            {
                Console.WriteLine(pergunta);
                string entrada = Console.ReadLine() ?? "";

                try
                {
                    return int.Parse(entrada);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Digite apenas números inteiros!");
                }
            }
        }

        public static int LerInteiroNoIntervalo(string pergunta, int min, int max)
        {
            while (true)
            {
                int valor = LerInteiro(pergunta);

                if (valor >= min && valor <= max)
                {
                    return valor;
                }

                Console.WriteLine($"Digite um número entre {min} e {max}!");
            }
        }

        public static bool LerSimNao(string pergunta)
        {
            while (true)
            {
                Console.WriteLine(pergunta);
                string entrada = (Console.ReadLine() ?? "").Trim().ToLower();

                if (entrada == "s") return true;
                if (entrada == "n") return false;

                Console.WriteLine("Responda apenas com s ou n!");
            }
        }
    }
}
