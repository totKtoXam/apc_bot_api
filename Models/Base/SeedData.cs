using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace apc_bot_api.Models.Base
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var _dbContext = serviceProvider.GetRequiredService<AppDbContext>();
            var _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // _dbContext.Database.EnsureDeleted();
            // _dbContext.Database.EnsureCreated();

            #region Roles
            var newRoles = new List<string>()
            {
                "admin", "teacher", "student", "enrollee"
            };
            var roles = _roleManager.Roles.Select(x => x.Name).ToList();
            var rolesDiff = newRoles.Except(roles).ToList();
            if (rolesDiff.Count() > 0)
            {
                foreach(var value in rolesDiff)
                {
                    var role = new IdentityRole { Name = value };
                    var asyncTask = _roleManager.CreateAsync(role);
                    asyncTask.Wait();
                }
            }
            #endregion

            #region Sections
            // var regSection = _dbContext.Sections.FirstOrDefault(x => x.NameTitle == SectionTitles.regTitle);
            // if (regSection == null)
            // {
            //     regSection = new Section
            //     {
            //         NameTitle = SectionTitles.regTitle,
            //         Content = "Здравствуйте!"
            //     };
            //     _dbContext.Sections.Add(regSection);
            // }
            #endregion

            #region Steps

            #region  StartStep
            var startStep = _dbContext.Steps.FirstOrDefault(x => x.Code == StepConstants._START_);
            if (startStep == null)
            {
                startStep = new Step
                {
                    Name = "Здравствуйте! Выберите свою роль:",
                    Code = StepConstants._START_,
                    Condition = "ON_START"
                };
                _dbContext.Steps.Add(startStep);
            }
            #endregion
            
            #region EmailConfirmStep
            var emailEnterStep = _dbContext.Steps.FirstOrDefault(x => x.Code == StepConstants._EMAIL_ENTER_);
            if (emailEnterStep == null)
            {
                emailEnterStep = new Step
                {
                    Name = "Введите актуальный электронный адрес Вашей почты:",
                    Code = StepConstants._EMAIL_ENTER_,
                    Condition = StepConstants._EMAIL_ENTER_
                };
                _dbContext.Steps.Add(emailEnterStep);
            }
            #endregion

            #endregion

            #region BotActions
            #region RolesButtons
            var studentRoleSelectButton = _dbContext.BotActions.FirstOrDefault(x => x.Code == ActionConstants.ROLE_IS_STUDENT);
            if (studentRoleSelectButton == null)
            {
                studentRoleSelectButton = new BotAction
                {
                    Name = "студент",
                    Code = ActionConstants.ROLE_IS_STUDENT,
                    Condition = ActionConstants.ROLE_IS_STUDENT,
                    PrevStep = startStep,
                    NextStep = emailEnterStep,
                    IsEdit = true
                };
                _dbContext.BotActions.Add(studentRoleSelectButton);
            }

            var teacherRoleSelectButton = _dbContext.BotActions.FirstOrDefault(x => x.Code == ActionConstants.ROLE_IS_TEACHER);
            if (teacherRoleSelectButton == null)
            {
                teacherRoleSelectButton = new BotAction
                {
                    Name = "преподаватель",
                    Code = ActionConstants.ROLE_IS_TEACHER,
                    Condition = ActionConstants.ROLE_IS_TEACHER,
                    PrevStep = startStep,
                    NextStep = emailEnterStep,
                    IsEdit = true
                };
                _dbContext.BotActions.Add(teacherRoleSelectButton);
            }

            var enrolleeRoleSelectButton = _dbContext.BotActions.FirstOrDefault(x => x.Code == ActionConstants.ROLE_IS_ENROLLEE);
            if (enrolleeRoleSelectButton == null)
            {
                enrolleeRoleSelectButton = new BotAction
                {
                    Name = "абитуриент",
                    Code = ActionConstants.ROLE_IS_ENROLLEE,
                    Condition = ActionConstants.ROLE_IS_ENROLLEE,
                    PrevStep = startStep,
                    NextStep = emailEnterStep,
                    IsEdit = true
                };
                _dbContext.BotActions.Add(enrolleeRoleSelectButton);
            }
            #endregion

            #endregion
            _dbContext.SaveChanges();
        }
    }
}