using System;
using System.Collections.Generic;
using System.Text;

namespace Liberary.Bussniess
{
    public class Person
    {

        private static int _nextId = 1;
        public int Id { get;}
        public string FullName { get;}
        public string PhoneNumber { get;}

        protected Person( string fullName, string phoneNumber)
        {
            Id = _nextId++;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }



    }
}
