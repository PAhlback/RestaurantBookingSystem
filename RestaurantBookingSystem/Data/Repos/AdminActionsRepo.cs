using RestaurantBookingSystem.Data.Repos.IRepos;

namespace RestaurantBookingSystem.Data.Repos
{
    public class AdminActionsRepo(ApplicationDbContext context) : IAdminActionsRepo
    {
        private readonly ApplicationDbContext _context = context;


    }
}
