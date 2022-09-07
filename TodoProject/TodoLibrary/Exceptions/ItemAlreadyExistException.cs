using System;
using System.Collections.Generic;
using System.Text;

namespace TodoLibrary.Exceptions
{
    internal class ItemAlreadyExistException:Exception
    {
        public ItemAlreadyExistException(string msg):base(msg)
        {

        }
    }
}
