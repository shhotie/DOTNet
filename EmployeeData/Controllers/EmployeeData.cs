using EmployeeData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeData.Controllers
{
    public class EmployeeData : Controller
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            List<Employee> empList = Employee.GetEmployeeDetails();
            return View(empList);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            Employee emp = Employee.GetEmployee(id);
            return View(emp);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee obj)
        {
            try
            {
                Employee.InsertUserData(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            Employee emp = Employee.GetEmployee(id);
            return View(emp);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee obj)
        {
            try
            {
                Employee.UpdateUserData(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            Employee emp = Employee.GetEmployee(id);
            return View(emp);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee obj)
        {
            try
            {
                Employee.DeleteUserData(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
