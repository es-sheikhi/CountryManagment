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
    public class PersonsService : IPersonsService
    {
        private List<Person> _persons;
        public PersonsService()
        {
            _persons = new List<Person>();
        }
        public PersonResponse AddPerson(PersonRequest? personAddRequest)
        {
            if (personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }
            if (personAddRequest.PersonName == null)
            {
                throw new ArgumentException(nameof(personAddRequest.PersonName));
            }

            Person Person = personAddRequest.ToPerson();
            Person.PersonId = Guid.NewGuid();

            _persons.Add(Person);
            return Person.ToPersonResponse();
        }

        public List<PersonResponse> GetAllPersons()
        {
            List<PersonResponse> personList = _persons.Select(c => c.ToPersonResponse())
                .ToList();
            return personList;
        }

        public PersonResponse? GetPersonByPersonId(Guid? personId)
        {
            if (personId is null)
                throw new ArgumentNullException(nameof(personId));

            PersonResponse? personResponse = _persons.FirstOrDefault(c => c.PersonId == personId)
                ?.ToPersonResponse();
            return personResponse;
        }

        public bool DeletePerson(Guid? personId)
        {
            Person? matchingPerson = _persons.FirstOrDefault(temp => temp.PersonId == personId);
            if (matchingPerson != null)
            {
                return _persons.Remove(matchingPerson);
            }
            return false;
        }

        public PersonResponse UpdatePerson(PersonRequest? personRequest)
        {
            if (personRequest == null)
                throw new ArgumentNullException(nameof(Person));

            
            //get matching person object to update
            Person? matchingPerson = _persons.FirstOrDefault(temp => temp.PersonId == personRequest.PersonId);
            if (matchingPerson == null)
            {
                throw new ArgumentException("Given person id doesn't exist");
            }

            //update all details
            matchingPerson.PersonName = personRequest.PersonName;
            matchingPerson.EmailAddress = personRequest.EmailAddress;
            matchingPerson.Gender = personRequest.Gender;
            matchingPerson.CountryId = personRequest.CountryId;

            return matchingPerson.ToPersonResponse();
        }
    }
}
