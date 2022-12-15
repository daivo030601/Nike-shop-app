namespace ShopAPI.Data
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }
        public float CouponCost { get; set; } = 0;
        public List<RecipeItemModel> RecipeItemModels { get; set; }
    }
}
