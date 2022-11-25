using Domain.Common;

namespace Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string Logo { get; set; }
        public string Banner { get; set; }

        public Country Country { get; set; }
        public string CountryId { get; set; }

        public State State { get; set; }
        public string StateId { get; set; }
    }
}