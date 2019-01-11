namespace EFDbFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Restaurant")]
    public partial class Restaurant
    {
        public int RestaurantId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public decimal MinimumOrder { get; set; }

        public bool IsOpen { get; set; }

        public int DeliveryTime { get; set; }

        public int? CuisineId { get; set; }

        public virtual Cuisine Cuisine { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Name} ({RestaurantId}):" +
                $" Address: {Address}, IsOpen: {IsOpen}, Cuisine: {Cuisine?.Description ?? "Unknown"}");
        }
    }
}
