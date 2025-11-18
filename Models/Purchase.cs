namespace WebApplication10_Nov10.Models
{
    public class Purchase
    {
        //annotations/attributes such as Key, Min, Max, Range
        public int PurchaseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set;}

    }
}
