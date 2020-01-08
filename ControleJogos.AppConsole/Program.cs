using ControleJogos.Domain.Services;
using System;
using System.Linq;

namespace ControleJogos.AppConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Iniciando....");

            var service = new ServiceJogador();
            Console.WriteLine("Criei Instancia do serviço");

            //AutenticarJogadorRequest Autenticarrequest = new AutenticarJogadorRequest();
            //Console.WriteLine("Criei Instancia do meu objeto reequest");
            //Autenticarrequest.Email = "borges@hotmail.com";
            //Autenticarrequest.Senha = "123456";
            //var response = service.AutenticarJogador(Autenticarrequest);

            //var AdicionarRequest = new AdicionarJogadorRequest()
            //{
            //    Email = "borges.andree@gmail.com",
            //    PrimeiroNome = "André",
            //    UltimoNome = "Borges",
            //    Senha = "123456"
            //};
            //var AdicionarResponse = service.AdicionarJogador(AdicionarRequest);

            var result = service.ListarJogador();

            service.Notifications.ToList().ForEach(x =>
                    {
                        Console.WriteLine(x.Message);
                    });

            Console.ReadKey();
        }
    }
}
