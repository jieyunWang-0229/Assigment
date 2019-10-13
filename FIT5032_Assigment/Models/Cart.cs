namespace FIT5032_Assigment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        public int TicketId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CartStatusId { get; set; }

        public int CustomersId { get; set; }

        public virtual CartStatu CartStatu { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
