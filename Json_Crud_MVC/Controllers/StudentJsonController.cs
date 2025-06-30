using Json_Crud_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Json_Crud_MVC.Controllers
{
    public class StudentJsonController : Controller
    {

        studentEntities db=new studentEntities();

        // GET: StudentJson
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStudents()
        {
            List<student> std = db.students.ToList();
            return Json(std, JsonRequestBehavior.AllowGet);
        }

        public string AddStudent(student s)
        {
            db.students.Add(s);
            db.SaveChanges();
            return "Student Added Successfully";

        }

        public JsonResult GetStudentById(int id)
        {
            student st = db.students.Find(id);
            return Json(st, JsonRequestBehavior.AllowGet);

        }


        public string UpdateStudent(student s)
        {
            db.Entry<student>(s).State=EntityState.Modified;
            db.SaveChanges();
            return "Student Updated Successfully";
        }

        public string DeleteStudent(int id)
        {
            student st = db.students.Find(id);
            db.students.Remove(st);
            db.SaveChanges();
            return "Student Deleted Successfully";

        }

    }
}