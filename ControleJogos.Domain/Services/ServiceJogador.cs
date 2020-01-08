using ControleJogos.Domain.Arguments.Jogador;
using ControleJogos.Domain.Entities;
using ControleJogos.Domain.Interface.Repositories;
using ControleJogos.Domain.Interface.Services;
using ControleJogos.Domain.Resources;
using ControleJogos.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleJogos.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {

        }
        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            Jogador jogador = new Jogador(nome, email, request.Senha);

            if (IsInvalid()) { return null; }

            jogador = _repositoryJogador.AdicionarJogador(jogador);

            //Gerado uma conversão explicita
            return (AdicionarJogadorResponse)jogador;
        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
            {
                //Gera uma notificação do metodo caso o valor do request for nulo
                AddNotification("AlterarJogadorResponse", Message.X0_E_OBRIGATORIO.ToFormat("AlterarJogadorResponse"));
            }

            Jogador jogador = _repositoryJogador.ObterJogadorPorId(request.Id);

            if(jogador == null)
            {
                AddNotification("Id", Message.DADOS_NÃO_ENCONTRADOS);
                return null;
            }

            var email = new Email(request.Email);
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);

            jogador.AlterarJogador(nome, email, jogador.Status);

            //Adicionado as notificações nessa classe que já foram criadas em alguma outra classe
            AddNotifications(jogador);

            if (IsInvalid())
            {
                return null;
            }

            _repositoryJogador.AlterarJogador(jogador);

            //Gerado uma conversão explicita
            return (AlterarJogadorResponse)jogador;
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                //Gera uma notificação do metodo caso o valor do request for nulo
                //AddNotification("AutenticarJogadorRequest", string.Format(Message.X0_E_OBRIGATORIO, "AutenticarJogadorRequest"));
                AddNotification("AutenticarJogadorRequest", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));
            }

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);

            //Adicionado as notificações nessa classe que ja foram criadas em alguma outra classe
            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);

            //Gerado uma conversão explicita
            return (AutenticarJogadorResponse)jogador;

        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {
            //Listando todos os jogadores e gerando uma conversão explicita dos mesmos
            return _repositoryJogador.ListarJogador().ToList().Select(jogador => (JogadorResponse)jogador);
        }
    }
}
