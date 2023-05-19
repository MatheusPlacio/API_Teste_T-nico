using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ConvenioMapping : IEntityTypeConfiguration<Convenio>
    {
        public void Configure(EntityTypeBuilder<Convenio> builder)
        {
            builder.HasKey(x => x.ConvenioId); // Chave Primária

            builder.Property(x => x.ConvenioId).ValueGeneratedOnAdd(); //Gera o id automatico

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(30); // Nome é obrigatório e pode conter no máximo 30 caracteres.

            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(250); // Descricao é obrigatório e pode conter no máximo 250 caracteres.

            //Relacionamento 1 : N
            builder.HasMany(x => x.Pacientes)
                   .WithOne(x => x.Convenio)
                   .HasForeignKey(x => x.ConvenioId);
        }
    }
}
