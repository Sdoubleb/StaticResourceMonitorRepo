using System;

namespace StaticResourceMonitor.Users
{
    public interface IUserStorage
    {
        UserInfo GetOrAddUser(Guid id);
    }
}