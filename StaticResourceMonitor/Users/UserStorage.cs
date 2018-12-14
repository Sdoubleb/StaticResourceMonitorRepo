using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaticResourceMonitor.Users
{
    public class UserStorage
    {
        private ConcurrentDictionary<Guid, UserInfo> _users = new ConcurrentDictionary<Guid, UserInfo>();

        public void AddUser(UserInfo user)
        {
            if (_users.ContainsKey(user.Id))
                throw new InvalidOperationException();
            _users[user.Id] = user;
        }

        public UserInfo GetUser(Guid id)
        {
            UserInfo user;
            return _users.TryGetValue(id, out user) ? user : null;
        }
    }
}