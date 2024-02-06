using System.Diagnostics;
using Gy.Modelos;
using OpenAI_API;


namespace Gy.Menus;

internal class MenuRegistrarBanda : Menu
{
      public override void Executar(Dictionary<string, Banda> bandasRegistradas)
      {

            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!;
            Banda banda = new Banda(nomeDaBanda);
            bandasRegistradas.Add(nomeDaBanda, banda);


            var client = new OpenAIAPI("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");
            
            var chat = client.Chat.CreateConversation();
            chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em um 1 paragrafo");

            string resposta =  chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
            banda.Resumo = resposta;

            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
             Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }

}