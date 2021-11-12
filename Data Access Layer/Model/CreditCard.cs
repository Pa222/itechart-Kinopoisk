namespace Data_Access_Layer.Model
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string CardHolderName { get; set; }
        public string Expiry { get; set; }
        public string Cvc { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
    }
}