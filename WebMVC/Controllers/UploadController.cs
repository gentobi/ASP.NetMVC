using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileNameExtend = Path.GetExtension(file.FileName);
                    var newFileName = Guid.NewGuid()+_FileNameExtend;

                    string _path = Path.Combine(Server.MapPath("~/App_Data"), newFileName);

                    file.SaveAs(_path);
                    ViewBag.Filename = newFileName;
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch (Exception e)
            {

                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        public ActionResult SaveFileToDb(string fileName)
        {
            var filePath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

            var file = System.IO.File.ReadAllBytes(filePath);

            return null;
        }
    }
}
