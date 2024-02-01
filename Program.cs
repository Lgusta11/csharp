//gy music
string msgDeBoasVindas = "Bem vindo ao GY Music";
//List<string> ListBd = new List<string> { "mozo", "serio", "zovo"};

Dictionary<string , List<int>> bandassRegistradas = new Dictionary<string , List<int>>();
bandassRegistradas.Add("Vasco", new List<int> { 1, 2, 3 });
bandassRegistradas.Add("neumar", new List<int> { 1, 2, 3 });


void ExibirLogo()
{
    Console.WriteLine(@"


░██████╗░██╗░░░██╗  ███╗░░░███╗██╗░░░██╗░██████╗██╗░█████╗░
██╔════╝░╚██╗░██╔╝  ████╗░████║██║░░░██║██╔════╝██║██╔══██╗
██║░░██╗░░╚████╔╝░  ██╔████╔██║██║░░░██║╚█████╗░██║██║░░╚═╝
██║░░╚██╗░░╚██╔╝░░  ██║╚██╔╝██║██║░░░██║░╚═══██╗██║██║░░██╗
╚██████╔╝░░░██║░░░  ██║░╚═╝░██║╚██████╔╝██████╔╝██║╚█████╔╝
░╚═════╝░░░░╚═╝░░░  ╚═╝░░░░░╚═╝░╚═════╝░╚═════╝░╚═╝░╚════╝░
");
    Console.WriteLine(msgDeBoasVindas);
}

void ExibirOpMenu()
{
    ExibirLogo();
    Console.WriteLine();
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para ver a media de avaliação de uma banda");

    Console.Write("\nDigite sua Opção: ");
    string resposta = Console.ReadLine()!;
    int opNumerica = int.Parse(resposta);
    switch (opNumerica)
    {
        case 1: RegistrarBd(); break;
            case 2: MostrarBd(); break;
            case 3: Avaliar(); break;
        case 4: Media(); break;
        default: Console.WriteLine("Opção INCORRETA selecionada");break;
    };
}

void RegistrarBd()
{
    Console.Clear();
    ExibleTitleOption("Resgistre uma banda");
    Console.Write("Digite o nome da banda: ");
    string NomeBd = Console.ReadLine()!;
    bandassRegistradas.Add(NomeBd, new List<int>());
    Console.WriteLine($"A banda {NomeBd} foi registrada!");
    Thread.Sleep(1000);
    Console.Clear();
    ExibirOpMenu();

};
void MostrarBd() {
    Console.Clear();
    ExibleTitleOption("Exibindo todas as bandas registradas na GY music");
    //for (int i = 0; i < ListBd.Count; i++)
    //{
    //    Console.WriteLine($"\nBanda: {ListBd[i]}");
    //};

    foreach (string banda in bandassRegistradas.Keys)
    {

        Console.WriteLine($"\nBanda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar!");
    Console.ReadKey();
    Console.Clear();
    ExibirOpMenu();

};

void ExibleTitleOption(string Title)
{
    int QuantLetras = Title.Length;
    string asteriscos = string.Empty.PadLeft(QuantLetras);
    Console.WriteLine(asteriscos);
    Console.WriteLine(Title);
    Console.WriteLine(asteriscos + "\n");

}

void Avaliar()
{
    Console.Clear();
    ExibleTitleOption("Avalie A sua banda FAVORITA!");
    Console.Write("Qual banda você quer avaliar?");
    string NomeBd = Console.ReadLine()!;
    if (bandassRegistradas.ContainsKey(NomeBd))
    {
        Console.Write($"\n Qual a nota da banda {NomeBd}? ");
        int nota = int.Parse(Console.ReadLine()!);
        bandassRegistradas[NomeBd].Add(nota);
        Console.WriteLine($"\n A nota {nota} foi atribuida a banda {NomeBd} com sucesso!");
        Thread.Sleep(5000);
        Console.Clear();
        ExibirOpMenu();

    }
    else {
        Console.WriteLine($"\nA banda {NomeBd} não foi encontrada!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpMenu();

    };

};

void Media()
{
    Console.Clear();
    ExibleTitleOption(" Veja a media da sua banda FAVORITA!");
    Console.Write("Qual banda você quer  ver a media? ");
    string NomeBd = Console.ReadLine()!;
    if (bandassRegistradas.ContainsKey(NomeBd)) {
        List<int> NotasBd = bandassRegistradas[NomeBd];
        Console.WriteLine($" A media da Banda {NomeBd} é {NotasBd.Average()}");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpMenu();

    }
    else
    {
        Console.WriteLine($"\nA banda {NomeBd} não foi encontrada!");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpMenu();
    }
};


ExibirOpMenu();