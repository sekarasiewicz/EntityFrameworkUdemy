namespace EntityFrameworkUdemy.Repositories
{
    public interface IUnitOfWork
    {
        ICourseRepository Courses { get; }

//        IAuthorRepository Authors { get; }
        int Complete();
    }
}