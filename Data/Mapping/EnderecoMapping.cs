using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.EnderecoId); // Chave primária

            builder.Property(x => x.EnderecoId).ValueGeneratedOnAdd(); //Gera o id automatico
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Complemento).IsRequired(false).HasMaxLength(70);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Cep).IsRequired().HasMaxLength(9);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(70);
            builder.Property(x => x.UF).IsRequired().HasMaxLength(2);

            
        }
    }
}
