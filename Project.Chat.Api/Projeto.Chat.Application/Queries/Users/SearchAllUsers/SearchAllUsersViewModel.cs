﻿namespace Projeto.Chat.Application.Queries.Users.SearchAllUsers
{
    public class SearchAllUsersViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public SearchAllUsersViewModel(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;    
        }
    }
}
