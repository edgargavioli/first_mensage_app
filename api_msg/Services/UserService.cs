using api_msg.Models;
using api_msg.Context;
using api_msg.View;
using Microsoft.EntityFrameworkCore;

namespace api_msg.Services
{
    public class UserService
    {

        private readonly ApiContext _context;

        public UserService(ApiContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users
                .AsNoTracking()
                .ToList();
        }

        public User? GetUserByName(string name)
        {
            return _context.Users
                .Include(u => u.Mensagems)
                .AsNoTracking()
                .FirstOrDefault(u => u.Nome == name);
        }

        public User? GetUserById(int id)
        {
            return _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == id);
        }

        public void CreateUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public User UpdateUser(int id, User newUser)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return null;
            }

            user.Nome = newUser.Nome;
            user.Senha = newUser.Senha;
            user.Numero = newUser.Numero;

            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var deletedUser = _context.Users.Find(id);

            if (deletedUser == null)
            {
                return;
            }

            _context.Users.Remove(deletedUser);
            _context.SaveChanges();
        }

        public void AddMensage(int UserId, Mensagem newMensage)
        {
            var user = _context.Users.Find(UserId);
            if (user == null)
            {
                return;
            }

            user.Mensagems.Add(newMensage);
            _context.SaveChanges();
        }
    }
}
