﻿using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Country entity.
    /// </summary>
    public interface IPersonsService
    {
        /// <summary>
        /// Add a Person to the datasource
        /// </summary>
        /// <param name="personAddRequest">Person object to add</param>
        /// <returns>Returns the Person Object after adding it</returns>
        PersonResponse AddPerson(PersonRequest? personAddRequest);
        
        /// <summary>
        /// Get all persons from the datasource
        /// </summary>
        /// <returns>A list of persons as a list of <PersonResponse></returns>
        List<PersonResponse> GetAllPersons();

        /// <summary>
        /// Returns a Person with the specified Id
        /// </summary>
        /// <param name="personId">The id of person to be returned</param>
        /// <returns>A person whose personId is equal to given personId</returns>
        PersonResponse? GetPersonByPersonId(Guid? personId);
        
        /// <summary>
        /// Removing a Person from the datasource
        /// </summary>
        /// <param name="personId">The Id of person to be deleted</param>
        /// <returns>Returns a bool value indicated that the remove was sucessful or not</returns>
        bool DeletePerson(Guid? personId);

        /// <summary>
        /// Update a person from the datasource
        /// </summary>
        /// <param name="personRequest">Person object to update</param>
        /// <returns>Returns the updated person</returns>
        PersonResponse UpdatePerson(PersonRequest? personRequest);
    }
}
