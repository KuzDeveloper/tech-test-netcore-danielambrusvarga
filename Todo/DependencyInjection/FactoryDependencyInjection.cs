using Microsoft.Extensions.DependencyInjection;
using Todo.EntityModelMappers.TodoItems;
using Todo.EntityModelMappers.TodoLists;

namespace Todo.DependencyInjection
{
    public static class FactoryDependencyInjection
    {
        public static IServiceCollection AddCustomFactories(this IServiceCollection services)
        {
            return services
                .AddScoped<TodoListIndexViewmodelFactory>()
                .AddScoped<TodoListSummaryViewmodelFactory>()
                .AddScoped<TodoListDetailViewmodelFactory>()
                .AddScoped<TodoItemSummaryViewmodelFactory>()
                .AddScoped<UserSummaryViewmodelFactory>();
        }
    }
}
