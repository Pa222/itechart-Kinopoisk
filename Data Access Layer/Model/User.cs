namespace Data_Access_Layer.Model
{
    public class User
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}