using ControleJogos.Domain.Resources;
using System;

namespace ControleJogos.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse
    {

        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }

        //Conversão explicita do objeto Jogador para um objeto AlterarJogadorResponse
        public static explicit operator AlterarJogadorResponse(Entities.Jogador entidade)
        {
            return new AlterarJogadorResponse()
            {
                Id = entidade.Id,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Email = entidade.Email.Endereco,
                Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
