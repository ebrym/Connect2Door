using Application.Interfaces;
using Application.Response.UnitOfMeasurement;
using MediatR;

namespace Application.Request.UnitOfMeasurement
{
    public class UpdateUnitOfMeasurementRequest : IRequest<(bool Succeed, string Message, UpdateUnitOfMeasurementResponse Response)>, IMapFrom<Domain.Entities.UnitOfMeasurement>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}