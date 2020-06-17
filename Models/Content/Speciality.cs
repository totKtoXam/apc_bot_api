using System.Collections.Generic;

namespace apc_bot_api.Models.Content
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Short { get; set; }
        public string SpecialtyNum { get; set; }
        public string SpecialtyName { get; set; }
        public string Price { get; set; }
        public string ClassificName { get; set; }
        public string Languages { get; set; }
        public string StudyType { get; set; }
        public string StudyPeriod { get; set; }
        public string Exam { get; set; }
    }

    public class SpecialityViewModel
    {
        public int Id { get; set; }
        public string Short { get; set; }
        public string Message { get; set; }
    }
}