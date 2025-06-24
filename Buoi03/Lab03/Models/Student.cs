using System.ComponentModel.DataAnnotations;

namespace Lab03.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
        [Range(0, 10, ErrorMessage = "Điểm từ 0 .. 10")]
        public double Score { get; set; }
        public string Grade
        {
            get
            {
                if (Score >= 8.5) return "A";
                if (Score >= 7) return "B";
                if (Score >= 5.5) return "C";
                if (Score >= 4) return "D";
                return "F";
            }
        }
    }
}
