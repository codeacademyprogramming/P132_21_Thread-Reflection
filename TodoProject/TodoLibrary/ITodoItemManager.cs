using System;
using System.Collections.Generic;
using System.Text;
using TodoLibrary.Enums;

namespace TodoLibrary
{
    internal interface ITodoItemManager
    {
        List<TodoItem> Items { get; }
        void AddTodoItem(TodoItem item);

        List<TodoItem> GetAllItems();
        
        List<TodoItem> GetAllDelayedItems();
        void ChangeItemStatus(int no, TodoStatus status);
        void EditItem(int no, string title = null, string desc = null, DateTime? deadline = null);
        void DeleteItem(int no);
        List<TodoItem> GetAllItemsByStatus(TodoStatus status);

        List<TodoItem> Search(string src);
        List<TodoItem> Filter(DateTime from, DateTime to, TodoStatus? status=null);
    }
}
