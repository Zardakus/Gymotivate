namespace Gymotivate.Models
{
    public class NameConquistasModel
    {
        public int NameConquistasId { get; set; }
        public string Name { get; set; }
        public int ConquistaExp { get; set; }
        public int Tier { get; set; }
        public GrupoConquistasModel GrupoConquistas { get; set; }
        public virtual List<ConquistasModel> Conquistas { get; set; }
    }
}
