using System.Threading.Tasks;
using Todo.Data.Entities;
using Todo.Models.TodoItems;

namespace Todo.EntityModelMappers.TodoItems
{
    public class TodoItemSummaryViewmodelFactory
    {
        private readonly UserSummaryViewmodelFactory _userSummaryViewmodelFactory;

        public TodoItemSummaryViewmodelFactory(UserSummaryViewmodelFactory userSummaryViewmodelFactory)
        {
            _userSummaryViewmodelFactory = userSummaryViewmodelFactory;
        }

        public async Task<TodoItemSummaryViewmodel> Create(TodoItem ti)
        {
            UserSummaryViewmodel userSummaryViewmodel = null;

            try
            {
                userSummaryViewmodel = await _userSummaryViewmodelFactory.Create(ti.ResponsibleParty);
            }
            catch
            {
                userSummaryViewmodel = new UserSummaryViewmodel(ti.ResponsibleParty.UserName, ti.ResponsibleParty.Email);
            }

            return new TodoItemSummaryViewmodel(ti.TodoItemId, ti.Title, ti.IsDone, userSummaryViewmodel, ti.Importance);
        }
    }
}