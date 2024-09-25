namespace e_commerce.Models
{
    public class Cart
    {
        public int UserId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(int userId, Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id && item.UserId == userId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { UserId = userId, ProductId = product.Id, Product = product, Quantity = quantity });
            }
        }

        public void RemoveItem(int userId, int productId)
        {
            var item = Items.FirstOrDefault(item => item.ProductId == productId && item.UserId == userId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public decimal GetTotal(int userId)
        {
            return Items.Where(item => item.UserId == userId).Sum(item => item.Product.Price * item.Quantity);
        }
    }
}