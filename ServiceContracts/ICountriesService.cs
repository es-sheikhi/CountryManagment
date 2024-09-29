using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Country entity.
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Add a Country entity to the datasource
        /// </summary>
        /// <param name="countryAddRequest">Country object to add</param>
        /// <returns>Returns the Country object after adding it</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
    }
}
