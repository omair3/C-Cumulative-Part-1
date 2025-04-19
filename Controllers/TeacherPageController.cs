using C__Cumulative_Part_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace C__Cumulative_Part_1.Controllers
{
    public class TeacherPageController : Controller
    {
        
        private readonly TeacherAPIController _api;

        public TeacherPageController()
        {
            _api = new TeacherAPIController(); 
        }

        /// <summary>
        /// Displays a list of all teachers on a dynamic page.
        /// </summary>
        /// <returns>A view with all teacher records.</returns>
        // GET: /TeacherPage/List
        public IActionResult List()
        {
            List<Teacher> Teachers = _api.ListTeacherRecords();
            return View(Teachers);
        }

        /// <summary>
        /// Displays detailed information for a specific teacher.
        /// </summary>
        /// <param name="id">The ID of the teacher to display.</param>
        /// <returns>A view with the teacher's details.</returns>
        // GET: /TeacherPage/Show/{id}
        public IActionResult Show(int id)
        {
            Teacher SelectedTeacher = _api.FindTeacher(id);
            return View(SelectedTeacher);
        }

    }
}