using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Models;

namespace DataAccess
{
    public partial class MecourselaContext : DbContext
    {
        public MecourselaContext()
        {
        }

        public MecourselaContext(DbContextOptions<MecourselaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Analytic> Analytics { get; set; } = null!;
        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Diet> Diets { get; set; } = null!;
        public virtual DbSet<DietGoal> DietGoals { get; set; } = null!;
        public virtual DbSet<DietType> DietTypes { get; set; } = null!;
        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<DishProduct> DishProducts { get; set; } = null!;
        public virtual DbSet<Exercise> Exercises { get; set; } = null!;
        public virtual DbSet<ExerciseGoal> ExerciseGoals { get; set; } = null!;
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Reminder> Reminders { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;
        public virtual DbSet<WaterIntake> WaterIntakes { get; set; } = null!;
        public virtual DbSet<Workout> Workouts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Analytic>(entity =>
            {
                entity.HasKey(e => e.AnalyticsId)
                    .HasName("PK__Analytic__506974C38EF6B003");

                entity.Property(e => e.AnalyticsId).HasColumnName("AnalyticsID");

                entity.Property(e => e.CaloriesBurned).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CaloriesConsumed).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DataDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WaterIntakeLiters).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Analytics)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Analytics__UserI__58D1301D");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<Diet>(entity =>
            {
                entity.Property(e => e.DietId).HasColumnName("DietID");

                entity.Property(e => e.DietGoalId).HasColumnName("DietGoalID");

                entity.Property(e => e.DietTypeId).HasColumnName("DietTypeID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.DietGoal)
                    .WithMany(p => p.Diets)
                    .HasForeignKey(d => d.DietGoalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Diets__DietGoalI__4D5F7D71");

                entity.HasOne(d => d.DietType)
                    .WithMany(p => p.Diets)
                    .HasForeignKey(d => d.DietTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Diets__DietTypeI__4C6B5938");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Diets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Diets__UserID__4B7734FF");
            });

            modelBuilder.Entity<DietGoal>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__DietGoal__737584F6F1CBA029")
                    .IsUnique();

                entity.Property(e => e.DietGoalId).HasColumnName("DietGoalID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<DietType>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__DietType__737584F63731DBAF")
                    .IsUnique();

                entity.Property(e => e.DietTypeId).HasColumnName("DietTypeID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Dishes__737584F690711025")
                    .IsUnique();

                entity.Property(e => e.DishId).HasColumnName("DishID");

                entity.Property(e => e.CaloriesPerPortion).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DishProduct>(entity =>
            {
                entity.Property(e => e.DishProductId).HasColumnName("DishProductID");

                entity.Property(e => e.DishId).HasColumnName("DishID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.QuantityGrams).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.DishProducts)
                    .HasForeignKey(d => d.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DishProdu__DishI__41EDCAC5");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DishProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DishProdu__Produ__42E1EEFE");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Exercise__737584F673F886A9")
                    .IsUnique();

                entity.Property(e => e.ExerciseId).HasColumnName("ExerciseID");

                entity.Property(e => e.CaloriesBurnedPerMinute).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ExerciseGoal>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Exercise__737584F66EB62A59")
                    .IsUnique();

                entity.Property(e => e.ExerciseGoalId).HasColumnName("ExerciseGoalID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.Property(e => e.FavoriteId).HasColumnName("FavoriteID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemType).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Favorites__UserI__395884C4");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Products__737584F6F2927319")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CaloriesPer100g).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CarbsPer100g).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FatsPer100g).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ProteinsPer100g).HasColumnType("decimal(6, 2)");
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.Property(e => e.ReminderId).HasColumnName("ReminderID");

                entity.Property(e => e.ReminderText).HasMaxLength(200);

                entity.Property(e => e.ReminderTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reminders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reminders__UserI__65370702");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.TestDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tests__UserID__5BAD9CC8");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E4B4B4EE00")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534D264D2D8")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasMaxLength(256);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.Property(e => e.UserDetailId).HasColumnName("UserDetailID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.HeightCm).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WeightKg).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserDetai__UserI__367C1819");
            });

            modelBuilder.Entity<WaterIntake>(entity =>
            {
                entity.ToTable("WaterIntake");

                entity.Property(e => e.WaterIntakeId).HasColumnName("WaterIntakeID");

                entity.Property(e => e.AmountLiters).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.IntakeTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WaterIntakes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WaterInta__UserI__5E8A0973");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.Property(e => e.WorkoutId).HasColumnName("WorkoutID");

                entity.Property(e => e.DurationMinutes).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ExerciseId).HasColumnName("ExerciseID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WorkoutTime).HasColumnType("datetime");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workouts__Exerci__625A9A57");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workouts__UserID__6166761E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

