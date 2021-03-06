// <auto-generated />
using HotDrinksMachine.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotDrinksMachine.Server.Migrations
{
    [DbContext(typeof(HotDrinksMachineDbContext))]
    [Migration("20211206015705_AddDrinksAndPreparationActionsTables")]
    partial class AddDrinksAndPreparationActionsTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotDrinksMachine.Shared.Entities.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("HotDrinksMachine.Shared.Entities.DrinkPreparationAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionOrder")
                        .HasColumnType("int");

                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<int>("PreparationActionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrinkId");

                    b.HasIndex("PreparationActionId");

                    b.ToTable("DrinkPreparationActions");
                });

            modelBuilder.Entity("HotDrinksMachine.Shared.Entities.PreparationAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PreparationActions");
                });

            modelBuilder.Entity("HotDrinksMachine.Shared.Entities.DrinkPreparationAction", b =>
                {
                    b.HasOne("HotDrinksMachine.Shared.Entities.Drink", "Drink")
                        .WithMany("DrinkPreparationActions")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotDrinksMachine.Shared.Entities.PreparationAction", "PreparationAction")
                        .WithMany()
                        .HasForeignKey("PreparationActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("PreparationAction");
                });

            modelBuilder.Entity("HotDrinksMachine.Shared.Entities.Drink", b =>
                {
                    b.Navigation("DrinkPreparationActions");
                });
#pragma warning restore 612, 618
        }
    }
}
