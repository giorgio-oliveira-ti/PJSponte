﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sponte.Dt.Context;

namespace Sponte.Dt.Migrations
{
    [DbContext(typeof(DContext))]
    partial class DContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sponte.Sdn.Inscricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("InscritoId")
                        .HasColumnType("int");

                    b.Property<int>("LiveId")
                        .HasColumnType("int");

                    b.Property<bool>("StatusPagamento")
                        .HasColumnType("bit");

                    b.Property<decimal>("ValorInscricao")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InscritoId");

                    b.HasIndex("LiveId");

                    b.ToTable("Inscricao");
                });

            modelBuilder.Entity("Sponte.Sdn.Inscrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndInstagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inscrito");
                });

            modelBuilder.Entity("Sponte.Sdn.Instrutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AndInstagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instrutor");
                });

            modelBuilder.Entity("Sponte.Sdn.Live", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataHoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DuracaoMinutos")
                        .HasColumnType("int");

                    b.Property<int>("InstrutorId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorInscricao")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InstrutorId");

                    b.ToTable("Live");
                });

            modelBuilder.Entity("Sponte.Sdn.Inscricao", b =>
                {
                    b.HasOne("Sponte.Sdn.Inscrito", "Inscrito")
                        .WithMany("Inscricao")
                        .HasForeignKey("InscritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sponte.Sdn.Live", "Live")
                        .WithMany("Inscricao")
                        .HasForeignKey("LiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inscrito");

                    b.Navigation("Live");
                });

            modelBuilder.Entity("Sponte.Sdn.Live", b =>
                {
                    b.HasOne("Sponte.Sdn.Instrutor", "Instrutor")
                        .WithMany("Live")
                        .HasForeignKey("InstrutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instrutor");
                });

            modelBuilder.Entity("Sponte.Sdn.Inscrito", b =>
                {
                    b.Navigation("Inscricao");
                });

            modelBuilder.Entity("Sponte.Sdn.Instrutor", b =>
                {
                    b.Navigation("Live");
                });

            modelBuilder.Entity("Sponte.Sdn.Live", b =>
                {
                    b.Navigation("Inscricao");
                });
#pragma warning restore 612, 618
        }
    }
}
