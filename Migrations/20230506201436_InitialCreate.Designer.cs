﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using url_shortener.Context;

#nullable disable

namespace url_shortener.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230506201436_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("url_shortener.Models.Url", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ShortUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Urls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ShortUrl = "1",
                            TargetUrl = "https://google.com"
                        },
                        new
                        {
                            Id = 2,
                            ShortUrl = "2",
                            TargetUrl = "https://inforce.digital/"
                        },
                        new
                        {
                            Id = 3,
                            ShortUrl = "3",
                            TargetUrl = "https://stackoverflow.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
