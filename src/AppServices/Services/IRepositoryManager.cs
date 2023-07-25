namespace Domain.Service.Services
{
    public interface IRepositoryManager
    {
        IUserAuthRepository UserAuthentication { get; }
        Task SaveAsync();
    }
}
