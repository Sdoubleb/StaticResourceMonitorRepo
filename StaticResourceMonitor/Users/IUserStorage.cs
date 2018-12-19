using System;

namespace StaticResourceMonitor.Users
{
    public interface IUserStorage
    {
        void AddUser(UserInfo user);

        UserInfo GetUser(Guid id);
    }
}