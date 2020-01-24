using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFDbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var restaurantTypeInfo = typeof(Restaurant);



            foreach (var restaurant in GetRestaurants())
            {
                restaurant.Print();
            }
            Console.WriteLine("-------------------");

            using (var db = new RestaurantModel())
            {
                var restaurants = db.Database.SqlQuery<Restaurant>("select * FROM restaurant");
                foreach (var r in restaurants)
                {
                    r.Print();
                }

                //db.Database.ExecuteSqlCommand("SELECT GETDATE()");
            }

            //using (var db = new RestaurantModel())
            //{
            //    var cuisines = db.Cuisines.ToList();
            //    foreach (var cuisine in cuisines)
            //    {
            //        Console.WriteLine(cuisine?.Restaurants?.Count ?? -1);
            //    }
            //}


            foreach (var restaurant in FilterRestaurants(Souvlakia))
            {
                restaurant.Print();
            }
            Console.WriteLine("-------------------");

            foreach (var restaurant in FilterRestaurants(r => Souvlakia(r)))
            {
                restaurant.Print();
            }
            Console.WriteLine("-------------------");

            foreach (var restaurant in FilterRestaurants(r => r.IsOpen))
            {
                restaurant.Print();
            }
            Console.WriteLine("-------------------");

            foreach (var restaurant in FilterRestaurants(r => r.MinimumOrder < 5.0m))
            {
                restaurant.Print();
            }
            Console.WriteLine("-------------------");

            foreach (var restaurant in OrderRestaurants(r => r.MinimumOrder))
            {
                restaurant.Print();
            }
            Console.WriteLine("-------------------");


            Console.WriteLine("Please give the name to search for:");
            var name = Console.ReadLine();

            foreach (var restaurant in FilterRestaurants(r => r.Name.Contains(name)))
            {
                restaurant.Print();
            }

            Console.ReadKey();
        }

        static IEnumerable<Restaurant> GetSouvlakoRestaurants()
        {
            using (var db = new RestaurantModel())
            {
                //return db.Restaurants.Include("Cuisine")
                //    .Where(Souvlakia)
                //    .ToList();

                return db.Restaurants.Include("Cuisine")
                        .Where(restaurant => Souvlakia(restaurant))
                        .ToList();
            }
        }

        static IEnumerable<Restaurant> FilterRestaurants(Func<Restaurant, bool> check)
        {
            using (var db = new RestaurantModel())
            {
                return db.Restaurants.Include("Cuisine")
                        .Where(check)
                        .ToList();
            }
        }

        static bool Souvlakia(Restaurant restaurant)
        {
            return restaurant.Cuisine?.Description == "Σουβλάκι";
        }

        static IEnumerable<Restaurant> OrderRestaurants<T>(Expression<Func<Restaurant, T>> order)
        {
            using (var db = new RestaurantModel())
            {
                return db.Restaurants.Include("Cuisine")
                        .OrderBy(order)
                        .ToList();
            }
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
