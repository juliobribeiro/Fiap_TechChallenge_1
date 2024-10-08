﻿// <auto-generated />
using FIAP._6NETT_GRUPO31.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FIAP._6NETT_GRUPO31.Infra.Data.Migrations
{
    [DbContext(typeof(FIAPContext))]
    [Migration("20241003220140_AlteraçãoNomeTabelaDDD")]
    partial class AlteraçãoNomeTabelaDDD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FIAP._6NETT_GRUPO31.Domain.Entities.Contatos", b =>
                {
                    b.Property<int>("IdContato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContato"));

                    b.Property<int>("DDDRegiaoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdContato");

                    b.HasIndex("DDDRegiaoId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("TAB_CONTATOS", (string)null);
                });

            modelBuilder.Entity("FIAP._6NETT_GRUPO31.Domain.Entities.DDDRegiao", b =>
                {
                    b.Property<int>("IdDDDRegiao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDDDRegiao"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Regiao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdDDDRegiao");

                    b.ToTable("TAB_DDD_REGIAO", (string)null);
                });

            modelBuilder.Entity("FIAP._6NETT_GRUPO31.Domain.Entities.Contatos", b =>
                {
                    b.HasOne("FIAP._6NETT_GRUPO31.Domain.Entities.DDDRegiao", "DDDRegiao")
                        .WithMany("Contatos")
                        .HasForeignKey("DDDRegiaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DDDRegiao");
                });

            modelBuilder.Entity("FIAP._6NETT_GRUPO31.Domain.Entities.DDDRegiao", b =>
                {
                    b.Navigation("Contatos");
                });
#pragma warning restore 612, 618
        }
    }
}
