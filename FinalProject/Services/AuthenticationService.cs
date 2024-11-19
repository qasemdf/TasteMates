using System;
using FinalProject.Models;
namespace FinalProject
{
	public class AuthenticationService
	{
        private static AuthenticationService _instance;
        public static AuthenticationService Instance => _instance ??= new AuthenticationService();

        public Users CurrentUser { get; private set; } 

        public bool Login(string username, string password)
        {
            try
            {
                DB.OpenConnection();
                CurrentUser = DB.conn.Table<Users>().FirstOrDefault(u => u.username == username && u.password == password);

                DB.conn.Close();

                return CurrentUser != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Login method: {ex.Message}");
                return false;
            }
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}

