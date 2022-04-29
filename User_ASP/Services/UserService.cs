using AutoMapper;
using BCrypt;
using User_ASP.Authorization;
using User_ASP.Entities;
using User_ASP.Helpers;
using User_ASP.Models.Users;

namespace User_ASP.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        void Register(RegisterRequest request);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IJwtUtils jwtUtils, IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        /// <summary>
        /// verifies authentication request
        /// returns generated token if user located in database and hashed password match
        /// </summary>
        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Thats not the secret word!");
           
            var response = _mapper.Map<AuthenticateResponse>(user);
            
            response.Token = _jwtUtils.GenerateToken(user);

            return response;
        }

        /// <summary>
        /// map register request as user
        /// bcrypt hash requested password
        /// add user to database
        /// </summary>
        public void Register(RegisterRequest request)
        {
            if (_context.Users.Any(x => x.Username == request.Username))
                throw new Exception("Are you an impostor??");

            var user = _mapper.Map<User>(request);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }
           

        // use in JwtMiddleware
        public User GetById(int id) 
            => _context.Users.Find(id);

    }
}
