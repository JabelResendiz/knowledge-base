using TravelAgency.Domain.Common;

namespace TravelAgency.Domain.Entities
{
    public class Facility:BaseEntity
    {
        //!Set restrictions
        public string Name {get; set;} = null!; //Must be NON-NULL!!!
    }
}