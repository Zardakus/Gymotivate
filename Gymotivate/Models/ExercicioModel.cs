namespace Gymotivate.Models
{
    public class ExercicioModel
    {
        public int ExercicioId { get; set; }

        public virtual List<TreinoExercicioModel>? TreinoExercicio { get; set; }

        public string Nome { get; set; }

        public int GrupoExercicio { get; set; }
    }
}
