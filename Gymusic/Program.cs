using System;
using System.Collections.Generic;
using System.Threading;
using Gy.Menus;

namespace Gy.Modelos
{
    class Program
    {
        private Dictionary<string, Banda> bandasRegistradas = new Dictionary<string, Banda>();
        private Dictionary<int, Menu> opcoes = new Dictionary<int, Menu>
        {
            { 1, new MenuRegistrarBanda() },
            { 2, new MenuRegistrarAlbum() },
            { 3, new MenuMostrarBandasRegistradas() },
            { 4, new MenuAvaliarUmaBanda() },
            { 5, new MenuExibirDetalhes() },
            { -1, new MenuSair() }
        };

        static void Main(string[] args)
        {
            Program programa = new Program();

            // Criar instâncias das classes
            Banda Ira = new Banda("Ira!");
            Banda Beatles = new Banda("The Beatles");

            // Adicionar avaliações à banda Ira
            Ira.AdicionarNota(new Avaliacao(10));
            Ira.AdicionarNota(new Avaliacao(10));
            Ira.AdicionarNota(new Avaliacao(10));

            // Adicionar álbuns à banda Beatles
            Beatles.AdicionarAlbum(new Album("Álbum 1"));
            Beatles.AdicionarAlbum(new Album("Álbum 2"));

            // Adicionar as bandas registradas ao dicionário
            programa.bandasRegistradas.Add(Ira.Nome, Ira);
            programa.bandasRegistradas.Add(Beatles.Nome, Beatles);

            // Exibir o menu
            programa.ExibirOpcoesDoMenu();
        }

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
            Console.WriteLine("Boas vindas ao GY Music");
        }

        void ExibirOpcoesDoMenu()
        {
            ExibirLogo();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
            Console.WriteLine("Digite 3 para mostrar todas as bandas");
            Console.WriteLine("Digite 4 para avaliar uma banda");
            Console.WriteLine("Digite 5 para exibir os detalhes de uma banda");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
            {
                Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
                menuASerExibido.Executar(bandasRegistradas);
                if (opcaoEscolhidaNumerica > 0)
                {
                    ExibirOpcoesDoMenu();
                }
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        }

        public Dictionary<string, Banda> GetBandasRegistradas()
        {
            return bandasRegistradas;
        }
    }
}
