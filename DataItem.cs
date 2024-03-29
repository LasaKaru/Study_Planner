namespace Study_Planner
{
    public class DataItem
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public DataItem(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}