using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagment.Tests.Unit
{
    public class PersonsServiceTests
    {
        private readonly IPersonsService _personsService;
        public PersonsServiceTests()
        {
            _personsService = new PersonsService();
        }

        #region AddPerson
        [Fact]
        public void AddPerson_ShouldThrowException_WhenPersonIsNull()
        {
            //Arrange
            PersonAddRequest personAddRequest = null;

            //Act
            var response=()=>_personsService.AddPerson(personAddRequest);

            //Assert
            Assert.Throws<ArgumentNullException>(response);
        }

        [Fact]
        public void AddPerson_ShouldThrowException_WhenPersonNameIsNull()
        {
            //Arrange
            PersonAddRequest personAddRequest = new PersonAddRequest
            {
                PersonName = null
            };

            //Act
            var response = () => _personsService.AddPerson(personAddRequest);

            //Assert
            Assert.Throws<ArgumentException>(response);
        }
        [Fact]
        public void AddPerson_ShouldReturnProperPerson_WhenEverythingIsOK()
        {
            //Arrange
            PersonAddRequest personAddRequest = new PersonAddRequest
            {
                PersonName = "Test",
                EmailAddress = "Test@google.com",
                CountryId = Guid.NewGuid(),
                Gender = "Male"
            };

            //Act
            var response = _personsService.AddPerson(personAddRequest);

            //Assert
            Assert.NotNull(response?.PersonId);
        }
        #endregion

        #region GetAllPersons
        [Fact]
        public void GetAllPersons_ShouldBeEmpty_WhenNothingIsAdded()
        {
            //Arrange

            //Act
            var PersonList = _personsService.GetAllPersons();

            //Assert
            Assert.Empty(PersonList);
        }

        [Fact]
        public void GetAllPersons_ShouldNotBeNull_WhenSomethingIsAdded()
        {
            //Arrange
            PersonAddRequest PersonAddRequest = new()
            {
                PersonName = "Test",
                EmailAddress = "Test@google.com",
                CountryId = Guid.NewGuid(),
                Gender = "Male"
            };

            //Act
            var result = _personsService.AddPerson(PersonAddRequest);
            var PersonList = _personsService.GetAllPersons();

            //Assert
            Assert.NotEmpty(PersonList);
        }
        #endregion


        #region GetPersonByPersonId

        [Fact]
        public void GetPersonByPersonId_ShouldThrowException_WhenPersonIdIsNull()
        {
            //Arrange
            Guid? PersonId = null;

            //Act
            var result = () => _personsService.GetPersonByPersonId(PersonId);

            //Assert
            Assert.Throws<ArgumentNullException>(result);
        }

        [Fact]
        public void GetPersonByPersonId_ShouldReturnNull_WhenPersonIdIsNotValid()
        {
            //Arrange
            PersonAddRequest PersonAddRequest = new()
            {
                PersonName = "Test",
                EmailAddress = "Test@google.com",
                CountryId = Guid.NewGuid(),
                Gender = "Male"
            };


            //Act
            var result = _personsService.AddPerson(PersonAddRequest);
            var response = _personsService.GetPersonByPersonId(new Guid());

            //Assert
            Assert.Null(response);
        }

        [Fact]
        public void GetPersonByPersonId_ShouldReturnPerson_WhenPersonIdIsValid()
        {
            //Arrange
            PersonAddRequest PersonAddRequest = new()
            {
                PersonName = "Test",
                EmailAddress = "Test@google.com",
                CountryId = Guid.NewGuid(),
                Gender = "Male"
            };

            var result = _personsService.AddPerson(PersonAddRequest);
            var response = _personsService.GetPersonByPersonId(result.PersonId);

            //Assert
            Assert.Equal(result, response);
        }

        #endregion
    }
}
