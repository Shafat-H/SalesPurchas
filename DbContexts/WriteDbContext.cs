using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SalePurchase.Models.Write;

namespace SalePurchase.DbContexts
{
    public partial class WriteDbContext : DbContext
    {
        public WriteDbContext()
        {
        }

        public WriteDbContext(DbContextOptions<WriteDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblItem> TblItems { get; set; } = null!;
        public virtual DbSet<TblPartner> TblPartners { get; set; } = null!;
        public virtual DbSet<TblPartnerType> TblPartnerTypes { get; set; } = null!;
        public virtual DbSet<TblPurchase> TblPurchases { get; set; } = null!;
        public virtual DbSet<TblPurchaseDetail> TblPurchaseDetails { get; set; } = null!;
        public virtual DbSet<TblSale> TblSales { get; set; } = null!;
        public virtual DbSet<TblSalesDetail> TblSalesDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SHAFAT\\SQLEXPRESS;Initial Catalog=MPSales;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblItem>(entity =>
            {
                entity.HasKey(e => e.IntItemId);

                entity.ToTable("tblItem");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NumStockQuantity)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("numStockQuantity");

                entity.Property(e => e.StrItemName)
                    .HasMaxLength(100)
                    .HasColumnName("strItemName");
            });

            modelBuilder.Entity<TblPartner>(entity =>
            {
                entity.HasKey(e => e.IntPartnerId);

                entity.ToTable("tblPartner");

                entity.Property(e => e.IntPartnerId).HasColumnName("intPartnerId");

                entity.Property(e => e.IntPartnerTypeId).HasColumnName("intPartnerTypeId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.StrPartnerName)
                    .HasMaxLength(100)
                    .HasColumnName("strPartnerName");
            });

            modelBuilder.Entity<TblPartnerType>(entity =>
            {
                entity.HasKey(e => e.IntPartnerTypeId);

                entity.ToTable("tblPartnerType");

                entity.Property(e => e.IntPartnerTypeId).HasColumnName("intPartnerTypeId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.StrPartnerTypeName)
                    .HasMaxLength(100)
                    .HasColumnName("strPartnerTypeName");
            });

            modelBuilder.Entity<TblPurchase>(entity =>
            {
                entity.HasKey(e => e.IntPurchaseId);

                entity.ToTable("tblPurchase");

                entity.Property(e => e.IntPurchaseId).HasColumnName("intPurchaseId");

                entity.Property(e => e.DtePurchaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dtePurchaseDate");

                entity.Property(e => e.IntSupplierId).HasColumnName("intSupplierId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            modelBuilder.Entity<TblPurchaseDetail>(entity =>
            {
                entity.HasKey(e => e.IntDetailsId);

                entity.ToTable("tblPurchaseDetails");

                entity.Property(e => e.IntDetailsId).HasColumnName("intDetailsId");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.IntPurchaseId).HasColumnName("intPurchaseId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NumItemQuantity)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("numItemQuantity");

                entity.Property(e => e.NumUnitPrice)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("numUnitPrice");
            });

            modelBuilder.Entity<TblSale>(entity =>
            {
                entity.HasKey(e => e.IntSalesId);

                entity.ToTable("tblSales");

                entity.Property(e => e.IntSalesId).HasColumnName("intSalesId");

                entity.Property(e => e.DteSalesDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteSalesDate");

                entity.Property(e => e.IntCustomerId).HasColumnName("intCustomerId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            modelBuilder.Entity<TblSalesDetail>(entity =>
            {
                entity.HasKey(e => e.IntDetailsId);

                entity.ToTable("tblSalesDetails");

                entity.Property(e => e.IntDetailsId).HasColumnName("intDetailsId");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.IntSalesId).HasColumnName("intSalesId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NumItemQuantity)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("numItemQuantity");

                entity.Property(e => e.NumUnitPrice)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("numUnitPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
