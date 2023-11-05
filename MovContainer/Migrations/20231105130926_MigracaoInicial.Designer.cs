﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovContainer.Context;

#nullable disable

namespace MovContainer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231105130926_MigracaoInicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovContainer.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MovContainer.Models.Container", b =>
                {
                    b.Property<int>("ContainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContainerId"));

                    b.Property<int>("CategoriaSelcionada")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("StatusSelecionado")
                        .HasColumnType("int");

                    b.Property<int>("TipoSelecionado")
                        .HasColumnType("int");

                    b.HasKey("ContainerId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("MovContainer.Models.Movimentacao", b =>
                {
                    b.Property<int>("MovimentacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovimentacaoId"));

                    b.Property<int>("ContainerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovimentacaoSelecionada")
                        .HasColumnType("int");

                    b.HasKey("MovimentacaoId");

                    b.HasIndex("ContainerId");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("MovContainer.Models.Container", b =>
                {
                    b.HasOne("MovContainer.Models.Cliente", "Cliente")
                        .WithMany("Containers")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MovContainer.Models.Movimentacao", b =>
                {
                    b.HasOne("MovContainer.Models.Container", "Container")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Container");
                });

            modelBuilder.Entity("MovContainer.Models.Cliente", b =>
                {
                    b.Navigation("Containers");
                });

            modelBuilder.Entity("MovContainer.Models.Container", b =>
                {
                    b.Navigation("Movimentacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
