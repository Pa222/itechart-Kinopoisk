namespace KinopoiskAPI.Dto.CreditCard
{
    public class AddCreditCardDto
    {
        public string Number { get; set; }
        public string Expiry { get; set; }
        public string CardHolderName { get; set; }
        public string Cvc { get; set; }
        public string Issuer { get; set; }
    }
}