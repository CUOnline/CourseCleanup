using System.Data.Entity.Validation;

namespace CourseCleanup.Repository
{
    public abstract class RepositoryBase
    {
        protected CourseCleanupContext Context = new CourseCleanupContext();

        protected void DisplayDbEntityErrors(DbEntityValidationException ex)
        {
            foreach (var eve in ex.EntityValidationErrors)
            {
                System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                }
            }
        }
    }
}