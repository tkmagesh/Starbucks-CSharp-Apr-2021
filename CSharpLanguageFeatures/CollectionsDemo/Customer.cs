﻿using System;
namespace CollectionsDemo
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}\tFirstName = {FirstName}\tLastName = {LastName}";
        }
    }
}
