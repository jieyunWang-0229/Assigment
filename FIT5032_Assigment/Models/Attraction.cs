namespace FIT5032_Assigment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Attraction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Attraction()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int AttractionId { get; set; }

        [Required]
        public string AttractionName { get; set; }

        [Required]
        public string Location { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public string Image { get; set; }

        public int CategoryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual Category Category { get; set; }
    }
}
