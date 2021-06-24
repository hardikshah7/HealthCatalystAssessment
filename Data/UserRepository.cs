using HealthCatalystAssessment.Models;

namespace HealthCatalystAssessment.Data
{
    public interface IUserRepository : IRepository<User>
    {

    }
    public class UserRepository : Repository<User, HealthCatalystAssessmentContext>, IUserRepository
    {
        public UserRepository(HealthCatalystAssessmentContext context) : base(context)
        {
        }

        // We can add new methods specific to the user repository here in the future
    }
}

