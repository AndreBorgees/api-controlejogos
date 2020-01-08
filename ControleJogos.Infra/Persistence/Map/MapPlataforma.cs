using ControleJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleJogos.Infra.Persistence.Map
{
    public class MapPlataforma : EntityTypeConfiguration<Plataforma>
    {
        public MapPlataforma()
        {
            //Nome da tabela
            ToTable("Plataforma");

            //Criando as propriedades que serão os campos no banco de dados(Caso não seja colocado essas configurações o Entity criara no padrão dele)
            Property(p => p.Nome).HasMaxLength(50).IsRequired().HasColumnName("Nome");

        }


    }
}
