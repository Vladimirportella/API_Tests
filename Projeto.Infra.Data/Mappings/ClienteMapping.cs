using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.HasKey(c => c.IdCliente);

            builder.Property(c => c.IdCliente)
                   .HasColumnName("IDCLIENTE");
            
            builder.Property(c => c.Nome)
                   .HasColumnName("NOME")
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(c => c.Email)
                   .HasColumnName("EMAIL")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.DataNascimento)
                   .HasColumnName("DATANASCIMENTO")
                   .IsRequired();

            builder.Property(c => c.Cpf)
                   .HasColumnName("CPF")
                   .HasMaxLength(11)
                   .IsRequired();

            builder.Property(c => c.Telefone)
                   .HasColumnName("TELEFONE")
                   .HasMaxLength(25)
                   .IsRequired();

            builder.Property(c => c.DataCadastro)
                   .HasColumnName("DATACADASTRO")
                   .IsRequired();

        }
    }
}
