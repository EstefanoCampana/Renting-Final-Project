using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Renting.Models
{
    public class ItemModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public double Cost { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageBase64 { get; set; }
        public string Status { get; set; }
        public ItemModel() { }
        public ItemModel(string id, string title, double cost, string category, string description, string status)
        {
            Id = id;
            Title = title;
            Cost = cost;
            Category = category;
            Description = description;
            Status = status;
        }

    }
}
