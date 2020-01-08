using ControleJogos.Domain.Interface.Arguments;
using ControleJogos.Domain.Resources;
using System;

namespace ControleJogos.Domain.Arguments.Jogador
{
    public class AdicionarJogadorResponse: IResponse
    {
        public Guid Id { get; set; }
        public string Mensagem { get; set; }

        //Conversão explicita do objeto Jogador para um objeto AdicionarJogadorResponse
        public static explicit operator AdicionarJogadorResponse(Entities.Jogador entidade)
        {
            return new AdicionarJogadorResponse()
            {
                Id = Guid.NewGuid(),
                Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO

            };
        }
    }
}
