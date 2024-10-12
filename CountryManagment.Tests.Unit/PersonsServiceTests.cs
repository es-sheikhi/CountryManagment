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
            PersonRequest personAddRequest = null;

            //Act
            var response=()=>_personsService.AddPerson(personAddRequest);

            //Assert
            Assert.Throws<ArgumentNullException>(response);
        }

        [Fact]
        public void AddPerson_ShouldThrowException_WhenPersonNameIsNull()
        {
            //Arrange
            PersonRequest personAddRequest = new PersonRequest
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
            PersonRequest personAddRequest = new PersonRequest
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
            PersonRequest PersonAddRequest = new()
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
            PersonRequest PersonAddRequest = new()
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
            PersonRequest PersonAddRequest = new()
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

        #region DeletePerson
        [Fact]
        public void DeletePerson_ShouldReturnFalse_WhenPersonIdIsInvalid()
        {
            //Arrange
            Guid? PersonId = null;

            //Act
            var result = _personsService.DeletePerson(PersonId);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DeletePerson_ShouldReturnTrue_WhenPersonIdIsValid()
        {
            //Arrange
            PersonRequest personRequest = new PersonRequest
            {
                PersonName = "Test",
                EmailAddress = "Test@google.com",
                CountryId = Guid.NewGuid(),
                Gender = "Male"
            };

            //Act
            var response = _personsService.AddPerson(personRequest);
            var result = _personsService.DeletePerson(response?.PersonId);

            //Assert
            Assert.True(result);
        }
        #endregion

        #region UpdatePerson
        [Fact]
        public void UpdatePerson_ShouldThrowException_WhenPersonIsNull()
        {
            //Arrange
            PersonRequest personUpdateRequest = null;

            //Act
            var response = () => _personsService.UpdatePerson(personUpdateRequest);

            //Assert
            Assert.Throws<ArgumentNullException>(response);
        }

        [Fact]
        public void UpdatePerson_ShouldThrowException_WhenPersonNameIsNull()
        {
            //Arrange
            PersonRequest personUpdateRequest = new PersonRequest
            {
                PersonName = null
            };

            //Act
            var response = () => _personsService.UpdatePerson(personUpdateRequest);

            //Assert
            Assert.Throws<ArgumentException>(response);
        }
        [Fact]
        public void UpdatePerson_ShouldReturnProperPerson_WhenEverythingIsOK()
        {
            //Arrange
            PersonRequest personAddRequest = new PersonRequest
            {
                PersonName = "Test",
                EmailAddress = "Test@google.com",
                CountryId = Guid.NewGuid(),
                Gender = "Male"
            };
            PersonRequest personUpdateRequest = new PersonRequest
            {
                PersonName = "Test",
                EmailAddress = "Test@google.com",
                CountryId = Guid.NewGuid(),
                Gender = "Female"
            };

            //Act
            var addResponse = _personsService.AddPerson(personAddRequest);
            personUpdateRequest.PersonId = addResponse?.PersonId;
            var updateResponse = _personsService.UpdatePerson(personUpdateRequest);

            //Assert
            Assert.NotNull(updateResponse?.PersonId);
        }
        #endregion
    }
}
