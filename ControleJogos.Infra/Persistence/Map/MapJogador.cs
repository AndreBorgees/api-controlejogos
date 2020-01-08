using ControleJogos.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace ControleJogos.Infra.Persistence.Map
{
    //Mapeando Jogador
    public class MapJogador: EntityTypeConfiguration<Jogador>
    {
        public MapJogador()
        {
            //Nome da tabela
            ToTable("Jogador");

            //Criando as propriedades que serão os campos no banco de dados(Caso não seja colocado essas configurações o Entity criara no padrão dele)
            Property(p => p.Email.Endereco).HasMaxLength(200).IsRequired().HasColumnAnnotation("index", new IndexAnnotation(new IndexAttribute("UK_JOGADOR_EMAIL") { IsUnique = true })).HasColumnName("Email");
            Property(p => p.Nome.PrimeiroNome).HasMaxLength(50).IsRequired().HasColumnName("PrimeiroNome");
            Property(p => p.Nome.UltimoNome).HasMaxLength(50).IsRequired().HasColumnName("UltimoNome");
            Property(p => p.Senha).IsRequired();
            Property(p => p.Status).IsRequired();
        }
    }
}
