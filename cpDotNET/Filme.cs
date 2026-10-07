// Murillo Kenzo Loureiro Kacinvazaki - RM566948

using System.Text.Json.Serialization;

namespace Classes
{

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "tipo")]
    [JsonDerivedType(typeof(Filme), "filme")]
    [JsonDerivedType(typeof(FilmeTerror), "filmeTerror")]
    public class Filme
    {
        public string Nome { get; set; } = "";
        public int DataDeLancamento { get; set; }
        public string Diretor { get; set; } = "";
        public int ClassificacaoIndicativa { get; set; }
        public string Genero { get; set; } = "";
        public int Duracao { get; set; }
 
        public Filme() { }

        public Filme(
            string nome,
            int dataDeLancamento,
            string diretor,
            int classificacaoIndicativa,
            string genero,
            int duracao)
        {
            Nome = nome;
            DataDeLancamento = dataDeLancamento;
            Diretor = diretor;
            ClassificacaoIndicativa = classificacaoIndicativa;
            Genero = genero;
            Duracao = duracao;
        }

        public virtual void Apresentar()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Data de Lançamento: {DataDeLancamento}");
            Console.WriteLine($"Diretor: {Diretor}");
            Console.WriteLine($"Classificação Indicativa: {ClassificacaoIndicativa}");
            Console.WriteLine($"Gênero: {Genero}");
            Console.WriteLine($"Duração: {Duracao} minutos");
        }
    }
}
