using Microsoft.AspNetCore.Cors.Infrastructure;
using TeacherApp.Business.Services;

namespace TeacherApp.Web.Models
{
    public class TeacherListModel
    {
        private ITeacherService _teacherService;

        public TeacherListModel(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        internal object GetTeachers(DataTablesAjaxRequestModel model)
        {
            var data = _teacherService.
                GetTeachers(model.PageIndex, model.PageSize, model.SearchText, 
                model.GetSortText(new string[] { "Name", "Address","Tel" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Address.ToString(),
                                record.Tel.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
        public void DeleteTeacher(int id)
        {
            _teacherService.DeleteTeacher(id);
        }
    }
}
