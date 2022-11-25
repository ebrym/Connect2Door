﻿using Application.Interfaces;

namespace Application.Response.Unit
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso >
    /// <cref>
    /// Application.Interfaces.IMapFrom{Domain.Entities.Unit}
    /// </cref>
    /// </seealso>
    public class GetAllUnitResponse : IMapFrom<Domain.Entities.Unit>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the ministry identifier.
        /// </summary>
        /// <value>
        /// The ministry identifier.
        /// </value>
        public string MinistryId { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public string DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the name of the ministry.
        /// </summary>
        /// <value>
        /// The name of the ministry.
        /// </value>
        public string MinistryName { get; set; }
    }
}