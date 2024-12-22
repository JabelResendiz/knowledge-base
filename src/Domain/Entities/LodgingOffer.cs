


using Microsoft.Identity.Client;
using TravelAgency.Domain.Common;

namespace TravelAgency.Domain.Entities
{
    public class LodgingOffer : BaseEntity
    {
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public string Description { get; set; } = null!;
        public double Price { get; set; }
    }
}