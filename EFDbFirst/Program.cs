using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var restaurant in GetRestaurants())
            {
                restaurant.Print();
            }

            Console.ReadKey();
        }

       
        static IEnumerable<Restaurant> GetRestaurants()
        {
            using (var db = new RestaurantModel())
            {
                return db.Restaurants.Include("Cuisine").ToList();
            }
        }




    }
}
