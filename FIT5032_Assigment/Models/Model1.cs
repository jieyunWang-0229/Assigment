namespace FIT5032_Assigment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=AssigmentModels")
        {
        }

        public virtual DbSet<Attraction> Attractions { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartStatu> CartStatus { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attraction>()
                .Property(e => e.Longitude)
                .HasPrecision(38, 0);

            modelBuilder.Entity<Attraction>()
                .Property(e => e.Latitude)
                .HasPrecision(38, 0);

            modelBuilder.Entity<Attraction>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Attraction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CartStatu>()
                .HasOptional(e => e.Cart)
                .WithRequired(e => e.CartStatu);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Attractions)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomersId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomersId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.TicketPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);
        }
    }
}
