using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Acts as a DTO to manipulate a person
    /// </summary>
    public class PersonRequest
    {
        public Guid? PersonId { set; get; }
        [Required]
        public required string PersonName { get; set; }
        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Gender { get; set; }
        public Guid CountryId { set; get; }
    }
}
