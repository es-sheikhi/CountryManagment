using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class is used as return type for most of PersonsService methods
    /// </summary>
    public class PersonResponse
    {
        public Guid? PersonId { get; set; }
        public required string PersonName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Gender { get; set; }
        public Guid CountryId { set; get; }
        public override bool Equals(object? obj)
        {
            if(obj is null)
                return false;

            PersonResponse person = (PersonResponse)obj;
            return PersonId == person.PersonId
                && PersonName == person.PersonName
                && EmailAddress == person.EmailAddress
                && Gender == person.Gender
                && CountryId == person.CountryId;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
