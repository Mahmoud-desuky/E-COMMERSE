namespace Back.Core.Entities
{
    public class CustomerBasket:BaseEntity
    {
        public CustomerBasket()
        {
            
        }
        public CustomerBasket(int id)
        {
            Id=id;
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public  List<BasketItem> Items { get; set; }=new List<BasketItem>();

    }
}