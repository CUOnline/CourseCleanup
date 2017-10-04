using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients.Models.Enums
{
    public enum RoleNames
    {
        AccountAdmin,
        EnrollmentManager,
        HelpDesk,
        OutcomesAdmin,
        SubAccountAdmin,
        Other
    }

    public class RoleNamesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            switch (enumString)
            {
                case "AccountAdmin":
                    {
                        return RoleNames.AccountAdmin;
                    }
                case "Enrollment Manager":
                    {
                        return RoleNames.EnrollmentManager;
                    }
                case "Help Desk":
                    {
                        return RoleNames.HelpDesk;
                    }
                case "Outcomes Admin":
                    {
                        return RoleNames.OutcomesAdmin;
                    }
                case "Sub-Account Admin":
                    {
                        return RoleNames.SubAccountAdmin;
                    }
                default:
                    {
                        return RoleNames.Other;
                    }
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var roleName = (RoleNames)value;
            switch (roleName)
            {
                case RoleNames.AccountAdmin:
                    {
                        writer.WriteValue("AccountAdmin");
                        break;
                    }
                case RoleNames.EnrollmentManager:
                    {
                        writer.WriteValue("EnrollmentManager");
                        break;
                    }
                case RoleNames.HelpDesk:
                    {
                        writer.WriteValue("Help Desk");
                        break;
                    }
                case RoleNames.OutcomesAdmin:
                    {
                        writer.WriteValue("OutcomesAdmin");
                        break;
                    }
                case RoleNames.SubAccountAdmin:
                    {
                        writer.WriteValue("SubAccountAdmin");
                        break;
                    }
            }
        }
    }
}
