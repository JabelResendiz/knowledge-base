
using BuberDinner.Application.Common.Interfaces.Services;

namespace DownTrack.Infrastrcuture.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}