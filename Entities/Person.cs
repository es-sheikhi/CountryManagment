using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Domain model for storing countries
    /// </summary>
    public class Person
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? EmailAddress { get; set; } 
        public string? Gender { get; set;}
        public Guid CountryId { set; get; }
    }
}
