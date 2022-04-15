﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Web;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(TripTalkContext))]
    [Migration("20220415005314_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Web.Data.DbModels.ArticleDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AssetLink")
                        .HasColumnType("text")
                        .HasColumnName("asset_link");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text")
                        .HasColumnName("short_description");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("upload_date");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_article");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_article_user_id");

                    b.ToTable("article", (string)null);
                });

            modelBuilder.Entity("Web.Data.DbModels.CommentDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("integer")
                        .HasColumnName("article_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_comment");

                    b.HasIndex("ArticleId")
                        .HasDatabaseName("ix_comment_article_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_comment_user_id");

                    b.ToTable("comment", (string)null);
                });

            modelBuilder.Entity("Web.Data.DbModels.RateDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("integer")
                        .HasColumnName("article_id");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_rate");

                    b.HasIndex("ArticleId")
                        .HasDatabaseName("ix_rate_article_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_rate_user_id");

                    b.ToTable("rate", (string)null);
                });

            modelBuilder.Entity("Web.Data.DbModels.TagDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("integer")
                        .HasColumnName("article_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_tag");

                    b.HasIndex("ArticleId")
                        .HasDatabaseName("ix_tag_article_id");

                    b.ToTable("tag", (string)null);
                });

            modelBuilder.Entity("Web.Data.DbModels.UserDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarLink")
                        .HasColumnType("text")
                        .HasColumnName("avatar_link");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nickname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registration_date");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Web.Data.DbModels.ArticleDbModel", b =>
                {
                    b.HasOne("Web.Data.DbModels.UserDbModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_article_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web.Data.DbModels.CommentDbModel", b =>
                {
                    b.HasOne("Web.Data.DbModels.ArticleDbModel", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_article_id");

                    b.HasOne("Web.Data.DbModels.UserDbModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_user_id");

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web.Data.DbModels.RateDbModel", b =>
                {
                    b.HasOne("Web.Data.DbModels.ArticleDbModel", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_article_id");

                    b.HasOne("Web.Data.DbModels.UserDbModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_user_id");

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web.Data.DbModels.TagDbModel", b =>
                {
                    b.HasOne("Web.Data.DbModels.ArticleDbModel", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_article_id");

                    b.Navigation("Article");
                });
#pragma warning restore 612, 618
        }
    }
}
