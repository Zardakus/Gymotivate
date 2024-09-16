﻿// <auto-generated />
using Gymotivate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gymotivate.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20231012193319_AdicionarColunaTierTabelaName")]
    partial class AdicionarColunaTierTabelaName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gymotivate.Models.CadastreModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cadastre");
                });

            modelBuilder.Entity("Gymotivate.Models.ConquistasModel", b =>
                {
                    b.Property<int>("ConquistasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConquistasId"));

                    b.Property<int>("NameConquistasId")
                        .HasColumnType("int");

                    b.Property<bool>("PossuiConquista")
                        .HasColumnType("bit");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ConquistasId");

                    b.HasIndex("NameConquistasId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Conquistas");
                });

            modelBuilder.Entity("Gymotivate.Models.GamesModel", b =>
                {
                    b.Property<int>("GamesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GamesId"));

                    b.Property<int>("AcertosBracos")
                        .HasColumnType("int");

                    b.Property<int>("AcertosCostas")
                        .HasColumnType("int");

                    b.Property<int>("AcertosPeitos")
                        .HasColumnType("int");

                    b.Property<int>("AcertosPernas")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("GamesId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Acertos");
                });

            modelBuilder.Entity("Gymotivate.Models.GrupoConquistasModel", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<int>("GroupExpTotal")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("GrupoConquistas");
                });

            modelBuilder.Entity("Gymotivate.Models.NameConquistasModel", b =>
                {
                    b.Property<int>("NameConquistasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NameConquistasId"));

                    b.Property<int>("ConquistaExp")
                        .HasColumnType("int");

                    b.Property<int>("GrupoConquistasGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NameConquistasId");

                    b.HasIndex("GrupoConquistasGroupId");

                    b.ToTable("NameConquistas");
                });

            modelBuilder.Entity("Gymotivate.Models.ConquistasModel", b =>
                {
                    b.HasOne("Gymotivate.Models.NameConquistasModel", "NameConquistas")
                        .WithMany("Conquistas")
                        .HasForeignKey("NameConquistasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymotivate.Models.CadastreModel", "Usuario")
                        .WithMany("Conquistas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NameConquistas");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Gymotivate.Models.GamesModel", b =>
                {
                    b.HasOne("Gymotivate.Models.CadastreModel", "Usuario")
                        .WithMany("Games")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Gymotivate.Models.NameConquistasModel", b =>
                {
                    b.HasOne("Gymotivate.Models.GrupoConquistasModel", "GrupoConquistas")
                        .WithMany("ConquistasName")
                        .HasForeignKey("GrupoConquistasGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoConquistas");
                });

            modelBuilder.Entity("Gymotivate.Models.CadastreModel", b =>
                {
                    b.Navigation("Conquistas");

                    b.Navigation("Games");
                });

            modelBuilder.Entity("Gymotivate.Models.GrupoConquistasModel", b =>
                {
                    b.Navigation("ConquistasName");
                });

            modelBuilder.Entity("Gymotivate.Models.NameConquistasModel", b =>
                {
                    b.Navigation("Conquistas");
                });
#pragma warning restore 612, 618
        }
    }
}
