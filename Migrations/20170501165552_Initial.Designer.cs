using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OverripeBananas.Models;

namespace OverripeBananas.Migrations
{
    [DbContext(typeof(OverripeBananasContext))]
    [Migration("20170501165552_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OverripeBananas.Models.Show", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.Property<string>("Rating");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.HasKey("ID");

                    b.ToTable("Show");
                });
        }
    }
}
