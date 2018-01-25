using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCleanup.Interface.BLL
{
    public interface ISendEmailBLL
    {
        Task<bool> SendEmail(string toEmail, string emailTemplate, Dictionary<string, string> bodyReplacementValues, 
            Dictionary<string, string> subjectReplacementValues);
    }
}
