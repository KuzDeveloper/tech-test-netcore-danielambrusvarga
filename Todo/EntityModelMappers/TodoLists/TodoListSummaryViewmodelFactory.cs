using System.Linq;
using System.Threading.Tasks;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public class TodoListSummaryViewmodelFactory
    {
        private readonly UserSummaryViewmodelFactory _userSummaryViewmodelFactory;

        public TodoListSummaryViewmodelFactory(UserSummaryViewmodelFactory userSummaryViewmodelFactory)
        {
            _userSummaryViewmodelFactory = userSummaryViewmodelFactory;
        }

        public async Task<TodoListSummaryViewmodel> Create(TodoList todoList)
        {
            var numberOfNotDoneItems = todoList.Items.Count(ti => !ti.IsDone);

            return new TodoListSummaryViewmodel(todoList.TodoListId,
                todoList.Title,
                numberOfNotDoneItems,
                await _userSummaryViewmodelFactory.Create(todoList.Owner));
        }
    }
}