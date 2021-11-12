namespace KinopoiskAPI.Dto.CreditCard
{
    public class AddCreditCardDto
    {
        public string Number { get; set; }
        public string Expiration { get; set; }
        public string CardHolder { get; set; }
        public string Cvv { get; set; }
        public string Issuer { get; set; }
    }
}