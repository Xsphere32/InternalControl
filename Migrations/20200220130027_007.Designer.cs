﻿// <auto-generated />
using System;
using InternalControl.Core.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InternalControl.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200220130027_007")]
    partial class _007
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InternalControl.Core.Models.AnswersModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Answer")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnswersModel");
                });

            modelBuilder.Entity("InternalControl.Core.Models.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeOfFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfFormId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("InternalControl.Core.Models.FormQuestion", b =>
                {
                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("AnswersId")
                        .HasColumnType("int");

                    b.HasKey("FormId", "QuestionId");

                    b.HasIndex("AnswersId");

                    b.HasIndex("QuestionId");

                    b.ToTable("FormQuestions");
                });

            modelBuilder.Entity("InternalControl.Core.Models.GroupOfIndicatorsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeOfFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfFormId");

                    b.ToTable("GroupOfIndicators");
                });

            modelBuilder.Entity("InternalControl.Core.Models.IndicatorsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupOfIndicatorsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeOfFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupOfIndicatorsId");

                    b.HasIndex("TypeOfFormId");

                    b.ToTable("Indicators");
                });

            modelBuilder.Entity("InternalControl.Core.Models.QuestionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupOfIndicatorsId")
                        .HasColumnType("int");

                    b.Property<int?>("IndicatorsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("GroupOfIndicatorsId");

                    b.HasIndex("IndicatorsId");

                    b.HasIndex("TypeOfFormId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("InternalControl.Core.Models.TypeOfForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfForm");
                });

            modelBuilder.Entity("InternalControl.Core.Models.Form", b =>
                {
                    b.HasOne("InternalControl.Core.Models.TypeOfForm", "TypeOfForm")
                        .WithMany()
                        .HasForeignKey("TypeOfFormId");
                });

            modelBuilder.Entity("InternalControl.Core.Models.FormQuestion", b =>
                {
                    b.HasOne("InternalControl.Core.Models.AnswersModel", "Answers")
                        .WithMany()
                        .HasForeignKey("AnswersId");

                    b.HasOne("InternalControl.Core.Models.Form", "Form")
                        .WithMany("FormQuestions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternalControl.Core.Models.QuestionModel", "Question")
                        .WithMany("FormQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InternalControl.Core.Models.GroupOfIndicatorsModel", b =>
                {
                    b.HasOne("InternalControl.Core.Models.TypeOfForm", "TypeOfForm")
                        .WithMany()
                        .HasForeignKey("TypeOfFormId");
                });

            modelBuilder.Entity("InternalControl.Core.Models.IndicatorsModel", b =>
                {
                    b.HasOne("InternalControl.Core.Models.GroupOfIndicatorsModel", "GroupOfIndicators")
                        .WithMany()
                        .HasForeignKey("GroupOfIndicatorsId");

                    b.HasOne("InternalControl.Core.Models.TypeOfForm", "TypeOfForm")
                        .WithMany()
                        .HasForeignKey("TypeOfFormId");
                });

            modelBuilder.Entity("InternalControl.Core.Models.QuestionModel", b =>
                {
                    b.HasOne("InternalControl.Core.Models.AnswersModel", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId");

                    b.HasOne("InternalControl.Core.Models.GroupOfIndicatorsModel", "GroupOfIndicators")
                        .WithMany()
                        .HasForeignKey("GroupOfIndicatorsId");

                    b.HasOne("InternalControl.Core.Models.IndicatorsModel", "Indicators")
                        .WithMany()
                        .HasForeignKey("IndicatorsId");

                    b.HasOne("InternalControl.Core.Models.TypeOfForm", "TypeOfForm")
                        .WithMany("Questions")
                        .HasForeignKey("TypeOfFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
