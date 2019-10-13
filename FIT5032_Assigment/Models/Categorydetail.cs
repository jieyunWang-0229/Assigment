using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace FIT5032_Assigment.Models
{
    public class Categorydetail
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name Requird")]
        public string CategoryName { get; set; }


    }

    public class AttractionDetail
    {
       

        public int AttractionId { get; set; }

        [Required(ErrorMessage = "Category Name Requird")]
        [StringLength(50, ErrorMessage = "Minimum 5  and maximum 50charaters are allwed", MinimumLength = 5)]

        public string AttractionName { get; set; }

        [Required]
        public string Location { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public string Image { get; set; }

        public int CategoryId { get; set; }

       
      
        public SelectList Category { get; set; }
    }

}