using booksaw.domain.Constants;
using booksaw.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.infrastructure.Data
{
    public class EFContext : DbContext
    {
        private static readonly string connectionString = "server=localhost; port=3306; database=db_booksaw; user=pna; password=123; Persist Security Info=False; Connect Timeout=300";
        public DbSet<Account> Account { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookClone> BookClone { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), null);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.DisplayName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.AccountType).HasDefaultValue(AccountType.Customer);
                entity.Property(e => e.Avatar).HasDefaultValue("https://i.imgur.com/su4KGCT.png");
            });
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.ImportPrice).IsRequired();
                entity.Property(e => e.SoldPrice).IsRequired();
                entity.Property(e => e.ImageUrl).HasDefaultValue("https://i.imgur.com/YJlYDX0.png");
                entity.HasOne(e => e.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(e => e.AuthorId);
                entity.HasOne(d => d.Publisher)
                  .WithMany(p => p.Books)
                  .HasForeignKey(e => e.PublisherId);
            });
            modelBuilder.Entity<BookClone>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BookIndex).IsRequired();
                entity.Property(e => e.ISBN).IsRequired();
                entity.Property(e => e.IsSold).IsRequired();
                entity.Property(e => e.CurrentPage).HasDefaultValue(1);
                entity.HasOne(e => e.Account)
                    .WithOne(p => p.BookClone)
                    .HasForeignKey<Account>(e => e.Id);
                entity.HasOne(e => e.Book)
                    .WithMany(p => p.Clones)
                    .HasForeignKey(e => e.BookId);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
                entity.Property(e => e.TotalPrice).HasDefaultValue(0);
                entity.HasOne(e => e.Account)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(e => e.AccountId);
            });
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.UnitPrice).IsRequired();
                entity.Property(e => e.TotalPrice).IsRequired();
                entity.HasOne(e => e.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(e => e.OrderId);
            });
            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
                entity.Property(e => e.TotalPrice).HasDefaultValue(0);
                entity.HasOne(e => e.Account)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(e => e.AccountId);
            });
            modelBuilder.Entity<ReceiptDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.UnitPrice).IsRequired();
                entity.Property(e => e.TotalPrice).IsRequired();
                entity.HasOne(e => e.Receipt)
                    .WithMany(p => p.ReceiptDetails)
                    .HasForeignKey(e => e.ReceiptId);
            });
        }
    }
}
