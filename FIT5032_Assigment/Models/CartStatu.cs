namespace FIT5032_Assigment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartStatu
    {
        [Key]
        public int CartStatusId { get; set; }

        [Column("CartStatu", TypeName = "date")]
        public DateTime CartStatu1 { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
