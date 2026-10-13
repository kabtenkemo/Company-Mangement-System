using Company_Mangement_System.Data;
using Company_Mangement_System.Models;
using Company_Mangement_System.Repo.Interface;

namespace Company_Mangement_System.Repo.Impelementation
{
    public class UserRepo:GenericRepo<ApplicationUser>,IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            var users = _context.ApplicationUsers.FirstOrDefault(u => u.Email == email);
            return await Task.FromResult(users);
        }
    }
}
