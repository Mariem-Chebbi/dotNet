﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TE.Data;

#nullable disable

namespace TE.Data.Migrations
{
    [DbContext(typeof(TEContext))]
    [Migration("20240105082346_InitMig")]
    partial class InitMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TE.Core.Domain.Candidature", b =>
                {
                    b.Property<int>("ConcoursFk")
                        .HasColumnType("int");

                    b.Property<int>("EnseignantFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDepot")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEntretien")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEpreuve")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dossier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Resultat")
                        .HasColumnType("bit");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.HasKey("ConcoursFk", "EnseignantFk");

                    b.HasIndex("EnseignantFk");

                    b.ToTable("Candidature");
                });

            modelBuilder.Entity("TE.Core.Domain.Concours", b =>
                {
                    b.Property<int>("Promotion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Promotion"));

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("NbrEM")
                        .HasColumnType("int");

                    b.Property<int>("NbrGC")
                        .HasColumnType("int");

                    b.Property<int>("NbrGED")
                        .HasColumnType("int");

                    b.Property<int>("NbrLANGUE")
                        .HasColumnType("int");

                    b.Property<int>("NbrMATH")
                        .HasColumnType("int");

                    b.Property<int>("NbrTIC")
                        .HasColumnType("int");

                    b.HasKey("Promotion");

                    b.ToTable("Concours");
                });

            modelBuilder.Entity("TE.Core.Domain.Enseignant", b =>
                {
                    b.Property<int>("Matricule")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Matricule"));

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("Specialite")
                        .HasColumnType("int");

                    b.Property<string>("UPFK")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Matricule");

                    b.HasIndex("UPFK");

                    b.ToTable("Enseignant");
                });

            modelBuilder.Entity("TE.Core.Domain.UP", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("UP");
                });

            modelBuilder.Entity("TE.Core.Domain.Candidature", b =>
                {
                    b.HasOne("TE.Core.Domain.Concours", "MyConcours")
                        .WithMany("Candidatures")
                        .HasForeignKey("ConcoursFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TE.Core.Domain.Enseignant", "MyEnseignant")
                        .WithMany("Candidatures")
                        .HasForeignKey("EnseignantFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyConcours");

                    b.Navigation("MyEnseignant");
                });

            modelBuilder.Entity("TE.Core.Domain.Enseignant", b =>
                {
                    b.HasOne("TE.Core.Domain.UP", "MyUP")
                        .WithMany("Enseignants")
                        .HasForeignKey("UPFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyUP");
                });

            modelBuilder.Entity("TE.Core.Domain.Concours", b =>
                {
                    b.Navigation("Candidatures");
                });

            modelBuilder.Entity("TE.Core.Domain.Enseignant", b =>
                {
                    b.Navigation("Candidatures");
                });

            modelBuilder.Entity("TE.Core.Domain.UP", b =>
                {
                    b.Navigation("Enseignants");
                });
#pragma warning restore 612, 618
        }
    }
}
