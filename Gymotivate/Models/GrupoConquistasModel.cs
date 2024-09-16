namespace Gymotivate.Models
{
    public class GrupoConquistasModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int GroupExpTotal { get; set; }
        public virtual List<NameConquistasModel> ConquistasName { get; set; }
    }
}
