namespace FIT5032_Assigment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int TicketId { get; set; }

        [Required]
        public string TicketName { get; set; }

        [Column(TypeName = "date")]
        public DateTime TicketDate { get; set; }

        [Required]
        public string TicketType { get; set; }

        public decimal TicketPrice { get; set; }

        public int TicketTotalQty { get; set; }

        public int AttractionId { get; set; }

        public virtual Attraction Attraction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
