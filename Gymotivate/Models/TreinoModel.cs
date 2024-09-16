namespace Gymotivate.Models
{
    public class TreinoModel
    {
        public int TreinoId { get; set; }

        public CadastreModel User { get; set; }

        public string Nome { get; set; }

        public virtual List<TreinoDiaSemanaModel>? TreinoDiaSemana { get; set; }
    }
}
