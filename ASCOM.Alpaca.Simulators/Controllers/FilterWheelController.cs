﻿using Alpaca;
using ASCOM.Common.Alpaca;
using ASCOM.Common.DeviceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace ASCOM.Alpaca.Simulators
{
    [ServiceFilter(typeof(AuthorizationFilter))]
    [ApiController]
    [Route("api/v1/filterwheel/")]
    public class FilterWheelController : AlpacaController
    {
        [NonAction]
        public override IAscomDevice GetDevice(uint DeviceNumber)
        {
            return DeviceManager.GetFilterWheel(DeviceNumber);
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("{DeviceNumber}/focusoffsets")]
        public ActionResult<IntListResponse> FocusOffsets([DefaultValue(0)][SwaggerSchema(Strings.DeviceIDDescription, Format = "uint32")][Range(0, 4294967295)] uint DeviceNumber,
 [SwaggerSchema(Description = Strings.ClientIDDescription, Format = "uint32")][Range(0, 4294967295)] uint ClientID = 0,
 [SwaggerSchema(Strings.ClientTransactionIDDescription, Format = "uint32")][Range(0, 4294967295)] uint ClientTransactionID = 0
)
        {
            return ProcessRequest(() => DeviceManager.GetFilterWheel(DeviceNumber).FocusOffsets, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("{DeviceNumber}/names")]
        public ActionResult<StringListResponse> Names([DefaultValue(0)][SwaggerSchema(Strings.DeviceIDDescription, Format = "uint32")][Range(0, 4294967295)] uint DeviceNumber,
 [SwaggerSchema(Description = Strings.ClientIDDescription, Format = "uint32")][Range(0, 4294967295)] uint ClientID = 0,
 [SwaggerSchema(Strings.ClientTransactionIDDescription, Format = "uint32")][Range(0, 4294967295)] uint ClientTransactionID = 0
)
        {
            return ProcessRequest(() => DeviceManager.GetFilterWheel(DeviceNumber).Names, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("{DeviceNumber}/position")]
        public ActionResult<IntResponse> Position([DefaultValue(0)][SwaggerSchema(Strings.DeviceIDDescription, Format = "uint32")][Range(0, 4294967295)] uint DeviceNumber,
 [SwaggerSchema(Description = Strings.ClientIDDescription, Format = "uint32")][Range(0, 4294967295)] uint ClientID = 0,
 [SwaggerSchema(Strings.ClientTransactionIDDescription, Format = "uint32")][Range(0, 4294967295)] uint ClientTransactionID = 0
)
        {
            return ProcessRequest(() => DeviceManager.GetFilterWheel(DeviceNumber).Position, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [Route("{DeviceNumber}/position")]
        public ActionResult<Response> Position([DefaultValue(0)][SwaggerSchema(Strings.DeviceIDDescription, Format = "uint32")][Range(0, 4294967295)] uint DeviceNumber,
 [Required][FromForm] short Position, [FromForm][SwaggerSchema(Description = Strings.ClientIDDescription, Format = "uint32")][Range(0, 4294967295)] uint ClientID = 0,
 [FromForm][SwaggerSchema(Strings.ClientTransactionIDDescription, Format = "uint32")][Range(0, 4294967295)] uint ClientTransactionID = 0
)
        {
            return ProcessRequest(() => { DeviceManager.GetFilterWheel(DeviceNumber).Position = Position; }, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }
    }
}