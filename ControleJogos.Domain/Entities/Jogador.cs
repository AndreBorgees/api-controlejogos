using ControleJogos.Domain.Enum;
using ControleJogos.Domain.Resources;
using ControleJogos.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace ControleJogos.Domain.Entities
{
    public class Jogador : Notifiable
    {

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            //Gera uma notificação do construtor caso a senha não atender os requisitos
            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 3, 32, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "3", "32"));

            //if (string.IsNullOrEmpty(request.Email))
            //{
            //    throw new Exception("Informe um e-mail");
            //}
            //if (IsEmail(request.Email))
            //{
            //    throw new Exception("Informe um e-mail válido");
            //}
            //if (string.IsNullOrEmpty(request.Senha))
            //{
            //    throw new Exception("Informe uma senha");
            //}
            //if (request.Senha.Length < 6)
            //{
            //    throw new Exception("Digite uma senha de no minimo 6 caracteres");
            //}
        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();
            Status = EnumSituacaoJogador.EmAnalise;

            //Gera uma notificação do construtor caso a senha não atender os requisitos
            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 3, 32, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "3", "32"));

            //if(IsValid())
            //{
            //    //Criptografa a senha
            //}

            //Adicionado as notificações nessa classe que ja foram ciradas em alguma outra classe
            AddNotifications(nome, email);
        }

        public void AlterarJogador(Nome nome, Email email, EnumSituacaoJogador status)
        {
            Nome  = nome;
            Email = email;

            new AddNotifications<Jogador>(this)
                .IfFalse(Status == EnumSituacaoJogador.Ativo, "Só é possível alterar jogador com status ativo.");

            //Adicionado as notificações nessa classe que ja foram ciradas em alguma outra classe
            AddNotifications(nome, email);
        }
         
        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public EnumSituacaoJogador Status { get; private set; }


        public override string ToString()
        {
            return Nome.PrimeiroNome + " " + Nome.UltimoNome;
        }
    }


}
