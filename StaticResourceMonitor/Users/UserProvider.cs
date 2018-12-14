using System;
using System.Web;

namespace StaticResourceMonitor.Users
{
    public class UserProvider
    {
        private const string USER_COOKIE_NAME = "user-id";

        private readonly HttpContextBase _context;
        private readonly UserStorage _storage;

        public UserProvider(HttpContextBase context, UserStorage storage)
        {
            _context = context;
            _storage = storage;
        }

        public UserInfo ProvideUser()
        {
            Guid userId;
            if (!Guid.TryParse(GetUserIdFromCookie(), out userId))
            {
                userId = Guid.NewGuid();
                SetUserIdIntoCookie(userId.ToString());
            }

            UserInfo user = _storage.GetUser(userId);
            if (user == null)
            {
                user = new UserInfo(userId);
                _storage.AddUser(user);
            }

            return user;
        }

        private string GetUserIdFromCookie()
        {
            return _context.Request.Cookies[USER_COOKIE_NAME]?.Value;
        }

        private void SetUserIdIntoCookie(string userId)
        {
            var cookie = new HttpCookie(USER_COOKIE_NAME, userId)
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddYears(1)
            };
            _context.Response.Cookies.Add(cookie);
        }
    }
}