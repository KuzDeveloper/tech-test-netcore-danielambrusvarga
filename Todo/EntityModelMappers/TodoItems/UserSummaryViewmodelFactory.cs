using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Todo.Models.TodoItems;
using Todo.Services;

namespace Todo.EntityModelMappers.TodoItems
{
    public class UserSummaryViewmodelFactory
    {
        private readonly IGravatarService _gravatarService;

        public UserSummaryViewmodelFactory(IGravatarService gravatarService)
        {
            _gravatarService = gravatarService;
        }

        public async Task<UserSummaryViewmodel> Create(IdentityUser identityUser)
        {
            UserSummaryViewmodel userSummaryViewmodel = null;

            try
            {
                var gravatarProfile = await _gravatarService.GetGravatarProfileAsync(identityUser.Email);

                if (gravatarProfile != null)
                {
                    userSummaryViewmodel = new UserSummaryViewmodel(gravatarProfile.DisplayName, identityUser.Email);
                }
            }
            catch(Exception ex)
            {
                // Log exception ...
            }
            finally
            {
                if (userSummaryViewmodel == null)
                {
                    userSummaryViewmodel = new UserSummaryViewmodel(identityUser.UserName, identityUser.Email);
                }
            }

            return userSummaryViewmodel;
        }
    }
}