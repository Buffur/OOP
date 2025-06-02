using System.Text.RegularExpressions;

namespace Lab32.Models
{
    public class Student : Person
    {
        public string? StudentNumber { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}