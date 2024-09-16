namespace Gymotivate.Models
{
    public class TreinoExercicioModel
    {
        public int TreinoExercicioId { get; set; }

        public TreinoDiaSemanaModel TreinoDiaSemana { get; set; }

        public ExercicioModel Exercicio { get; set; }
    }
}
