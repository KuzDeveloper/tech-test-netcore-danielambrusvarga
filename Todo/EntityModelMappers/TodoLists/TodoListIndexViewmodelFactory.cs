using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Data.Entities;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public class TodoListIndexViewmodelFactory
    {
        private readonly TodoListSummaryViewmodelFactory _todoListSummaryViewmodelFactory;

        public TodoListIndexViewmodelFactory(TodoListSummaryViewmodelFactory todoListSummaryViewmodelFactory)
        {
            _todoListSummaryViewmodelFactory = todoListSummaryViewmodelFactory;
        }

        public async Task<TodoListIndexViewmodel> Create(IEnumerable<TodoList> todoLists)
        {
            List<TodoListSummaryViewmodel> todoListSummaryViewmodels = new List<TodoListSummaryViewmodel>();

            foreach (var todoList in todoLists)
            {
                todoListSummaryViewmodels.Add(await _todoListSummaryViewmodelFactory.Create(todoList));
            }

            return new TodoListIndexViewmodel(todoListSummaryViewmodels);
        }
    }
}