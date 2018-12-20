using System;
using System.Web;

namespace StaticResourceMonitor.Users
{
    public class CookieUserProvider : IUserProvider
    {
        private const string USER_COOKIE_NAME = "user-id";

        private readonly HttpContextBase _context;
        private readonly IUserStorage _storage;

        public CookieUserProvider(HttpContextBase context, IUserStorage storage)
        {
            _context = context;
            _storage = storage;
        }

        public UserInfo ProvideUser()
        {
            if (!Guid.TryParse(GetUserIdFromCookie(), out Guid userId))
                userId = Guid.NewGuid();
            SetUserIdIntoCookie(userId.ToString());

            UserInfo user = _storage.GetOrAddUser(userId);
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