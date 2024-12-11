using On_call_masters1.Core;
using On_call_masters1.BLL;
using On_call_masters1DAL;
namespace On_call_masters1.BLL
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(User user)
        {
            _userRepository.AddUser(user);
        }
    }
}
