using Krooze.EntranceTest.WriteHere.Structure.Model;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class XMLTest
    {

        public CruiseDTO TranslateXML()
        {
            //TODO: Take the Cruises.xml file, on the Resources folder, and translate it to the CruisesDTO object,
            //you can do it in any way, including intermediary objects

            XmlSerializer xmlSr = new XmlSerializer(typeof(CruiseDTO));

            CruiseDTO result = (CruiseDTO)xmlSr.Deserialize(new StringReader(Resources.Resources.Cruises.ToString()));

            result
                .PassengerCruise
                .ForEach(pc =>
                {

                    pc.Cruise = new CruiseDTO()
                    {
                        CabinValue = pc.Charge.Where(ch => "CAB".Equals(ch.ChargeType)).FirstOrDefault().GrossAmountBfrDisc,
                        PortCharge = pc.Charge.Where(ch => "PCH".Equals(ch.ChargeType)).FirstOrDefault().GrossAmountBfrDisc
                    };

                    pc.Cruise.TotalValue = pc.Cruise.CabinValue + pc.Cruise.PortCharge;

                });

            return result;

        }

    }

}
