using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.FuncionarioId); // Chave primária

            builder.Property(x => x.FuncionarioId).ValueGeneratedOnAdd(); //Gera o id automatico
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(30);
            builder.Property(x => x.SobreNome).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Idade).IsRequired().HasMaxLength(2);

            builder.HasMany(x => x.Endereco).WithOne(x => x.Funcionario).HasForeignKey(x => x.FuncionarioId);
        }
    }
}
