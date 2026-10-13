using Company_Mangement_System.Models;

namespace Company_Mangement_System.Repo.Interface
{
    public interface IUserRepo:IGenericRepo<ApplicationUser>
    {
        Task<ApplicationUser> GetByEmailAsync(string email);
    }
}
