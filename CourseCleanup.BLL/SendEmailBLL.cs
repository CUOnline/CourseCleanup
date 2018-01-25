using CourseCleanup.Interface.BLL;
using Hermes.Clients;
using RSS.EmailEngine.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCleanup.BLL
{
    public class SendEmailBLL : ISendEmailBLL
    {
        public async Task<bool> SendEmail(string toEmail, string emailTemplate, Dictionary<string, string> bodyReplacementValues, 
            Dictionary<string, string> subjectReplacementValues)
        {
            var hermesApi = ConfigurationManager.AppSettings["HermesApi"];
            var applicationId = Convert.ToInt16(ConfigurationManager.AppSettings["ApplicationId"]);
            var authorizationToken = ConfigurationManager.AppSettings["EmailAuthorizationToken"];
            var sendEmails = Convert.ToBoolean(ConfigurationManager.AppSettings["SendEmails"] ?? "false");
            var sendEmailClient = new SendEmailClient(hermesApi);

            if (sendEmails)
            {
                if (!String.IsNullOrEmpty(toEmail))
                {
                    var emailItem = new EmailItem
                    {
                        ToEmail = toEmail,
                        ApplicationId = applicationId,
                        EmailTemplate = emailTemplate,
                        AuthorizationToken = authorizationToken,
                        ReplacementValues = bodyReplacementValues,
                        SubjectReplacementValues = subjectReplacementValues
                    };

                    await sendEmailClient.SendEmailAsync(emailItem);
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}
