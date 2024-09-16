namespace Gymotivate.Helper
{
    public class Question
    {
        public string question { get; set; }
        public List<string> answers { get; set; }
        public int correctAnswer { get; set; }
        public int selectedAnswer { get; set; }
    }
}
