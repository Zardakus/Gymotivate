namespace Gymotivate.Models
{
    public class ConquistasModel
    {
        public int ConquistasId { get; set; }
        public CadastreModel Usuario { get; set; }
        public NameConquistasModel NameConquistas { get; set; }
        public bool PossuiConquista { get; set; }
    }
}
