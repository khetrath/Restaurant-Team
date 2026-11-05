using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }

        public Restaurant(string name, string type, double rating)
        {
            Name = name;
            Type = type;
            Rating = rating;
        }
    }

    class Program
    {
        static List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant("ร้านส้มตำป้าศรี", "อาหารไทย/อีสาน", 4.8),
            new Restaurant("Ramen King", "อาหารญี่ปุ่น", 4.2),
            new Restaurant("Pasta House", "อาหารอิตาเลียน", 4.6)
        };

        static void Main(string[] args)
        {
            Console.WriteLine("=== ระบบจัดการข้อมูลร้านอาหาร (RestaurantApp) ===");
            ShowAllRestaurants();
            AddRestaurant();       // เมธอดของ A
            ShowGoodRating();      // เมธอดของ B
            ShowSummaryRating();   // เมธอดของ C

            Console.WriteLine("\nกดปุ่มใดๆ เพื่อออกจากโปรแกรม...");
            Console.ReadKey();
        }

        static void ShowAllRestaurants()
        {
            Console.WriteLine("\n--- รายชื่อร้านอาหารทั้งหมด ---");
            foreach (var item in restaurants)
            {
                Console.WriteLine($"- {item.Name} | ประเภท: {item.Type} | คะแนน: {item.Rating}/5.0");
            }
        }

        static void AddRestaurant() { }      // A จะมาเขียนตรงนี้
        static void ShowGoodRating() { }     // B จะมาเขียนตรงนี้
        static void ShowSummaryRating()
        {
            Console.WriteLine("\n--- [C] สรุปร้านอาหารคะแนนสูงสุดและต่ำสุด ---");
            if (restaurants.Count == 0)
            {
                Console.WriteLine("⚠️ ไม่มีข้อมูลร้านอาหารในระบบ");
                return;
            }

            var maxRestaurant = restaurants.OrderByDescending(r => r.Rating).First();
            var minRestaurant = restaurants.OrderBy(r => r.Rating).First();

            Console.WriteLine($"🏆 ร้านคะแนนสูงสุด: {maxRestaurant.Name} ({maxRestaurant.Type}) - {maxRestaurant.Rating}/5.0");
            Console.WriteLine($"🔻 ร้านคะแนนต่ำสุด: {minRestaurant.Name} ({minRestaurant.Type}) - {minRestaurant.Rating}/5.0");
        }
    }
}