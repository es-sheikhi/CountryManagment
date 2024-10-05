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

        #region AddCountry
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
        public void AddCountry_ShouldThrowException_WhenCountryNameIsDuplicate()
        {
            //Arrange
            CountryAddRequest countryAddRequest1 = new()
            {
                CountryName = "UK"
            };
            CountryAddRequest countryAddRequest2 = new()
            {
                CountryName = "UK"
            };

            //Act
            _countriesService.AddCountry(countryAddRequest1);
            var result = () => _countriesService.AddCountry(countryAddRequest2);

            //Assert
            Assert.Throws<Exception>(result);
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
            var countryList = _countriesService.GetAllCountries();

            //Assert
            Assert.True(result?.CountryId != null);
            Assert.Contains(result, countryList);
        }
        #endregion

        #region GetAllCountries
        [Fact]
        public void GetAllCountries_ShouldBeEmpty_WhenNothingIsAdded()
        {
            //Arrange

            //Act
            var countryList = _countriesService.GetAllCountries();

            //Assert
            Assert.Empty(countryList);
        }

        [Fact]
        public void GetAllCountries_ShouldNotBeNull_WhenSomethingIsAdded()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new()
            {
                CountryName = "Germany"
            };

            //Act
            var result = _countriesService.AddCountry(countryAddRequest);
            var countryList = _countriesService.GetAllCountries();

            //Assert
            Assert.NotEmpty(countryList);
        }
        #endregion

        #region GetCountryByCountryId

        [Fact]
        public void GetCountryByCountryId_ShouldThrowException_WhenCountryIdIsNull()
        {
            //Arrange
            Guid? countryId = null;

            //Act
            var result = () => _countriesService.GetCountryByCountryId(countryId);

            //Assert
            Assert.Throws<ArgumentNullException>(result);
        }

        [Fact]
        public void GetCountryByCountryId_ShouldReturnNull_WhenCountryIdIsNotValid()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new()
            {
                CountryName = "Germany"
            };


            //Act
            var result = _countriesService.AddCountry(countryAddRequest);
            var response = _countriesService.GetCountryByCountryId(new Guid());

            //Assert
            Assert.Null(response);
        }

        [Fact]
        public void GetCountryByCountryId_ShouldReturnCountry_WhenCountryIdIsValid()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new()
            {
                CountryName = "Germany"
            };

            var result = _countriesService.AddCountry(countryAddRequest);
            var response = _countriesService.GetCountryByCountryId(result.CountryId);

            //Assert
            Assert.Equal(result, response);
        }

        #endregion

    }
}
