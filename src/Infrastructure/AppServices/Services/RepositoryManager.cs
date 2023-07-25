using AutoMapper;
using Domain.Entities;
using Domain.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Persistance;

namespace AppServices.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly PurchaseManagmentAppContext _purchaseManagmentAppContext;
        private UserManager<AppUser> _userManager;
        private IMapper _mapper;
        private IConfiguration _configuration;
        private IUserAuthRepository _userAuthRepository;

        public RepositoryManager(PurchaseManagmentAppContext purchaseManagmentAppContext, UserManager<AppUser> userManager,
            IMapper mapper, IConfiguration configuration)
        {
            _purchaseManagmentAppContext = purchaseManagmentAppContext;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            //_userAuthRepository = userAuthRepository;
        }

        public IUserAuthRepository UserAuthentication
        {
            get
            {
                if (_userAuthRepository is null)
                    _userAuthRepository = new UserAuthRepository(_userManager, _configuration, _mapper);
                return _userAuthRepository;
            }
        }

        public Task SaveAsync() => _purchaseManagmentAppContext.SaveChangesAsync();
    }
}
