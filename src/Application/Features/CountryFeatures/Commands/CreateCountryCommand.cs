using Application.Interfaces;
using Application.Request.Country;
using Application.Response.Country;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class CreateCountryCommand : IRequestHandler<CreateCountryRequest, (bool Succeed, string Message, CreateCountryResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public CreateCountryCommand(IApplicationDbContext applicationDb, IMapper mapper)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<(bool Succeed, string Message, CreateCountryResponse Response)> Handle(CreateCountryRequest request, CancellationToken cancellationToken)
        {
            var unit = mapper.Map<Country>(request);

            var unitNameExist = await applicationDb.Countries.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken);
            if (unitNameExist != null)
                return (false, "The Country with this name has already been created", null);
            //perform insert
            unit.DateCreated = DateTime.Now;
            await applicationDb.Countries.AddAsync(unit, cancellationToken);

            await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = mapper.Map<CreateCountryResponse>(request);
            // return response object
            response.Id = unit.Id;
            return (true, "Country Created successfully", response);
        }
    }
}