﻿namespace ReactBlogApp.Server.Models
{
    //public class UserModel
    //{
    //    public Guid Id { get; set; }
    //    public string Email { get; set; }
    //    public string Password { get; set; }
    //}

    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

}
