using System.Collections.Generic;

namespace Login_and_Regiser.UsersFolder
{
    class Users
    {
        public static List<User> users = new();
        public void Add(string name, string pass) =>
            Add(new User()
            {
                Name = name,
                Password = pass
            });
        void Add(User u) => users.Add(u);
    }
}
