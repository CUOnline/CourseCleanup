using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients.Models
{
    public class EnrollmentTerm : BaseModel, IComparable<EnrollmentTerm>
    {
        public int CompareTo(EnrollmentTerm other)
        {
            // Terms should follow the format 'Season Year' Eg. Spring 2017
            // A few exceptions exist such as 'Default Term', 'Migration', 'Orientation', 'Sandbox'  We want default functionality for these.
            var genericTerms = new[] { "1", "35", "38", "39" };
            if (Array.IndexOf(genericTerms, this.Id) > 0 || Array.IndexOf(genericTerms, other.Id) > 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            var seasons = new[] { "Spring", "Summer", "Fall", "Winter" };

            var thisTerm = this.Name.Split(' ');
            var otherTerm = other.Name.Split(' ');

            if(int.Parse(thisTerm[1]) != int.Parse(otherTerm[1]))
            {
                return int.Parse(thisTerm[1]).CompareTo(int.Parse(otherTerm[1]));
            }
            else
            {
                return Array.IndexOf(seasons, thisTerm[0]).CompareTo(Array.IndexOf(seasons, otherTerm[0]));
            }
        }
    }
}
