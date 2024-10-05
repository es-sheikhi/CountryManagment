using Entities;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Extensions
{
    public static class PersonExtensions
    {
        public static Person ToPerson(this PersonRequest request)=>
            new Person
            { 
                PersonName = request.PersonName ,
                CountryId = request.CountryId ,
                EmailAddress = request.EmailAddress ,
                Gender = request.Gender
            };

        public static PersonResponse ToPersonResponse(this Person person) =>
            new PersonResponse
            {
                PersonName = person.PersonName,
                CountryId = person.CountryId,
                EmailAddress = person.EmailAddress,
                Gender = person.Gender,
                PersonId = person.PersonId
            };
    }
}
