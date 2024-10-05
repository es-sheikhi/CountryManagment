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
        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
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
    }
}
