﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TableauWeb.Data;

namespace TableauWeb.Migrations
{
    [DbContext(typeof(TableauxContext))]
    [Migration("20200216204023_AjoutIdentity2")]
    partial class AjoutIdentity2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Dimension", b =>
                {
                    b.Property<int>("DimensionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstActif")
                        .HasColumnType("bit");

                    b.Property<int>("Hauteur")
                        .HasColumnType("int");

                    b.Property<int>("Largeur")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DimensionId");

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("Model.Finition", b =>
                {
                    b.Property<int>("FinitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstActif")
                        .HasColumnType("bit");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FinitionId");

                    b.ToTable("Finitions");
                });

            modelBuilder.Entity("Model.ImageTableau", b =>
                {
                    b.Property<int>("ImageTableauId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstActif")
                        .HasColumnType("bit");

                    b.Property<int>("MaxImpression")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomBase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageTableauId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Model.Tableau", b =>
                {
                    b.Property<int>("TableauId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DimensionId")
                        .HasColumnType("int");

                    b.Property<int>("FinitionId")
                        .HasColumnType("int");

                    b.Property<int>("ImageTableauId")
                        .HasColumnType("int");

                    b.Property<string>("NomPdf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreImpression")
                        .HasColumnType("int");

                    b.HasKey("TableauId");

                    b.HasIndex("DimensionId");

                    b.HasIndex("FinitionId");

                    b.HasIndex("ImageTableauId");

                    b.ToTable("Tableaux");
                });

            modelBuilder.Entity("Model.Tableau", b =>
                {
                    b.HasOne("Model.Dimension", "Dimension")
                        .WithMany("Tableaux")
                        .HasForeignKey("DimensionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Finition", "Finition")
                        .WithMany("Tableaux")
                        .HasForeignKey("FinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.ImageTableau", "Image")
                        .WithMany("Tableaux")
                        .HasForeignKey("ImageTableauId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
