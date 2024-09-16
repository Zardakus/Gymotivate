namespace Gymotivate.Models
{
    public class GamesModel
    {
        public int GamesId { get; set; }
        public int AcertosPeitos { get; set; }
        public int AcertosCostas { get; set; }
        public int AcertosPernas { get; set; }
        public int AcertosBracos { get; set; }
        public CadastreModel Usuario { get; set; }
    }
}
