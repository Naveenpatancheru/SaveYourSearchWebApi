﻿// <auto-generated />
using System;
using BingWebSearch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BingWebSearch.Migrations
{
    [DbContext(typeof(BingWebSearchContext))]
    [Migration("20200312202210_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BingWebSearch.Entities.Note", b =>
                {
                    b.Property<string>("noteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("bufferColumn");

                    b.Property<DateTime>("createdDate");

                    b.Property<string>("moreInfo");

                    b.Property<string>("noteHeadLine");

                    b.Property<string>("notesInfo");

                    b.HasKey("noteId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("BingWebSearch.Entities.value", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dateLastCrawled");

                    b.Property<string>("displayUrl");

                    b.Property<bool>("isNavigational");

                    b.Property<string>("language");

                    b.Property<string>("name");

                    b.Property<string>("snippet");

                    b.Property<string>("url");

                    b.Property<string>("userid");

                    b.HasKey("id");

                    b.ToTable("SaveUrlInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
