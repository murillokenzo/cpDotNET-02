// Murillo Kenzo Loureiro Kacinvazaki - RM566948

using System.Text.Encodings.Web;
using System.Text.Json;

namespace Classes
{
    public class Repositorio
    {
        private const string NomeDoArquivo = "filmes.json";

        private static readonly JsonSerializerOptions Opcoes = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public string Caminho => Path.GetFullPath(NomeDoArquivo);

        public List<Filme> Carregar()
        {
            if (!File.Exists(NomeDoArquivo))
            {
                Console.WriteLine("Arquivo não encontrado. Começando com a lista vazia.");
                return new List<Filme>();
            }

            try
            {
                string json = File.ReadAllText(NomeDoArquivo);

                if (string.IsNullOrWhiteSpace(json))
                {
                    Console.WriteLine("Arquivo vazio. Começando com a lista vazia.");
                    return new List<Filme>();
                }

                List<Filme>? filmes = JsonSerializer.Deserialize<List<Filme>>(json);
                return filmes ?? new List<Filme>();
            }
            catch (JsonException)
            {
                Console.WriteLine("O arquivo JSON está inválido (corrompido)!");
                GuardarCopiaCorrompida();
                Console.WriteLine("Começando com a lista vazia.");
                return new List<Filme>();
            }
            catch (IOException)
            {
                Console.WriteLine("Erro ao ler o arquivo. Ele pode estar aberto em outro programa.");
                Console.WriteLine("Começando com a lista vazia.");
                return new List<Filme>();
            }
        }

        public void Salvar(List<Filme> filmes)
        {
            try
            {
                string json = JsonSerializer.Serialize(filmes, Opcoes);
                File.WriteAllText(NomeDoArquivo, json);
            }
            catch (IOException)
            {
                Console.WriteLine("Erro ao salvar o arquivo. Ele pode estar aberto em outro programa.");
            }
        }

        private void GuardarCopiaCorrompida()
        {
            string copia = NomeDoArquivo + ".corrompido";

            try
            {
                File.Copy(NomeDoArquivo, copia, true);
                Console.WriteLine($"Uma cópia foi guardada em {copia}");
            }
            catch (IOException)
            {
                Console.WriteLine("Não foi possível guardar a cópia do arquivo corrompido.");
            }
        }
    }
}
