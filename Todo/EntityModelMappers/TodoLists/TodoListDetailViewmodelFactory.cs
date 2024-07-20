using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public class TodoListDetailViewmodelFactory
    {
        private readonly TodoItemSummaryViewmodelFactory _todoItemSummaryViewmodelFactory;

        public TodoListDetailViewmodelFactory(TodoItemSummaryViewmodelFactory todoItemSummaryViewmodelFactory)
        {
            _todoItemSummaryViewmodelFactory = todoItemSummaryViewmodelFactory;
        }

        public async Task<TodoListDetailViewmodel> Create(TodoList todoList)
        {
            var items = todoList?.Items;

            if (items == null || !items.Any())
            {
                return null;
            }

            List<TodoItemSummaryViewmodel> todoItemSummaryViewmodels = new List<TodoItemSummaryViewmodel>();

            foreach (var item in items)
            {
                todoItemSummaryViewmodels.Add(await _todoItemSummaryViewmodelFactory.Create(item));
            }

            return new TodoListDetailViewmodel(todoList.TodoListId,
                todoList.Title,
                todoItemSummaryViewmodels
                    .OrderBy(t => t.Importance)
                    .ToList());
        }
    }
}