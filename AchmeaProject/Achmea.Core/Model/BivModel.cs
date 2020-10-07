using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Model
{
    public class BivModel
    {
        public int Id { get; }

        public string Naam { get; }

        public BivModel(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }
    }
}
