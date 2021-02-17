using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace projectnewgadi
{
    public class LoReUp
    {
        private string username;
        private string password;
        public LoReUp(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string GetUser() { return username; }
        public string Getpass() { return password; }

        public void SetPass(string pass) { this.password = pass; }
        public void Setuser(string username) { this.username = username; }

        public static bool Register(string username, string password)
        {
            if (IfUserExit(username) == false)
            {
                MySqlConnection conn = new MySqlConnection(Connection.user);
                string Query = $@"INSERT INTO users (username,password) VALUES ('{username}','{password}','');";
                MySqlCommand command = new MySqlCommand(Query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            return false;
        }
        public static LoReUp Login(string username, string password)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,password from users where username='{username}' and password='{password}';";
            MySqlCommand command = new MySqlCommand(Query, conn);
            LoReUp user = null;
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                string name = dr.GetString(1);
                string pass = dr.GetString(2);
                user = new LoReUp(name, pass);
            }
            conn.Close();
            return user;

        }
        public static bool IfUserExit(string username)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select username from users where username='{username}';";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read() == false)
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;
        }

        public static bool UpdatePassword(LoReUp user, string newpassword)
        {
            if (user != null)
            {
                MySqlConnection conn = new MySqlConnection(Connection.user);
                conn.Open();
                string Query = $@"UPDATE users SET password='{newpassword}' WHERE username='{user.GetUser()}';";
                MySqlCommand command = new MySqlCommand(Query, conn);
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            return false;
        }
    }
}