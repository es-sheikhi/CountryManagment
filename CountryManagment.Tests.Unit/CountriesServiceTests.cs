using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryManagment.Tests.Unit
{
    public class CountriesServiceTests
    {
        private readonly ICountriesService _countriesService;
        public CountriesServiceTests()
        {
            _countriesService = new CountriesService();
        }

        [Fact]
        public void AddCountry_ShouldThrowException_WhenCountryIsNull()
        {
            //Arrange
            CountryAddRequest countryAddRequest = null;

            //Act
            var result = () => _countriesService.AddCountry(countryAddRequest);

            //Assert
            Assert.Throws<ArgumentNullException>(result);
        }

        [Fact]
        public void AddCountry_ShouldThrowException_WhenCountryNameIsNull()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new()
            {
                CountryName = null
            };

            //Act
            var result = () => _countriesService.AddCountry(countryAddRequest);

            //Assert
            Assert.Throws<ArgumentException>(result);
        }

        [Fact]
        public void AddCountry_ShouldThrowException_WhenCountryNameIsDuplicated()
        {
            //Arrange
            CountryAddRequest countryAddRequest1 = new()
            {
                CountryName = "UK"
            };
            CountryAddRequest countryAddRequest2 = new()
            {
                CountryName = "USA"
            };

            //Act
            _countriesService.AddCountry(countryAddRequest1);
            var result = () => _countriesService.AddCountry(countryAddRequest2);

            //Assert
            Assert.Throws<ArgumentException>(result);
        }

        [Fact]
        public void AddCountry_ShouldReturnProperCountry_WhenEverythingIsOK()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new()
            {
                CountryName = "Germany"
            };

            //Act
            var result = _countriesService.AddCountry(countryAddRequest);

            //Assert
            Assert.True(result?.CountryId != null);
        }

    }
}
