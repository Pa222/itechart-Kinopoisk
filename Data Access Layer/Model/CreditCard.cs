namespace Data_Access_Layer.Model
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}