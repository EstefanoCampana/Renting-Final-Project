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
        public static List<ItemModel> items = new List<ItemModel>();
        public static List<string> categories = new List<string>();
        public static string errorMessage = "";

        public static void AddItem()
        {
            try
            {
                ItemModelManager.GetItems();
                ItemModelManager.GetCategories();
                string content = JsonSerializer.Serialize(items);
                File.WriteAllText(JSONPATH, content);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public static void GetItems()
        {

            try
            {
                if (File.Exists(JSONPATH) == true)
                {
                    var content = File.ReadAllText(JSONPATH);

                    if (content != null)
                    {
                        var filecontent = JsonSerializer.Deserialize<List<ItemModel>>(content);
                        items.AddRange(filecontent);
                    }

                }
                else
                {
                    File.Create(JSONPATH).Close();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }
        public static void GetCategories()
        {
            try
            {
                ItemModelManager.GetItems();
                foreach (ItemModel item in items)
                {
                    categories.Add(item.Category);
                }
                errorMessage = "";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}