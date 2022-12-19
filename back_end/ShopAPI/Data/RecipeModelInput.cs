namespace ShopAPI.Data
{
    public class RecipeModelInput
    {
        public int UserId { get; set; }
        public int CouponId { get; set; } = 0;
        public List<RecipeItemModelInput> RecipeItemModelInputs { get; set; } = new List<RecipeItemModelInput>();
    }
}
