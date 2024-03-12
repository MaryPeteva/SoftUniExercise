using Microsoft.VisualBasic;
using SeminarHub.Data.Models;
using System.Xml.Linq;

namespace SeminarHub.Models
{
    public class SeminarPartial
    {
        public SeminarPartial(int id, string topic, string lecturer, DateTime dateAndTime, string organizer, CategoryModel category)
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            DateAndTime = dateAndTime;
            Organizer = organizer;
            Category = category;
        }

        /// <summary>
        /// seminar model for partial information
        /// </summary>
        public int Id { get; set; }

        public string Topic { get; set; }

        public string Lecturer { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Organizer { get; set; }

        public CategoryModel Category { get; set; }

    }
}
