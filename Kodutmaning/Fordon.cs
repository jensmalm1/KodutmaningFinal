using System;
using System.Text.RegularExpressions;

namespace Kodutmaning
{
    public class Fordon

    {
        public FordonsTyp FordonsTyp { get; set; }
        public double Vikt { get; set; }
        public DateTime TidVidTullen { get; set; }
        public bool MiljöKlassad { get; set; }

    }
}
