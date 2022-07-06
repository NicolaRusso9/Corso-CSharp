using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    internal class FirstClassPassenger
    {
        public int AirMiles { get; set; }
        public override string ToString()
        {
            return $"First Class with {AirMiles:N0} air miles";
        }
    }

    internal class BusinessClassPassenger
    {
        public override string ToString()
        {
            return $"Business Class";
        }
    }

    internal class CoachClassPassenger
    {
        public double CarryOnKG { get; set; }
        public override string ToString()
        {
            return $"Coach Class with {CarryOnKG:N2} Kg carry on";
        }
    }

    internal class _18_PatternMatching
    {
        public void Starter()
        {
            object[] passengers =
            {
                new FirstClassPassenger{ AirMiles = 1_419},
                new FirstClassPassenger{ AirMiles = 16_359},
                new BusinessClassPassenger(),
                new CoachClassPassenger{ CarryOnKG = 25.7},
                new CoachClassPassenger{ CarryOnKG = 0}
            };


            // PATTERN MATCHING C# 9 >
            foreach (object passenger in passengers)
            {

                decimal flightCost = passenger switch
                {
                    FirstClassPassenger p => p.AirMiles switch
                    {
                        > 35_000 => 1500M,
                        > 15_000 => 1750M,
                        _ => 2000M
                    },

                    BusinessClassPassenger => 1000M,
                    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
                    CoachClassPassenger => 650M,
                    _ => 800M
                };
            }

            // C# 8 Syntax
            foreach (object passenger in passengers)
            {
                decimal flightCost = passenger switch
                {
                    FirstClassPassenger p when p.AirMiles > 35_000 => 1500M,
                    FirstClassPassenger p when p.AirMiles > 15_000 => 1750M,
                    FirstClassPassenger => 2000M,
                    BusinessClassPassenger => 1000M,
                    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
                    CoachClassPassenger => 650M,
                    _ => 800M
                };
            }
        }
    }
}
