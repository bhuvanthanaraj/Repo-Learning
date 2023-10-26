using Learning.DataDBContext;
using Learning.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning.Controllers
{
    public class AdminController : Controller

    {
        private readonly LearningDbContext learningDbContext;

        public AdminController(LearningDbContext learningDbContext)
        {
            this.learningDbContext = learningDbContext;
        }




        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }





        [HttpPost]
        [ActionName("Add")]

        public IActionResult Add(Tag tag)
        {
            var tem = new Tag
            {
                Name = tag.Name,
                Description = tag.Description,
            };

            learningDbContext.Tags.Add(tem);
            learningDbContext.SaveChanges();

            return RedirectToAction("List");
        }






        [HttpGet]
        [ActionName("List")]
        public IActionResult List()
        {
            var tem = learningDbContext.Tags.ToList();
            return View(tem);
        }






        [HttpGet]
        public IActionResult Edit( Guid ID)

        { 
            var tem= learningDbContext.Tags.Find(ID);

            if (tem != null)
            {
                var tag = new Tag
                {
                    ID = tem.ID,
                    Name = tem.Name,
                    Description = tem.Description,

                };
                return View(tag);
            }
            return View(null); 
        }






        [HttpPost]
        public IActionResult Edit(Tag tag)
        {
            var tem = new Tag
            {
                Name = tag.Name,
                Description = tag.Description,
            };

            var extag= learningDbContext.Tags.Find(tag.ID);
            if (extag != null)
            {
                extag.Name = tag.Name;
                extag.Description = tag.Description;


                learningDbContext.SaveChanges();
                return RedirectToAction("List");
            }

            return View(null);

           
        }





        [HttpPost]
        public ActionResult Delete(Tag tag)
        {
            // Find the item to delete
            var itemToDelete = learningDbContext.Tags.Find(tag.ID);

            if (itemToDelete != null)
            {
                learningDbContext.Tags.Remove(itemToDelete);
                learningDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            //rediract to edit page and view the paticular id details..what we want to delete
            return RedirectToAction("Edit", new {ID=tag.ID});

        }











    }
}
