using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/*namespace Study_Planner
{
    public class UserService
    {
        private readonly Dictionary<string, string> _users;

        public UserService()
        {
            _users = new Dictionary<string, string>();

            // In a real application, you would retrieve user data from a database
            // For demonstration purposes, we'll hardcode some user data
            _users.Add("user1", EncryptPassword("password1"));
            _users.Add("user2", EncryptPassword("password2"));
        }

        public bool AuthenticateUser(string username, string password)
        {
            if (_users.ContainsKey(username))
            {
                string hashedPassword = EncryptPassword(password);
                return _users[username] == hashedPassword;
            }
            return false;
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        internal bool UserExists(string username)
        {
            //throw new NotImplementedException();
            return _users.ContainsKey(username);
        }

        internal void AddUser(string username, string password)
        {
            //throw new NotImplementedException();
            _users.Add(username, EncryptPassword(password));
        }
    }
}          

        /*
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>();
        }

        public bool AuthenticateUser(string username, string password)
        {
            User user = _users.Find(u => u.Username == username);
            if (user != null)
            {
                string hashedPassword = EncryptPassword(password);
                return user.Password == hashedPassword;
            }
            return false;
        }

        public bool UserExists(string username)
        {
            return _users.Exists(u => u.Username == username);
        }

        public void AddUser(string username, string password)
        {
            _users.Add(new User(username, EncryptPassword(password)));
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private class User
        {
            public string Username { get; }
            public string Password { get; }

            public User(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }
    }
}

*/


/*
namespace Study_Planner
{
    public class UserService
    {
        private readonly Dictionary<string, string> _users;

        public UserService()
        {
            _users = new Dictionary<string, string>();

            // In a real application, you would retrieve user data from a database
            // For demonstration purposes, we'll hardcode some user data
            _users.Add("user1", EncryptPassword("password1"));
            _users.Add("user2", EncryptPassword("password2"));
            _users.Add("lasa", EncryptPassword("12345"));
        }

        public bool AuthenticateUser(string username, string password)
        {
            if (_users.ContainsKey(username))
            {
                string hashedPassword = EncryptPassword(password);
                return _users[username] == hashedPassword;
            }
            return false;
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        internal bool UserExists(string username)
        {
            return _users.ContainsKey(username);
        }

        internal void AddUser(string username, string password)
        {
            _users.Add(username, EncryptPassword(password));
        }
    }
}

*/
namespace Study_Planner
{
    public class UserService
    {
        private readonly Dictionary<string, string> _users;

        public UserService()
        {
            _users = LoadUsersFromFile("users.txt");
        }

        public bool AuthenticateUser(string username, string password)
        {
            if (_users.ContainsKey(username))
            {
                string hashedPassword = EncryptPassword(password);
                return _users[username] == hashedPassword;
            }
            return false;
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        internal bool UserExists(string username)
        {
            return _users.ContainsKey(username);
        }

        internal void AddUser(string username, string password)
        {
            _users.Add(username, EncryptPassword(password));
            SaveUsersToFile("users.txt", _users);
        }

        private Dictionary<string, string> LoadUsersFromFile(string filename)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        users.Add(parts[0], parts[1]);
                    }
                }
            }
            return users;
        }

        private void SaveUsersToFile(string filename, Dictionary<string, string> users)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var user in users)
                {
                    writer.WriteLine($"{user.Key},{user.Value}");
                }
            }
        }
    }
}