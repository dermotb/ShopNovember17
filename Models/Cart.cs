namespace Shop.Models
{
    public class Cart
    {
 

        private List<CartItem> trolley;

        public Cart()
        {
            trolley = new List<CartItem>();
        }

        public void AddItem(Item _item)
        {
            CartItem match = trolley.FirstOrDefault(i=>i.Code==_item.Code);
            if (match==null)
            {
                trolley.Add(new CartItem(){Code=_item.Code, Description=_item.Description, Price=_item.Price, Quantity=1});
            }
            else
            {
                match.Quantity++;
            }
        }

        public double CalculateTotalPrice()
        {
            return trolley.Sum(i=>i.Price * i.Quantity);
        }
    }
}