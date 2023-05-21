using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.PacienteId); // Chave Primária

            builder.Property(x => x.PacienteId).ValueGeneratedOnAdd(); //Gera o id automatico

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(30); // Nome é obrigatório e pode conter no máximo 30 caracteres.

            builder.Property(x => x.SobreNome).IsRequired().HasMaxLength(100); // sobreNome é obrigatório e pode conter no máximo 100 caracteres.

            builder.Property(x => x.Genero).IsRequired().HasMaxLength(30); // Genero é obrigatório e pode conter no máximo 30 caracteres.

            builder.Property(x => x.DataDeNascimento)
                   .IsRequired() 
                   .HasColumnType("date") 
                   .HasDefaultValueSql("GETDATE()"); // Data de Nascimento obrigatoria, definindo no banco como date retornando a data.

            builder.HasIndex(x => x.CPF)
                .IsUnique(); // Define o índice único para o CPF

            builder.HasIndex(x => x.RG).IsUnique(); // RG é unico

            builder.Property(x => x.UF_RG).IsRequired().HasMaxLength(15); ; // UF do RG obrigatório

            builder.Property(x => x.Email).HasMaxLength(100); // Email é opcional e pode conter até 100 caracteres

            builder.Property(x => x.TelefoneFixo).HasMaxLength(15); // Telefone fixo é opcional e pode conter até 15 caracteres

            builder.Property(x => x.CarteirinhaDoConvenio).IsRequired().HasMaxLength(20); // Carteirinha do convênio é obrigatória e pode conter no máximo 20 caracteres.

            builder.Property(x => x.ValidadeDaCarteirinha).IsRequired().HasMaxLength(7); // Validade da carteirinha é obrigatória e pode conter no máximo 7 caracteres (no formato "MM/yyyy").

        }
    }
}
