using System;
using System.Collections.Concurrent;

namespace StaticResourceMonitor.Users
{
    public class UserStorage : IUserStorage
    {
        private const int INITIAL_CAPACITY = Byte.MaxValue + 1;

        private ConcurrentDictionary<Guid, UserInfo> _users
            = new ConcurrentDictionary<Guid, UserInfo>(Environment.ProcessorCount, INITIAL_CAPACITY);

        public UserInfo GetOrAddUser(Guid id)
        {
            return _users.GetOrAdd(id, key => new UserInfo(key));
        }
    }
}