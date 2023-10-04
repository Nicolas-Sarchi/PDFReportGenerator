using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistencia.Data.Configurations;
  public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
  {
     public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Producto");

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Stock)
        .IsRequired()
        .HasColumnType("int");

         builder.Property(p => p.Precio)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.Categoria)
        .WithMany(p => p.Productos)
        .HasForeignKey(p => p.IdCategoriaFk);
        
        builder.HasData(
          new Producto { Id = 1, Nombre = "Teclado", Stock = 10, Precio = 100, IdCategoriaFk = 1 },
          new Producto { Id = 2, Nombre = "Mouse", Stock = 10, Precio = 80, IdCategoriaFk = 1 },
          new Producto { Id = 3, Nombre = "Leche", Stock = 102, Precio = 50, IdCategoriaFk = 2}
        );
  }
  }