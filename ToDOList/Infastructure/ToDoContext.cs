﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDOList.Models;

namespace ToDOList.Infastructure
{
    public class ToDoContext : DbContext
    {
        public ToDoContext (DbContextOptions<ToDoContext> options) : base(options)
        {

        }
        public DbSet<ToDo> ToDoList { get; set; }
    }
}
