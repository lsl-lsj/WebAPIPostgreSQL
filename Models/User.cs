namespace WebAPI04PostgreSQL.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"[Username : '{Username}' , Password : '{Password}' , Age : '{Age}' , Gender : '{Gender}']";
        }
    }

}