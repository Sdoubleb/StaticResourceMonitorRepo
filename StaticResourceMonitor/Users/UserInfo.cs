using System;

namespace StaticResourceMonitor.Users
{
    public class UserInfo
    {
        public UserInfo(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public override bool Equals(object obj)
            => obj is UserInfo aUser && Id == aUser.Id;

        public override int GetHashCode()
            => Id.GetHashCode();

        public override string ToString()
            => Id.ToString();
    }
}