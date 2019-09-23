using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBookServices.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Required]
        [Range(0, 1000)] // this range gives availablity property, this stops going beyond 0
        public int Availablity { get; set; }
        [Required]
        [DataType(DataType.Currency)] // gives the currency data type
        public double Price { get; set; }
        
        [DisplayFormat(DataFormatString ="{0:MMM DD YYYY}")]
        public DateTime? DateAdded { get; set; }
        
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; } //this will invoke to the Genre class

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM DD YYYY}")]

        public DateTime PublicationDate { get; set; }

        [Required]
        public int Pages { get; set; }
        [Required]
        public string ProductDimensions { get; set; }
    }   

}