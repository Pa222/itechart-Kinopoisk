namespace Data_Access_Layer.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}