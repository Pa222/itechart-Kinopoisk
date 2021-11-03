namespace Data_Access_Layer.Model
{
    public class GenreMovie
    {
        public int Id { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}