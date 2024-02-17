﻿namespace Homies.Models
{
    public class EventDetailsModel
    {
        /// <summary>
        /// event informatio in the view details
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Start { get; set; }
        public string End { get; set; }
        public string CreatedOn { get; set; }
        public string Organiser { get; set; }
        public string Type { get; set; }
    }
}
