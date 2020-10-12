using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class BivViewModel
    {
        public int Id { get; }

        public string Naam { get; }

        public BivViewModel(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }

    }
}
