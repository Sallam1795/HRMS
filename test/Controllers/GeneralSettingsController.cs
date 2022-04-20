using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using test.Data.Repository;
using test.Data.ViewModels;
using test.Models;
using test.Services;

namespace test.Controllers
{
    [Authorize]
    public class GeneralSettingsController : Controller
    {
        private readonly IGeneralSettingsService generalSettingsService;

        public GeneralSettingsController(IGeneralSettingsService generalSettingsService)
        {
            this.generalSettingsService = generalSettingsService;
        }

        [HttpGet]
        public IActionResult Index()
        {            
            return View(generalSettingsService.GSServiceIndex());
        }
      
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult UpdateWeeklyHoliday(GeneralSettingsViewModel generalSettingVM)
        {
            generalSettingsService.GSServiceUpdate(generalSettingVM);
            return RedirectToAction("Index");
        }

    }
}
