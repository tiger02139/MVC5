namespace LanguageFeatures.Models {

    public class Product {
        public int ProductID { get; set; }

        private string _name;
        public string Name {
            get {
                return $"{_name} (Id={ProductID})";
            }
            set {
                _name = value;
            }
        }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }
}
