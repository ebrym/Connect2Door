
using Application.Interfaces;
// using MailKit.Net.Smtp;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
// using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Application.BackgroundService
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="IHostedService" />
    public class NotificationWorkerService : IHostedService, IDisposable
    {
        // private readonly IApplicationDbContext applicationDbContext;
        // private readonly ILogger<NotificationWorkerService> logger;
        // private readonly IHttpClientFactory httpClientFactory;
        private readonly IServiceScopeFactory serviceScopeFactory;

        private readonly ILogger<NotificationWorkerService> logger;
        // private IServiceScope scope;
        private Timer timer;
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationWorkerService"/> class.
        /// </summary>

        public NotificationWorkerService(IServiceScopeFactory serviceScopeFactory, ILogger<NotificationWorkerService> logger)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
        }

        /// <summary>
        /// Triggered when the application host is ready to start the service.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                timer = new Timer(async o =>
                {
                    await SendEmailAsync(cancellationToken);
                   // await RestartPendingAssetWorkflow(cancellationToken);
                    logger.LogInformation("Mail Service called");
                }, null,
                    TimeSpan.Zero,
                    TimeSpan.FromSeconds(60));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }
        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task SendEmailAsync(CancellationToken cancellationToken)
        {
            try
            {
                var scope = serviceScopeFactory.CreateScope();
                //while (!cancellationToken.IsCancellationRequested)
                //{
                var applicationDbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                var configuration = scope.ServiceProvider.GetRequiredService<Microsoft.Extensions.Configuration.IConfiguration>();
                var _smtpPort = configuration.GetSection("EmailSettings:SMTPPort").Value;
                var _username = configuration.GetSection("EmailSettings:UserNameEmail").Value;
                var _password = configuration.GetSection("EmailSettings:Password").Value;
                var _smtpHost = configuration.GetSection("EmailSettings:SMTPHost").Value;
                var _emailFrom = configuration.GetSection("EmailSettings:EmailFrom").Value;
                
                var mail = await applicationDbContext.NotificationMessages.Where(x => !x.Sent).ToArrayAsync();
                if (mail.Any())
                {
                    foreach (var item in mail)
                    {
                        MailMessage mMessage = new MailMessage();

                        mMessage.To.Add(item.To);
                        mMessage.Subject = item.NotificationActionType.ToString();
                        mMessage.From = new MailAddress($"Connect 2 Door <{_emailFrom}>");
                        mMessage.Body = item.Body;
                        mMessage.Priority = MailPriority.High;
                        mMessage.IsBodyHtml = true;
                        mMessage.BodyEncoding = Encoding.UTF8;
                        using (SmtpClient smtpMail = new SmtpClient())
                        {
                            smtpMail.Host = _smtpHost;
                            smtpMail.EnableSsl = true;
                            smtpMail.UseDefaultCredentials = false;
                            smtpMail.Credentials = new NetworkCredential(_username.Trim(), _password.Trim());
                            smtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtpMail.Timeout = 10000; 
                            smtpMail.SendCompleted += SmtpMail_SendCompleted;
                            item.Sent = true;
                            item.DateModified = DateTime.UtcNow;
                            logger.LogInformation($"using {_username} and {_password}  to send email to {item.To}");
                            await smtpMail.SendMailAsync(mMessage);
                            await applicationDbContext.SaveChangesAsync(cancellationToken);
                        }
                    }

                }
            }
            catch (Exception e)
            {

                logger.LogError(e, e.Message);
            }
           
             
        }
        /// <summary>
        /// Smtps the mail_ send completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void SmtpMail_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var token = e.UserState;
            //todo DB log

            if (e.Cancelled)
            {
                logger.LogInformation($"{token} Send canceled.");
              
            }
            if (e.Error != null)
            {
                logger.LogError(e.Error.Message);
               
            }
            else
            {
                logger.LogInformation($"Email sent successfully to {token}");
               
            }
           
        }

        private async Task SendMail(CancellationToken cancellationToken)
        {
            var scope = serviceScopeFactory.CreateScope();
            //while (!cancellationToken.IsCancellationRequested)
            //{
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
         //   SmtpClient client = new SmtpClient();
            var mailProvider = await applicationDbContext.MailConfigurations.FirstOrDefaultAsync(x => x.IsDefault, cancellationToken: cancellationToken);
            var mail = await applicationDbContext.NotificationMessages.Where(x => !x.Sent).ToArrayAsync();
            // logger.LogInformation($"Mail Service Running - Timer {watch.ElapsedMilliseconds} milliseconds");
            if (mailProvider.ProviderType == Domain.Common.EmailProviderType.ELASTICMAIL)
            {
                if (mail.Any())
                {
                    //MimeMessage message = new MimeMessage();
                    //MailboxAddress from = new MailboxAddress("Admin", "no-reply@cybsoft.ng");
                    //message.From.Add(from);

                    var payload = new Dictionary<string, string>{
                        { "apikey", mailProvider.ApiKey},
                        { "from", mailProvider.From },
                        { "fromName", mailProvider.FromName },
                        { "isTransactional", "true" }};

                    var mailUrl = mailProvider.Url;
                    var httpClientFactory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();
                    HttpClient httpClient = httpClientFactory.CreateClient("HttpClient");
                    foreach (var item in mail)
                    {
                        //MailboxAddress to = new MailboxAddress("", item.To);
                        //message.To.Add(to);
                        //message.Subject = item.NotificationActionType.ToString();
                        //BodyBuilder bodyBuilder = new BodyBuilder();
                        //bodyBuilder.HtmlBody = item.Body;
                        //message.Body = bodyBuilder.ToMessageBody();
                       
                        //client.Connect("smtp.elasticemail.com", 2525, true);
                        //client.Authenticate("webmasters@cyberspace.net.ng", "4DE9B28B192DA1FD90A2EF84984E6EB26865");
                        //client.Send(message);
                        //client.MessageSent += Client_MessageSent;
                        //item.Sent = true;
                        //item.DateModified = DateTime.UtcNow;
                        //await applicationDbContext.SaveChangesAsync(cancellationToken);

                        payload.TryAdd("to", item.To);
                        payload.TryAdd("subject", item.NotificationActionType.ToString());
                        payload.TryAdd("bodyHtml", item.Body);
                        var formContent = new FormUrlEncodedContent(payload);
                        HttpResponseMessage response = await httpClient.PostAsync(mailUrl, formContent, cancellationToken);
                        if (response.IsSuccessStatusCode)
                        {
                            item.Sent = true;
                            item.DateModified = DateTime.UtcNow;
                            await applicationDbContext.SaveChangesAsync(cancellationToken);

                        }
                        else
                        {
                            logger.LogInformation(response.ReasonPhrase);
                        }
                    }
                    //client.Disconnect(true);
                    //client.Dispose();
                }
            }
            else if (mailProvider.ProviderType == Domain.Common.EmailProviderType.SENDGRID)
            {
                if (mail.Any())
                {
                    foreach (var item in mail)
                    {
                        var gridClient = new SendGridClient(mailProvider.ApiKey);
                        var from = new EmailAddress(mailProvider.From, mailProvider.FromName);
                        var subject = item.NotificationActionType.ToString();
                        var to = new EmailAddress(item.To);
                        var msg = MailHelper.CreateSingleEmail(from, to, subject, "", item.Body);
                        SendGrid.Response response = await gridClient.SendEmailAsync(msg, cancellationToken);

                        if (response is { StatusCode: HttpStatusCode.Accepted })
                        {
                            item.Sent = true;
                            await applicationDbContext.SaveChangesAsync(cancellationToken);
                            logger.LogInformation($"---- mail has been successfully sent to {item.To} using Send Grid Mail Provider -----");
                        }
                        else
                        {
                            if (response != null)
                            {
                                Dictionary<string, dynamic> resBody = await response.DeserializeResponseBodyAsync(response.Body);

                                foreach (var i in resBody)
                                {
                                    logger.LogInformation(i.Key);
                                }
                            }
                        }
                    }
                }
            }

            // await Task.Delay(1000 * 5, cancellationToken);
        }

       
        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            // logger.LogInformation("Service Stopped!");

            return Task.CompletedTask;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}