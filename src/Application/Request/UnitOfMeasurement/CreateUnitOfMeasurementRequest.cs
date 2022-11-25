﻿using Application.Interfaces;
using Application.Response.UnitOfMeasurement;
using MediatR;

namespace Application.Request.UnitOfMeasurement
{
    /// <summary>
    /// 1.Name (unique)
    ///2.Website
    ///3.Description
    ///4.Email
    ///5.PhoneNo
    ///6.ContactPerson
    ///7. Status(True or false)
    /// </summary>
    ///     public class CreateVendorRequest :  IRequest<(bool Succeed, string Message, CreateMinistryResponse Response)>, IMapFrom<Domain.Entities.Vendor>

    public class CreateUnitOfMeasurementRequest : IRequest<(bool Succeed, string Message, CreateUnitOfMeasurementResponse Response)>, IMapFrom<Domain.Entities.UnitOfMeasurement>
    {
        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        public string Code { get; set; }
    }
}