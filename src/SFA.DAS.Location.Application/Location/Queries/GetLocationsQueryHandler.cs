using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFA.DAS.Location.Domain.Interfaces;

namespace SFA.DAS.Location.Application.Location.Queries
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery,GetLocationsResponse>
    {
        private readonly ILocationService _locationService;

        public GetLocationsQueryHandler (ILocationService locationService)
        {
            _locationService = locationService;
        }
        public async Task<GetLocationsResponse> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _locationService.GetLocationsByQuery(request.Query, request.ResultCount);
            
            return new GetLocationsResponse
            {
                Locations = result.ToList()
            };
        }
    }
}