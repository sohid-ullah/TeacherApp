using Autofac;
using Microsoft.AspNetCore.Mvc;
using TeacherApp.Business.Services;
using TeacherApp.Web.Models;
using TeacherApp.Web.Utilities;

namespace TeacherApp.Web.Controllers
{
    public class TeachersController : Controller
    {
        private ILifetimeScope _scope;
        private ILogger<TeachersController> _logger;

        public TeachersController(ILifetimeScope scope,
            ILogger<TeachersController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<CreateTeacherModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateTeacherModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                try
                {
                    model.CreateTeacher();

                    TempData.Put("Message", new ResponseModel
                    {
                        ResponseMessage = "Teacher Created Successfully",
                        ResponseType = ResponseTypes.Success
                    });
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData.Put("Message", new ResponseModel
                    {
                        ResponseMessage = ex.Message,
                        ResponseType = ResponseTypes.Danger
                    });
                    _logger.LogInformation(ex, ex.Message);
                }
            }
            return View();
        }
        public JsonResult GetTeachers()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            try
            {
                var model = _scope.Resolve<TeacherListModel>();
                var data = model.GetTeachers(dataTableModel);
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Json(string.Empty);

        }
        public IActionResult Delete(int id)
        {
            var model = _scope.Resolve<TeacherListModel>();
            try
            {
                model.DeleteTeacher(id);
                TempData.Put("Message", new ResponseModel
                {
                    ResponseMessage = "Teacher Deleted Successfully!",
                    ResponseType = ResponseTypes.Success
                });
            }
            catch (InvalidDataException ex)
            {
                TempData.Put("Message", new ResponseModel
                {
                    ResponseMessage = ex.Message,
                    ResponseType = ResponseTypes.Danger
                });
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _scope.Resolve<TeacherEditModel>();
            model.LoadData(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(TeacherEditModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                try
                {
                    model.EditCourse();
                    TempData.Put("Message", new ResponseModel
                    {
                        ResponseMessage = "Course Edited Successfully",
                        ResponseType = ResponseTypes.Success
                    });
                    return RedirectToAction("Index");
                }
                catch (DataNotFoundException ex)
                {
                    TempData.Put("Message", new ResponseModel
                    {
                        ResponseMessage = "The data is not available",
                        ResponseType = ResponseTypes.Danger
                    });
                    _logger.LogInformation(ex.Message);
                }
                catch (Exception ex)
                {
                    TempData.Put("Message", new ResponseModel
                    {
                        ResponseMessage = ex.Message,
                        ResponseType = ResponseTypes.Danger
                    });
                }
            }
            return View();
        }
    }
}
