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
    [Migration("20231008152607_AdicionandoPodeSerNullCadastre")]
    partial class AdicionandoPodeSerNullCadastre
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

                    b.Property<int>("ConquistaExp")
                        .HasColumnType("int");

                    b.Property<int>("GrupoConquistasGroupId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ConquistasId");

                    b.HasIndex("GrupoConquistasGroupId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Conquistas");
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

                    b.Property<int>("ConquistasId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NameConquistasId");

                    b.HasIndex("ConquistasId");

                    b.ToTable("NameConquistas");
                });

            modelBuilder.Entity("Gymotivate.Models.ConquistasModel", b =>
                {
                    b.HasOne("Gymotivate.Models.GrupoConquistasModel", "GrupoConquistas")
                        .WithMany("Conquistas")
                        .HasForeignKey("GrupoConquistasGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gymotivate.Models.CadastreModel", "Usuario")
                        .WithMany("Conquistas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoConquistas");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Gymotivate.Models.NameConquistasModel", b =>
                {
                    b.HasOne("Gymotivate.Models.ConquistasModel", "Conquista")
                        .WithMany("ConquistasName")
                        .HasForeignKey("ConquistasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conquista");
                });

            modelBuilder.Entity("Gymotivate.Models.CadastreModel", b =>
                {
                    b.Navigation("Conquistas");
                });

            modelBuilder.Entity("Gymotivate.Models.ConquistasModel", b =>
                {
                    b.Navigation("ConquistasName");
                });

            modelBuilder.Entity("Gymotivate.Models.GrupoConquistasModel", b =>
                {
                    b.Navigation("Conquistas");
                });
#pragma warning restore 612, 618
        }
    }
}
