namespace GameDB.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Developers { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
