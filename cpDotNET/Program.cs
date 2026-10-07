// Murillo Kenzo Loureiro Kacinvazaki - RM566948 2TDSPA

using Classes;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Repositorio repositorio = new Repositorio();

List<Filme> filmes = repositorio.Carregar();

Console.WriteLine($"{filmes.Count} filme(s) carregado(s) do arquivo.");
Console.WriteLine($"Arquivo: {repositorio.Caminho}");

string opcao = "";

while (opcao != "0")
{
    Console.WriteLine();
    Console.WriteLine("===== CADASTRADOR DE FILMES =====");
    Console.WriteLine("1 - Cadastrar");
    Console.WriteLine("2 - Listar");
    Console.WriteLine("3 - Excluir");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Escolha uma opção: ");
    opcao = (Console.ReadLine() ?? "").Trim();

    switch (opcao)
    {
        case "1":
            Cadastrar();
            break;
        case "2":
            Listar();
            break;
        case "3":
            Excluir();
            break;
        case "0":
            Console.WriteLine("Até a próxima!");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}

void Cadastrar()
{
    Console.WriteLine();
    Console.WriteLine("--- Novo cadastro ---");
    Console.WriteLine("1 - Filme comum");
    Console.WriteLine("2 - Filme de terror");
    int tipo = Validacoes.LerInteiroNoIntervalo("Qual o tipo do filme?", 1, 2);

    string nome = Validacoes.LerTextoObrigatorio("Digite o nome do filme: ");
    int dataLancamento = Validacoes.LerInteiro("Digite o ano de lançamento do filme: ");
    string diretor = Validacoes.LerTextoObrigatorio("Digite o diretor do filme: ");
    int idadeIndicativa = Validacoes.LerInteiro("Digite a idade indicativa do filme: ");
    string genero = Validacoes.LerTextoObrigatorio("Digite o gênero do filme: ");
    int duracao = Validacoes.LerInteiro("Digite a duração do filme em minutos: ");

    Filme filme;

    if (tipo == 1)
    {
        filme = new Filme(nome, dataLancamento, diretor, idadeIndicativa, genero, duracao);
    }
    else
    {
        string tipoTerror = Validacoes.LerTextoObrigatorio("Digite o tipo de terror do filme: ");
        int nivelMedo = Validacoes.LerInteiro("Digite o nível de medo do filme: ");
        bool possuiJumpscare = Validacoes.LerSimNao("O filme possui jumpscares? (s/n): ");

        filme = new FilmeTerror(
            nome,
            dataLancamento,
            diretor,
            idadeIndicativa,
            genero,
            duracao,
            tipoTerror,
            nivelMedo,
            possuiJumpscare);
    }

    filmes.Add(filme);
    repositorio.Salvar(filmes); 

    Console.WriteLine("Cadastrado com sucesso!");
}

void Listar()
{
    Console.WriteLine();
    Console.WriteLine("===== LISTA DE FILMES =====");

    foreach (Filme filme in filmes)
    {
        filme.Apresentar();
        Console.WriteLine();
    }

    Console.WriteLine($"Total de filmes cadastrados: {filmes.Count}");
}

void Excluir()
{
    if (filmes.Count == 0)
    {
        Console.WriteLine("Não há filmes para excluir.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("--- Excluir filme ---");

    for (int i = 0; i < filmes.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {filmes[i].Nome}");
    }

    int escolhido = Validacoes.LerInteiroNoIntervalo("Digite o número do filme a excluir: ", 1, filmes.Count);
    Filme filmeEscolhido = filmes[escolhido - 1];

    bool confirmou = Validacoes.LerSimNao($"Tem certeza que deseja excluir \"{filmeEscolhido.Nome}\"? (s/n): ");

    if (confirmou)
    {
        filmes.Remove(filmeEscolhido);
        repositorio.Salvar(filmes); 
        Console.WriteLine("Filme excluído com sucesso!");
    }
    else
    {
        Console.WriteLine("Exclusão cancelada.");
    }
}
