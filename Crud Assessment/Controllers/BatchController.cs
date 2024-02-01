using Crud_Assessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Assessment.Controllers
{
    public class BatchController : Controller
    {
        static List<Batch> list = null;
        public BatchController()
        {
            if (list == null)
            {
                list = new List<Batch>()
            {
       new Batch() { Id =1, Name="Saurav", batch="B001", Address="Lucknow" , Dob=DateTime.Parse("12/02/2003")},

        new Batch() { Id =2, Name="Animesh", batch="B001", Address="lucknow" , Dob=DateTime.Parse("12/02/2006")},

        new Batch() { Id =3, Name="Chirag", batch="B003", Address="Delhi" , Dob=DateTime.Parse("12/02/2007")}
            };
            }
        }
        [HttpPost]
        public JsonResult UniqueIDValue(Batch stu)
        {
            return Json(!list.Any(x => x.Id == stu.Id));
        }
        public IActionResult Index()
        {

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Batch student)
        {
            list.Add(student);
            //return View();
            return RedirectToAction("Index");

        }

        public IActionResult Display(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var student = list.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(student);
            }


        }
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var student = list.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(student);
            }


        }
        [HttpPost]
        public IActionResult Delete(Batch student, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
                list.Remove(temp);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var student = list.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(student);
            }

        }

        [HttpPost]
        public IActionResult Edit(Batch student, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                foreach (Batch stu in list)
                {
                    if (stu.Id == temp.Id)
                    {
                        stu.batch = student.batch;
                        stu.Address = student.Address;
                        stu.Name= student.Name;
                        stu.Dob = student.Dob;
                        break;
                    }


                }
            }
            return RedirectToAction("Index");

        }


    }
}


