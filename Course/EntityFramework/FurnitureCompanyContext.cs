using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Course.Models;

#nullable disable

namespace Course.EntityFramework
{
    public partial class FurnitureCompanyContext : DbContext
    {
        public FurnitureCompanyContext()
        {
        }

        public FurnitureCompanyContext(DbContextOptions<FurnitureCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Factory> Factories { get; set; }
        public virtual DbSet<Furniture> Furnitures { get; set; }
        public virtual DbSet<FurnitureParameter> FurnitureParameters { get; set; }
        public virtual DbSet<FurnitureParameterFurniture> FurnitureParameterFurnitures { get; set; }
        public virtual DbSet<FurnitureParameterValue> FurnitureParameterValues { get; set; }
        public virtual DbSet<FurnitureSubtype> FurnitureSubtypes { get; set; }
        public virtual DbSet<FurnitureType> FurnitureTypes { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialColor> MaterialColors { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<MaterialsAtFactory> MaterialsAtFactories { get; set; }
        public virtual DbSet<MaterialsInProduction> MaterialsInProductions { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderedFurniture> OrderedFurnitures { get; set; }
        public virtual DbSet<OrderedFurnitureMaterial> OrderedFurnitureMaterials { get; set; }
        public virtual DbSet<OrderedMaterial> OrderedMaterials { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Production> Productions { get; set; }
        public virtual DbSet<ProductionEmployee> ProductionEmployees { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<SuppliedMaterial> SuppliedMaterials { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<SupplyRealization> SupplyRealizations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=FurnitureCompany;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegionId).HasColumnName("Region_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_City_Region");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.ColorId).HasColumnName("Color_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FactoryId).HasColumnName("Factory_id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("Position_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Factory)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.FactoryId)
                    .HasConstraintName("FK_Employee_Factory");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Employee_Position");
            });

            modelBuilder.Entity<Factory>(entity =>
            {
                entity.ToTable("Factory");

                entity.Property(e => e.FactoryId).HasColumnName("Factory_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Factories)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Factory_City");
            });

            modelBuilder.Entity<Furniture>(entity =>
            {
                entity.ToTable("Furniture");

                entity.Property(e => e.FurnitureId).HasColumnName("Furniture_id");

                entity.Property(e => e.BasePrice).HasColumnType("money");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FurnitureSubtypeId).HasColumnName("FurnitureSubtype_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.FurnitureSubtype)
                    .WithMany(p => p.Furnitures)
                    .HasForeignKey(d => d.FurnitureSubtypeId)
                    .HasConstraintName("FK_Furniture_FurnitureSubtype");
            });

            modelBuilder.Entity<FurnitureParameter>(entity =>
            {
                entity.ToTable("FurnitureParameter");

                entity.Property(e => e.FurnitureParameterId).HasColumnName("FurnitureParameter_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<FurnitureParameterFurniture>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FurnitureParameter_Furniture");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.FurnitureId).HasColumnName("Furniture_id");

                entity.Property(e => e.FurnitureParameterValueId).HasColumnName("FurnitureParameterValue_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Furniture)
                    .WithMany()
                    .HasForeignKey(d => d.FurnitureId)
                    .HasConstraintName("FK_FurnitureParameter_Furniture_Furniture");

                entity.HasOne(d => d.FurnitureParameterValue)
                    .WithMany()
                    .HasForeignKey(d => d.FurnitureParameterValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FurnitureParameter_Furniture_FurnitureParameterValue");
            });

            modelBuilder.Entity<FurnitureParameterValue>(entity =>
            {
                entity.ToTable("FurnitureParameterValue");

                entity.Property(e => e.FurnitureParameterValueId).HasColumnName("FurnitureParameterValue_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.FurnitureParameterId).HasColumnName("FurnitureParameter_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FurnitureParameter)
                    .WithMany(p => p.FurnitureParameterValues)
                    .HasForeignKey(d => d.FurnitureParameterId)
                    .HasConstraintName("FK_FurnitureParameterValue_FurnitureParameter");
            });

            modelBuilder.Entity<FurnitureSubtype>(entity =>
            {
                entity.ToTable("FurnitureSubtype");

                entity.Property(e => e.FurnitureSubtypeId).HasColumnName("FurnitureSubtype_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.FurnitureTypeId).HasColumnName("FurnitureType_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.FurnitureType)
                    .WithMany(p => p.FurnitureSubtypes)
                    .HasForeignKey(d => d.FurnitureTypeId)
                    .HasConstraintName("FK_FurnitureSubtype_FurnitureType");
            });

            modelBuilder.Entity<FurnitureType>(entity =>
            {
                entity.ToTable("FurnitureType");

                entity.Property(e => e.FurnitureTypeId).HasColumnName("FurnitureType_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.MaterialId).HasColumnName("Material_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialType_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.MaterialType)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.MaterialTypeId)
                    .HasConstraintName("FK_Material_MaterialType");
            });

            modelBuilder.Entity<MaterialColor>(entity =>
            {
                entity.ToTable("MaterialColor");

                entity.Property(e => e.MaterialColorId).HasColumnName("MaterialColor_id");

                entity.Property(e => e.ColorId).HasColumnName("Color_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.MaterialId).HasColumnName("Material_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.MaterialColors)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_MaterialColor_Color");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.MaterialColors)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_MaterialColor_Material");
            });

            modelBuilder.Entity<MaterialType>(entity =>
            {
                entity.ToTable("MaterialType");

                entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialType_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<MaterialsAtFactory>(entity =>
            {
                entity.ToTable("MaterialsAtFactory");

                entity.Property(e => e.MaterialsAtFactoryId).HasColumnName("MaterialsAtFactory_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.FactoryId).HasColumnName("Factory_id");

                entity.Property(e => e.MaterialColorId).HasColumnName("MaterialColor_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Factory)
                    .WithMany(p => p.MaterialsAtFactories)
                    .HasForeignKey(d => d.FactoryId)
                    .HasConstraintName("FK_MaterialsAtFactory_Factory");

                entity.HasOne(d => d.MaterialColor)
                    .WithMany(p => p.MaterialsAtFactories)
                    .HasForeignKey(d => d.MaterialColorId)
                    .HasConstraintName("FK_MaterialsAtFactory_MaterialColor");
            });

            modelBuilder.Entity<MaterialsInProduction>(entity =>
            {
                entity.ToTable("MaterialsInProduction");

                entity.Property(e => e.MaterialsInProductionId).HasColumnName("MaterialsInProduction_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.MaterialsAtFactoryId).HasColumnName("MaterialsAtFactory_id");

                entity.Property(e => e.ProductionId).HasColumnName("Production_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.MaterialsAtFactory)
                    .WithMany(p => p.MaterialsInProductions)
                    .HasForeignKey(d => d.MaterialsAtFactoryId)
                    .HasConstraintName("FK_MaterialsInProduction_MaterialsAtFactory");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.MaterialsInProductions)
                    .HasForeignKey(d => d.ProductionId)
                    .HasConstraintName("FK_MaterialsInProduction_Production");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.TotalSum).HasColumnType("money");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Order_Employee");
            });

            modelBuilder.Entity<OrderedFurniture>(entity =>
            {
                entity.ToTable("OrderedFurniture");

                entity.Property(e => e.OrderedFurnitureId).HasColumnName("OrderedFurniture_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.FurnitureId).HasColumnName("Furniture_id");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.SizeSurchase).HasColumnType("money");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Furniture)
                    .WithMany(p => p.OrderedFurnitures)
                    .HasForeignKey(d => d.FurnitureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedFurniture_Furniture");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderedFurnitures)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedFurniture_Order");
            });

            modelBuilder.Entity<OrderedFurnitureMaterial>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.OrderedFurnitureId).HasColumnName("OrderedFurniture_id");

                entity.Property(e => e.OrderedMaterialsId).HasColumnName("OrderedMaterials_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<OrderedMaterial>(entity =>
            {
                entity.HasKey(e => e.OrderedMaterialsId);

                entity.Property(e => e.OrderedMaterialsId).HasColumnName("OrderedMaterials_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.MaterialColorId).HasColumnName("MaterialColor_id");

                entity.Property(e => e.OrderedFurnitureId).HasColumnName("OrderedFurniture_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.MaterialColor)
                    .WithMany(p => p.OrderedMaterials)
                    .HasForeignKey(d => d.MaterialColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedMaterials_MaterialColor");

                entity.HasOne(d => d.OrderedFurniture)
                    .WithMany(p => p.OrderedMaterials)
                    .HasForeignKey(d => d.OrderedFurnitureId)
                    .HasConstraintName("FK_OrderedMaterials_OrderedFurniture");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionId).HasColumnName("Position_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.ToTable("Production");

                entity.Property(e => e.ProductionId).HasColumnName("Production_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.OrderedFurnitureId).HasColumnName("OrderedFurniture_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.OrderedFurniture)
                    .WithMany(p => p.Productions)
                    .HasForeignKey(d => d.OrderedFurnitureId)
                    .HasConstraintName("FK_Production_OrderedFurniture");
            });

            modelBuilder.Entity<ProductionEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Production_Employee");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.ProductionId).HasColumnName("Production_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Production_Employee_Employee");

                entity.HasOne(d => d.Production)
                    .WithMany()
                    .HasForeignKey(d => d.ProductionId)
                    .HasConstraintName("FK_Production_Employee_Production");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.RegionId).HasColumnName("Region_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<SuppliedMaterial>(entity =>
            {
                entity.HasKey(e => e.SuppliedMaterialsId);

                entity.Property(e => e.SuppliedMaterialsId).HasColumnName("SuppliedMaterials_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.MaterialColorId).HasColumnName("MaterialColor_id");

                entity.Property(e => e.SupplierPrice).HasColumnType("money");

                entity.Property(e => e.SupplyId).HasColumnName("Supply_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.MaterialColor)
                    .WithMany(p => p.SuppliedMaterials)
                    .HasForeignKey(d => d.MaterialColorId)
                    .HasConstraintName("FK_SuppliedMaterials_MaterialColor");

                entity.HasOne(d => d.Supply)
                    .WithMany(p => p.SuppliedMaterials)
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK_SuppliedMaterials_Supply");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Supplier_City");
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.ToTable("Supply");

                entity.Property(e => e.SupplyId).HasColumnName("Supply_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_id");

                entity.Property(e => e.TotalSum).HasColumnType("money");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Supply_Employee");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Supply_Supplier");
            });

            modelBuilder.Entity<SupplyRealization>(entity =>
            {
                entity.ToTable("SupplyRealization");

                entity.Property(e => e.SupplyRealizationId).HasColumnName("SupplyRealization_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.MaterialsAtFactoryId).HasColumnName("MaterialsAtFactory_id");

                entity.Property(e => e.SuppliedMaterialsId).HasColumnName("SuppliedMaterials_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SupplyRealizations)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_SupplyRealization_Employee");

                entity.HasOne(d => d.MaterialsAtFactory)
                    .WithMany(p => p.SupplyRealizations)
                    .HasForeignKey(d => d.MaterialsAtFactoryId)
                    .HasConstraintName("FK_SupplyRealization_MaterialsAtFactory");

                entity.HasOne(d => d.SuppliedMaterials)
                    .WithMany(p => p.SupplyRealizations)
                    .HasForeignKey(d => d.SuppliedMaterialsId)
                    .HasConstraintName("FK_SupplyRealization_SuppliedMaterials");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
