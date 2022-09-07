using System;
using System.Collections.Generic;
using System.Text;
using TodoLibrary.Enums;

namespace TodoLibrary
{
    public class TodoItem
    {
        private static int _totalCount;
        public TodoItem()
        {
            _totalCount++;
            No = _totalCount;
        }
        public int No { get; }
        public TodoStatus Status;
        public string Title;
        public string Description;
        public DateTime Deadline;
        public DateTime StatusChangedAt;
    }
}
