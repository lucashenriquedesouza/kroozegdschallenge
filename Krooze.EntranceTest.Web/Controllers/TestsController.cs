using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Tests.InjectionTests;
using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Krooze.EntranceTest.WriteHere.Tests.WebTests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Krooze.EntranceTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        // GET api/values
        [HttpGet("XML")]
        public ActionResult<CruiseDTO> TranslateXML()
        {
            return new XMLTest().TranslateXML();
        }

        [HttpGet("OtherTaxes/TotalValue={totalValue:decimal}&CabinValue={cabinValue:decimal}&PortCharge={portCharge:decimal}")]
        public decimal? OtherTaxes(decimal totalValue, decimal cabinValue, decimal portCharge)
        {
            return new SimpleLogicTest().GetOtherTaxes(new CruiseDTO() { TotalValue = totalValue, CabinValue = cabinValue, PortCharge = portCharge });
        }

        [HttpGet("IsThereDiscount/CabinValue1={cabinValue1:decimal}&CabinValue2={cabinValue2:decimal}")]
        public bool? IsThereDiscount(decimal cabinValue1, decimal cabinValue2)
        {
            return new SimpleLogicTest().IsThereDiscount(new CruiseDTO()
            {
                PassengerCruise = new List<PassengerCruiseDTO>()
                {
                    new PassengerCruiseDTO()
                        {PassengerCode = "1", Cruise = new CruiseDTO() {CabinValue = cabinValue1}},
                    new PassengerCruiseDTO()
                        {PassengerCode = "2", Cruise = new CruiseDTO() {CabinValue = cabinValue2}},
                },
                CabinValue = cabinValue1 + cabinValue2
            });
        }

        [HttpGet("GetInstallments/FullPrice={fullPrice:decimal}")]
        public int? GetInstallments(decimal fullPrice)
        {
            return new SimpleLogicTest().GetInstallments(fullPrice);
        }

        [HttpGet("GetAllMovies")]
        public object GetAllMovies()
        {
            return new WebTest().GetAllMovies();
        }

        [HttpGet("GetDirector")]
        public object GetDirector()
        {
            return new WebTest().GetDirector();
        }

        [HttpGet("GetCruises/CruiseCode={cruiseCode:int}")]
        public object GetCruises(int cruiseCode)
        {
            return new InjectionTest().GetCruises(new CruiseRequestDTO() { CruiseCompanyCode = cruiseCode });
        }

    }

}
