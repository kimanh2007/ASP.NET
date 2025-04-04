using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DangNuKimAnh_2122110482_b2.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        // Một Category có nhiều Product
        public List<Product> Products { get; set; }
    }
}
