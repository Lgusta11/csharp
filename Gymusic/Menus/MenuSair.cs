using Gy.Modelos;
using System;
using System.Collections.Generic;

namespace Gy.Menus;

internal class MenuSair : Menu
{
        public override void Executar(Dictionary<string, Banda> bandasRegistradas){
        Console.WriteLine("Tchau tchau :)");
}
}