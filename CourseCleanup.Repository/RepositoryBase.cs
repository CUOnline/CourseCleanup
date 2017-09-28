namespace CourseCleanup.Repository
{
    public abstract class RepositoryBase
    {
        protected CourseCleanupContext Context = new CourseCleanupContext();
    }
}