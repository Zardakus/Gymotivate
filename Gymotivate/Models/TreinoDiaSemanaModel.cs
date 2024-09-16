namespace Gymotivate.Models
{
    public class TreinoDiaSemanaModel
    {
        public int TreinoDiaSemanaId { get; set; }

        public TreinoModel Treino { get; set; }

        public virtual List<TreinoExercicioModel>? TreinoExercicio { get; set; }

        public string DiaSemana { get; set; }
    }
}
