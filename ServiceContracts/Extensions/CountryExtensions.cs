using Entities;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Extensions
{
    public static class CountryExtensions
    {
        public static Country ToCountry(this CountryAddRequest country) =>
            new Country
            {
                CountryName = country.CountryName
            };

        public static CountryResponse ToCountryResponse(this Country country) =>
            new CountryResponse
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName
            };
    }
}
