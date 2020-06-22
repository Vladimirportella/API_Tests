using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class DependenteMapping : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.ToTable("DEPENDENTE");

            builder.HasKey(d => d.IdDependente);

            builder.Property(d => d.IdDependente)
                   .HasColumnName("IDDEPENDENTE");

            builder.Property(d => d.Nome)
                   .HasColumnName("NOME")
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(d => d.Sexo)
                 .HasColumnName("SEXO")
                 .HasMaxLength(1)
                 .IsRequired();

            builder.Property(d => d.DataNascimento)
                   .HasColumnName("DATANASCIMENTO")
                   .IsRequired();

            builder.Property(d => d.IdCliente)
                   .HasColumnName("IDCLIENTE")
                   .IsRequired();

            builder.HasOne(d => d.Cliente).WithMany(c => c.Dependentes);

        }
    }
}
