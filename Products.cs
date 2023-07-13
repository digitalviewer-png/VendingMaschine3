namespace VendingMaschine3
{
    public class Products
    {
        public string Name { get;  set; }
        public int Price { get;  set; }
        public int Count { get;  set; }
        public Products(string name, int price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }
    }
}
