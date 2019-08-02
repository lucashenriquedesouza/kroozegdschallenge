using System.Collections.Generic;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("OtherTaxes")]
        public decimal? OtherTaxes(CruiseDTO cruise)
        {
            return new SimpleLogicTest().GetOtherTaxes(cruise);
        }

        [HttpPost("IsThereDiscount")]
        public bool? IsThereDiscount(CruiseDTO cruise)
        {
            return new SimpleLogicTest().IsThereDiscount(cruise);
        }

        [HttpGet("GetInstallments/{fullPrice}")]
        public int? GetInstallments(decimal fullPrice)
        {
            return  new SimpleLogicTest().GetInstallments(fullPrice);
        }

    }

}
