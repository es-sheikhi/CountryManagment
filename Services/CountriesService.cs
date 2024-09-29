using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private List<Country> _countries;
        public CountriesService()
        {
            _countries = new List<Country>();   
        }
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            if(countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            Country country = countryAddRequest.ToCountry();
            country.CountryId =Guid.NewGuid();

            if (_countries.Where(c => c.CountryName == country.CountryName).Count() > 0)
            {
                throw new Exception($"Country name : {nameof(country.CountryName)} is duplicate!");
            }    
            _countries.Add(country);
            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            var countryList = _countries.Select(c => c.ToCountryResponse())
                .ToList();
            return countryList;
        }

        public CountryResponse? GetCountryByCountryId(Guid? countryId)
        {
            if (countryId == null)
                throw new ArgumentNullException(nameof(countryId));

            CountryResponse? country = _countries.FirstOrDefault(c => c.CountryId == countryId)
                ?.ToCountryResponse();
            return country;
        }
    }
}
