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

        /// <summary>
        /// Returns all Countries
        /// </summary>
        /// <returns>Return All Countries a list of<CountryResponse></returns>
        List<CountryResponse> GetAllCountries();

        /// <summary>
        /// Returns a country with the specified Id
        /// </summary>
        /// <param name="countryId">Country Id (Guid) of the country</param>
        /// <returns>A country whose CountryId is equal to the given countryId</returns>
        CountryResponse? GetCountryByCountryId(Guid? countryId);
    }
}
