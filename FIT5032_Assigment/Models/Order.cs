namespace FIT5032_Assigment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderId { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        public decimal OrderAmount { get; set; }

        public int TicketQty { get; set; }

        public int TicketId { get; set; }

        public int CustomersId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
