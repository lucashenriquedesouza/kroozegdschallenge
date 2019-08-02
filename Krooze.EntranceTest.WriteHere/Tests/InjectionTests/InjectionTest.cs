using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Krooze.EntranceTest.WriteHere.Tests.InjectionTests
{
    public class InjectionTest
    {
        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
            //TODO: This method receives a generic request, that has a cruise company code on it
            //There is an interface (IGetCruise) that is implemented by 3 classes (Company1, Company2 and Company3)
            //Make sure that the correct class is injected based on the CruiseCompanyCode on the request
            //without directly referencing the 3 classes and the method GetCruises of the chosen implementation is called

            var types = Assembly
                        .GetAssembly(typeof(IGetCruise))
                        .GetTypes()
                        .Where(t => t.IsClass 
                                && !t.IsAbstract 
                                && t.GetInterfaces().Contains(typeof(IGetCruise)))
                        .ToList();

            foreach (var t in types)
            {

                IGetCruise cruise = Activator.CreateInstance(t) as IGetCruise;

                if (cruise != null && request.CruiseCompanyCode == cruise.CruiseCompanyCode)
                    return cruise.GetCruises(request);

            }

            throw new Exception($"CruiseCompanyCode {request.CruiseCompanyCode.ToString()} does not exists.");

        }

    }

}
