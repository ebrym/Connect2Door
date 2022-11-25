using Api.ResponseWrapper;
using Application.Request.NotificationReceiver;
using Application.Response.NotificationReceiver;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Endpoints
{
    /// </summary>
    [ApiVersion("1.0")]
    public class NotificationReceiverController : BaseApiController
    {
        /// <summary>
        /// Adds the NotificationReceiver
        /// </summary>
        /// <param name="notificationReceiverRequest"> Creates a new NotificationReceiver</param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesDefaultResponseType(typeof(CreateNotificationReceiverResponse))]
        public async Task<IActionResult> AddNotificationReceiverAsync([FromBody] CreateNotificationReceiverRequest notificationReceiverRequest)
        {
            (bool succeed, string message, CreateNotificationReceiverResponse notificationReceiverResponse) = await Mediator.Send(notificationReceiverRequest);
            if (succeed)
                return Ok(notificationReceiverResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Deletes a NotificationReceiver
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        [ProducesDefaultResponseType(typeof(DeleteNotificationReceiverResponse))]
        public async Task<IActionResult> DeleteNotificationReceiverAsync(string id)
        {
            DeleteNotificationReceiverRequest deleteNotificationReceiverRequest = new DeleteNotificationReceiverRequest
            {
                Id = id
            };
            (bool succeed, string message, DeleteNotificationReceiverResponse deleteNotificationReceiverResponse) =
                await Mediator.Send(deleteNotificationReceiverRequest);
            if (succeed)
                return Ok(deleteNotificationReceiverResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Gets all NotificationReceivers
        /// </summary>
        /// <param name="notificationReceiverRequest"> Gets all NotificationReceivers</param>
        /// <returns></returns>
        [HttpPost("getbyLocationId")]
        [ProducesDefaultResponseType(typeof(GetAllNotificationReceiverResponse))]
        public async Task<IActionResult> GetAllNotificationReceiverAsync([FromBody] GetAllNotificationReceiverRequest getAllNotificationReceiverRequest)
        {
            List<GetAllNotificationReceiverResponse> notificationReceiver = await Mediator.Send(getAllNotificationReceiverRequest);

            return Ok(notificationReceiver.ToResponse());
        }

        /// <summary>
        /// Gets a specific NotificationReceiver
        /// </summary>
        /// <param name="notificationReceiverRequest"> Gets a specific NotificationReceiver</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetNotificationReceiverByIdResponse))]
        public async Task<IActionResult> GetByIdNotificationReceiverAsync(string Id)
        {
            GetNotificationReceiverByIdResponse notificationReceiver = await Mediator.Send(new GetNotificationReceiverByIdRequest() { Id = Id });
            return Ok(notificationReceiver.ToResponse());
        }

        /// <summary>
        /// Updates the NotificationReceiver
        /// </summary>
        /// <param name="notificationReceiverRequest"> Updates the NotificationReceiver</param>
        /// <returns></returns>
        [HttpPost("update")]
        [ProducesDefaultResponseType(typeof(UpdateNotificationReceiverResponse))]
        public async Task<IActionResult> UpdateMinistryAsync([FromBody] UpdateNotificationReceiverRequest notificationReceiverRequest)
        {
            UpdateNotificationReceiverRequest update = new UpdateNotificationReceiverRequest();
            update = notificationReceiverRequest;

            (bool succeed, string message, UpdateNotificationReceiverResponse notificationReceiverResponse) = await Mediator.Send(update);
            if (succeed)
                return Ok(notificationReceiverResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }
    }
}