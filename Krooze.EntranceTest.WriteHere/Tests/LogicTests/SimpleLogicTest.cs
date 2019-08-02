using Krooze.EntranceTest.WriteHere.Structure.Model;
using System.Linq;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class SimpleLogicTest
    {
        public decimal? GetOtherTaxes(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, gets if there is some other tax that not the port charge
            return cruise.TotalValue - cruise.CabinValue - cruise.PortCharge;
        }

        public bool? IsThereDiscount(CruiseDTO cruise)
        {
            if (cruise.PassengerCruise.Count < 2)
                return false;

            //TODO: Based on the CruisesDTO object, check if the second passenger has some kind of discount, based on the first passenger price
            //Assume there are always 2 passengers on the list
            return cruise.PassengerCruise[0].Cruise.CabinValue > cruise.PassengerCruise[1].Cruise.CabinValue;
        }

        public int? GetInstallments(decimal fullPrice)
        {
            //TODO: Based on the full price, find the max number of installments
            // -The absolute max number is 12
            // -The minimum value of the installment is 200

            int fullInsts = int.Parse(System.Math.Round(fullPrice / 200).ToString());

            return fullInsts > 12 ? 12 : fullInsts;
        }
    }
}
