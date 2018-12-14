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
        {
            if (obj is UserInfo)
            {
                var aUser = obj as UserInfo;
                return Id == aUser.Id;
            }
            return false;
        }

        public override int GetHashCode()
            => Id.GetHashCode();

        public override string ToString()
            => Id.ToString();
    }
}