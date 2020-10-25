using Domain.Entity;

namespace Application.Model
{
    public class ProductsModelOutPut
    {
        public int code { get; set; }
        public string Status { get; set; }
        public string Imported_t { get; set; }
        public string url { get; set; }
        public string creator { get; set; }
        public int created_t { get; set; }
        public int last_modified_t { get; set; }
        public string product_name { get; set; }
        public string generic_name { get; set; }
        public double quantity { get; set; }
        public string brands { get; set; }
        public string categories { get; set; }
        public string labels { get; set; }
        public string cities { get; set; }
        public string purchase_places { get; set; }
        public string stores { get; set; }
        public string ingredients_text { get; set; }
        public string traces { get; set; }
        public string serving_size { get; set; }
        public double serving_quantity { get; set; }
        public int nutriscore_score { get; set; }
        public string nutriscore_grade { get; set; }
        public string main_category { get; set; }
        public Image image { get; set; }
    }
}
