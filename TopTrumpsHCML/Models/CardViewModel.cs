using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTrumpsHCML.Models
{
    public class CardViewModel
    {
        public string Credits { get; set; }
        public string Ratings { get; set; }
        public string Speed { get; set; }
        public string Films { get; set; }
        public string Crew { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Pilot { get; set; } //we will only retrive one pilot 

        public CardViewModel()
        {

        }
    }
}