using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OverripeBananas.Models;

namespace OverripeBananas.Migrations
{
    [DbContext(typeof(OverripeBananasContext))]
    [Migration("20170501173309_Episodes")]
    partial class Episodes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OverripeBananas.Models.Episodes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BestCharacter")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("EpisodeName")
                        .IsRequired();

                    b.Property<int>("EpisodeNumber");

                    b.Property<int>("HumorRating");

                    b.Property<int>("OverallGrade");

                    b.Property<int>("Season");

                    b.Property<string>("ShowName")
                        .IsRequired();

                    b.Property<int>("StoryRating");

                    b.HasKey("ID");

                    b.ToTable("Episodes");
                });

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
