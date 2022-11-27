using Blogi.Application.Features.Contacts.Commands.Create;
using Blogi.Application.Features.Contacts.Commands.Update;
using Blogi.Application.Features.Contacts.Queries.GetList;
using Blogi.Application.Features.Contacts.Commands.Delete;
using Blogi.Application.Features.Contacts.Queries.Get;
using Blogi.Application.Features.Languages.Queries.GetList;
using Blogi.Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    public class ContactController : BaseController
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var languageList = await Mediator.Send(new GetListLanguageQuery());
            var model = new ContactCreateViewModel
            {
                LanguageList = languageList.Data,
                ContactCommand = new CreateContactCommand()
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactCreateViewModel input)
        {
            var result = await Mediator.Send(input.ContactCommand);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Contact");
            }
            else
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var model = new ContactCreateViewModel
                {
                    LanguageList = languageList.Data,
                    ContactCommand = input.ContactCommand
                };

                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(GetContactQuery input)
        {
            var result = await Mediator.Send(input);
            var languageList = await Mediator.Send(new GetListLanguageQuery());
            var model = new ContactEditViewModel();

            if (result.Success)
            {
                model.Contact = result.Data;
                model.LanguageList = languageList.Data;
                return View(model);
            }
            else
            {
                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactEditViewModel input)
        {
            var result = await Mediator.Send(new UpdateContactCommand
            {
                Id = input.Contact.Id,
                Content = input.Contact.Content,
                Email = input.Contact.Email,
                LanguageId = input.Contact.LanguageId,
                Location = input.Contact.Location,
                MetaDescription = input.Contact.MetaDescription,
                MetaKeywords = input.Contact.MetaKeywords,
                Phone = input.Contact.Phone,
                Slug = input.Contact.Slug,
                Title = input.Contact.Title
            });
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Contact");
            }
            else
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var model = new ContactEditViewModel
                {
                    LanguageList = languageList.Data,
                    Contact = input.Contact
                };

                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(DeleteContactCommand input)
        {
            var result = await Mediator.Send(input);
            return Json(new { data = result });

        }

        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListContactQuery());
            return Json(new { data = result.Data });
        }
    }
}