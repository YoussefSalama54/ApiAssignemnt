﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAssignment.Logic.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
