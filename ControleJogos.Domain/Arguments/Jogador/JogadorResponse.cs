using ControleJogos.Domain.Enum;
using System;

namespace ControleJogos.Domain.Arguments.Jogador
{
    public class JogadorResponse
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; private set; }
        public string Status { get; private set; }

        //Conversão explicita do objeto Jogador para um objeto JogadorResponse
        public static explicit operator JogadorResponse(Entities.Jogador entidade)
        {
            return new JogadorResponse()
            {
                Id = Guid.NewGuid(),
                //Override
                NomeCompleto = entidade.ToString(),
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Email = entidade.Email.Endereco,
                //Status = entidade.Status.ToString()
            };
        }
    }
}
