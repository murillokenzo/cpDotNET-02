// Murillo Kenzo Loureiro Kacinvazaki - RM566948

namespace Classes
{
    public class FilmeTerror : Filme
    {
        public string TipoDeTerror { get; set; } = "";
        public int NivelDeMedo { get; set; }
        public bool PossuiJumpscare { get; set; }

        public FilmeTerror() { }

        public FilmeTerror(
            string nome,
            int dataDeLancamento,
            string diretor,
            int classificacaoIndicativa,
            string genero,
            int duracao,
            string tipoDeTerror,
            int nivelDeMedo,
            bool possuiJumpscare)
            : base(
                nome,
                dataDeLancamento,
                diretor,
                classificacaoIndicativa,
                genero,
                duracao)
        {
            TipoDeTerror = tipoDeTerror;
            NivelDeMedo = nivelDeMedo;
            PossuiJumpscare = possuiJumpscare;
        }

        public override void Apresentar()
        {
            base.Apresentar();

            Console.WriteLine($"Tipo de Terror: {TipoDeTerror}");
            Console.WriteLine($"Nível de Medo do Filme: {NivelDeMedo}");
            Console.WriteLine($"Possui jumpscares no Filme?: {(PossuiJumpscare ? "Sim" : "Não")}");
        }
    }
}
