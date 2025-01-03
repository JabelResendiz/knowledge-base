using TravelAgency.Domain.Common;

namespace TravelAgency.Domain.Entities
{
    public class Hotel:BaseEntity
    {
        //!Set restrictions
        public string Name {get; set;} = null!;
        public string Category{get; set;} = null!;
        public string Address {get; set;} = null!;
        public IList<LodgingOffer> lodgingOffers{get; private set;} = new List<LodgingOffer>();
    }
}