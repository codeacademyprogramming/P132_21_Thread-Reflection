using System;
using System.Collections.Generic;
using System.Text;
using TodoLibrary.Enums;
using TodoLibrary.Exceptions;

namespace TodoLibrary
{
    internal class TodoManager : ITodoItemManager
    {
        private List<TodoItem> _items = new List<TodoItem>();
        public List<TodoItem> Items { get => _items; }

        public void AddTodoItem(TodoItem item)
        {
            if (_items.Exists(x => x.No == item.No))
                throw new ItemAlreadyExistException($"{item.No} nomreli item movcuddur!");

            _items.Add(item);
        }

        public void ChangeItemStatus(int no, TodoStatus status)
        {
            TodoItem item = GetItem(x => x.No == no);

            if(item.Status != status)
            {
                item.Status = status;
                item.StatusChangedAt = DateTime.Now;
            }
        }

        public void DeleteItem(int no)
        {
            TodoItem item = GetItem(x => x.No == no);

            _items.Remove(item);
        }

        public void EditItem(int no, string title = null, string desc = null, DateTime? deadline = null)
        {
            TodoItem item = _items.Find(x => x.No == no);
            if (item == null)
                throw new ItemNotFoundException($"{item.No} nomreli item yoxdur!");

            if (title != null)
                item.Title = title;

            if (desc != null)
                item.Description = desc;

            if(deadline != null)
                item.Deadline = (DateTime)deadline;
        }

        public List<TodoItem> Filter(DateTime from, DateTime to, TodoStatus? status = null)
        {
            if (status == null)
                return _items.FindAll(x => x.Deadline >= from && x.Deadline <= to);
            else
                return _items.FindAll(x => x.Status == status && x.Deadline >= from && x.Deadline <= to);
        }

        public List<TodoItem> GetAllDelayedItems()
        {
            return _items.FindAll(x => x.Deadline < DateTime.Now && x.Status != TodoStatus.Done);
        }

        public List<TodoItem> GetAllItems()
        {
            return _items;
        }

        public List<TodoItem> GetAllItemsByStatus(TodoStatus status)
        {
            return _items.FindAll(x => x.Status == status);
        }

        public List<TodoItem> Search(string src)
        {
            src = src.ToLower();
            return _items.FindAll(x => x.Title.ToLower().Contains(src));
        }

        private TodoItem GetItem(Predicate<TodoItem> pr)
        {
            TodoItem item = _items.Find(pr);
            if (item == null)
                throw new ItemNotFoundException($"{item.No} nomreli item yoxdur!");

            return item;
        }
    }
}
