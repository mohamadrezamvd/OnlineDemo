using OnlineDemo.Models;

namespace OnlineDemo.Helpers
{
    public class OnlineUsersHelper
    {
        private Dictionary<User, DateTime> _users;
        
        public OnlineUsersHelper()
        {
            OnlineDemoDatabaseContext _context = new OnlineDemoDatabaseContext();
            _users= new Dictionary<User, DateTime>();
            foreach (var user in _context.Users)
            {
                _users.Add(user, DateTime.Now.AddDays(-1));
            }
        }

        public void Update(int userId)
        {
            var keys = _users.Keys.ToList();
            for (int i = 0; i < _users.Count; i++)
            {
                if (keys[i].UserId==userId)
                {
                    _users[keys[i]] = DateTime.Now;
                }
            }
        }

        public List<User> OnlineUsers
        {
            get
            {
                return _users.Where(u=>u.Value>DateTime.Now.AddSeconds(-5)).Select(u=>u.Key).ToList();
            }
        }
    }
}
