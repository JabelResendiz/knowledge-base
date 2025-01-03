using TravelAgency.Domain.Common;


namespace TravelAgency.Domain.Entities
{
    public class Agency:BaseEntity
    {
        //!Set restrictions
        public string Name {get; set;} = null!;
        public string Fax {get; set;} = null!;
        public string Address {get; set;} = null!;
        public string ElectronicAddress {get; set;} = null!;


    }
}