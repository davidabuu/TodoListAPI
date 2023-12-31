﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Model;

namespace TodoListAPI.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public DbSet<Todo> Todo { get; set; }  

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) {
        }

    }
}
