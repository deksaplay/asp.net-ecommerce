using e_commerce.Data;
using e_commerce.Models;
using System.Threading.Tasks;
using e_commerce.Base;

namespace e_commerce.Services
{
    public class UserService : BaseService<User>
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context, dbconnection dbconn) : base(context, dbconn)
        {
            _context = context;
        }
        public List<User> GetAllUsers() => _context.Users.ToList();

        public User GetUserById(int id) => _context.Users.Find(id);

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}