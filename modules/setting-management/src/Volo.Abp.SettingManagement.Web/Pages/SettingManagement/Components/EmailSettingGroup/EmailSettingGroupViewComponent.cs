﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.SettingManagement.Web.Pages.SettingManagement.Components.EmailSettingGroup;

public class EmailSettingGroupViewComponent : AbpViewComponent
{
    protected IEmailSettingsAppService EmailSettingsAppService { get; }

    public EmailSettingGroupViewComponent(IEmailSettingsAppService emailSettingsAppService)
    {
        ObjectMapperContext = typeof(AbpSettingManagementWebModule);
        EmailSettingsAppService = emailSettingsAppService;
    }

    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        var emailSettings = await EmailSettingsAppService.GetAsync();
        var model = ObjectMapper.Map<EmailSettingsDto, UpdateEmailSettingsDto>(emailSettings);
        return View("~/Pages/SettingManagement/Components/EmailSettingGroup/Default.cshtml", model);
    }
}
