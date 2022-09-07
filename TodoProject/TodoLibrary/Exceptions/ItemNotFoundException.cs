using System;
using System.Collections.Generic;
using System.Text;

namespace TodoLibrary.Exceptions
{
    internal class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string msg) : base(msg)
        {

        }
    }
}
