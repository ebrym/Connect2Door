using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Domain.Common.BaseEntity" />
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the staff identifier.
        /// </summary>
        /// <value>
        /// The staff identifier.
        /// </value>
        public string StaffId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

      

        

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the phone no.
        /// </summary>
        /// <value>
        /// The phone no.
        /// </value>
        public string PhoneNo { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        /// <value>
        /// The picture.
        /// </value>
        public string Picture { get; set; }

       

        

        /// <summary>
        /// Gets or sets the Unit.
        /// </summary>
        /// <value>
        /// The Unit.
        /// </value>
        public Unit? Unit { get; set; }

        /// <summary>
        /// Gets or sets the Unit identifier.
        /// </summary>
        /// <value>
        /// The Unit identifier.
        /// </value>
        public string? UnitId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string? UserId { get; set; }

        /// <summary>
        /// Gets or sets the user Status.
        /// </summary>
        /// <value>
        /// The user Status.
        /// </value>
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public Country? Country { get; set; }
        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public string? CountryId { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public State? State { get; set; }
        /// <summary>
        /// Gets or sets the state identifier.
        /// </summary>
        /// <value>
        /// The state identifier.
        /// </value>
        public string? StateId { get; set; }

        /// <summary>
        /// Gets or sets the local government.
        /// </summary>
        /// <value>
        /// The local government.
        /// </value>
        public LocalGovernment LocalGovernment { get; set; }
        /// <summary>
        /// Gets or sets the local government identifier.
        /// </summary>
        /// <value>
        /// The local government identifier.
        /// </value>
        public string? LocalGovernmentId { get; set; }
    }
}