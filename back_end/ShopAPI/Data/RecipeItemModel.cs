namespace ShopAPI.Data
{
    public class RecipeItemModel
    {
        public int RecipeId { get; set; }
        public int Quatity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
    }
}
