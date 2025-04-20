using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Renting.Models
{
    public class ItemModelManager
    {
        public static string JSONPATH = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Resources\Res\items_data.json");
        public static string errorMessage = "";

        public static void AddItem(List<ItemModel> items)
        {
            try
            {
                ItemModelManager.GetCategories();
                string content = JsonSerializer.Serialize(items);
                File.WriteAllText(JSONPATH, content);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public static List<ItemModel> GetItems()
        {
            List<ItemModel> items = new List<ItemModel>();
            try
            {
                    var content = File.ReadAllText(JSONPATH);
                    var filecontent = JsonSerializer.Deserialize<List<ItemModel>>(content);
                    items.AddRange(filecontent);
                    return items;

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return items;
            }

        }
        public static List<string> GetCategories()
        {
            HashSet<string> uniqueCategories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            try
            {
                foreach (ItemModel item in ItemModelManager.GetItems())
                {
                    if (!string.IsNullOrWhiteSpace(item.Category))
                        uniqueCategories.Add(item.Category);
                }
                errorMessage = "";
                return uniqueCategories.ToList();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return uniqueCategories.ToList();
            }
        }

        public static void DeleteItem(ItemModel targetItem)
        {
            foreach(ItemModel item in ItemModelManager.GetItems())
            {
                if(item == targetItem)
                {
                    ItemModelManager.GetItems().Remove(item);
                }
            }
        }
    }
}
