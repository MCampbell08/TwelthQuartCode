using System;
using System.Collections.Generic;
using System.Text;

namespace AnsweringQuestions.Models
{
    public class Location
    {
        public string  Name { get; set; }
        public List<Route> Routes { get; set; }
    }
}
