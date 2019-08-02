using System.Collections.Generic;
using System.Xml.Serialization;

namespace Krooze.EntranceTest.WriteHere.Structure.Model
{
    /// <summary>
    /// Cruise Transfer Object
    /// </summary>
    [XmlRoot("Cruises")]
    public class CruiseDTO
    {

        [XmlElement("CruiseId")]
        public string CruiseCode { get; set; }
        /// <summary>
        /// Total Value of the Cruise
        /// </summary>
        [XmlElement("TotalCabinPrice")]
        public decimal TotalValue { get; set; }
        /// <summary>
        /// Total Cabin (CAB) Value
        /// </summary>
        [XmlElement("CabinPrice")]
        public decimal CabinValue { get; set; }
        /// <summary>
        /// Total Port Charge (PCH) Value
        /// </summary>
        [XmlElement("PortChargesAmt")]
        public decimal PortCharge { get; set; }
        /// <summary>
        /// Ship Name
        /// </summary>
        [XmlElement("ShipName")]
        public string ShipName { get; set; }

        [XmlArray("CategoryPriceDetails"), XmlArrayItem("Pax")]
        public List<PassengerCruiseDTO> PassengerCruise { get; set; }

    }

    public class PassengerCruiseDTO
    {

        public CruiseDTO Cruise { get; set; }

        [XmlAttribute("PaxID")]
        public string PassengerCode { get; set; }

        [XmlElement("Charge")]
        public List<ChargeDTO> Charge { get; set; }

    }

    public class ChargeDTO
    {

        [XmlAttribute("ChargeType")]
        public string ChargeType { get; set; }

        public decimal GrossAmountBfrDisc { get; set; }

    }

}
