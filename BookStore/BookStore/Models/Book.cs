using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
namespace BookStore.Models
{
    public class Book
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("Name")]
        [Required]
        public string Name { get; set; }
        
        [BsonElement("Img")]
        
        public string Img { get; set; }

        [BsonElement("Description")]
        
        public string Description { get; set; }
        [BsonElement("Price")]
        [Required]
        public float Price { get; set; }
        [BsonElement("ISBN")]
        [Required]
        public int ISBN { get; set; }
        [BsonElement("Author")]
        [Required]
        public string Author { get; set; }

        [BsonElement("Year_of_publication")]
        

        public int  Year_of_publication { get; set; }

        [BsonElement("Publishing")]
        public string Publishing { get; set; }




    }
}