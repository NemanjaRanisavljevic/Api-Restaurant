using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.HTTPDTO;
using Application.Commands.MealCommand;
using Application.Commands.MeniCommand;
using Application.DTO.MeniDTO;
using Application.DTO.WebDTO;
using Application.Exceptions;
using Application.Helpers;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    public class MeniController : Controller
    {
        private IAddMeniCommand _addMeniCommand;
        private IGetMeniCommand _getMeniCommand;
        private IGetMeniesCommand _getMeniesCommand;
        private IEditMeniCommand _editMeniCommand;
        private IDeleteMeniCommand _deleteMeniCommand;
        private IGetAllMeniesCommandWeb _getAllMeniesCommandWeb;
        private IGetMeniWebCommand _getOneMeniCommand;
        private IGetEditMeniCommand _getEditMeniCommand;
        private IGetWebMealsCommand _getWebMeals;

        public MeniController(IAddMeniCommand addMeniCommand, IGetMeniCommand getMeniCommand, IGetMeniesCommand getMeniesCommand, IEditMeniCommand editMeniCommand, IDeleteMeniCommand deleteMeniCommand, IGetAllMeniesCommandWeb getAllMeniesCommandWeb, IGetMeniWebCommand getOneMeniCommand, IGetEditMeniCommand getEditMeniCommand, IGetWebMealsCommand getWebMeals)
        {
            _addMeniCommand = addMeniCommand;
            _getMeniCommand = getMeniCommand;
            _getMeniesCommand = getMeniesCommand;
            _editMeniCommand = editMeniCommand;
            _deleteMeniCommand = deleteMeniCommand;
            _getAllMeniesCommandWeb = getAllMeniesCommandWeb;
            _getOneMeniCommand = getOneMeniCommand;
            _getEditMeniCommand = getEditMeniCommand;
            _getWebMeals = getWebMeals;
        }



        // GET: Meni
        public ActionResult Index(MeniSearchWeb request)
        {
            var obj = _getAllMeniesCommandWeb.Execute(request);
            return View(obj);
        }

        // GET: Meni/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var obj = _getOneMeniCommand.Execute(id);
                return View(obj);
            }catch(NotFoundException)
            {
                return NotFound();
            }
            
        }

        // GET: Meni/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Meni/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] HttpSlikaDTO p)
        {

            var ext = Path.GetExtension(p.Image.FileName); //daje ekstenziju .jpg

            if (!FileUpload.AllowExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }


            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;//unique za ime fajla

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);

                p.Image.CopyTo(new FileStream(filePath, FileMode.Create));


                var dto = new MeniAddDTO
                {
                    NameFood = p.NameFood,
                    Ingradiant = p.Ingradiant,
                    FileName = newFileName,
                    Price = p.Price,
                    MealId = p.MealId
                };

                _addMeniCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                
                TempData["error"] = "Meal of food not found";
            }
            catch (AlredyExistException)
            {
                TempData["error"] = "Name of food alredy exist";
                
            }
            catch (Exception)
            {

                return StatusCode(500, "Server error try later");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Meni/Edit/5
        public ActionResult Edit(int id, ClassForNullObj request)
        {
            var obj = _getEditMeniCommand.Execute(id);
            
            return View(obj);
        }

        // POST: Meni/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[FromForm] HttpEditMeni p)
        {
            var ext = Path.GetExtension(p.Image.FileName); //daje ekstenziju .jpg

            if (!FileUpload.AllowExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }

            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;//unique za ime fajla

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);

                p.Image.CopyTo(new FileStream(filePath, FileMode.Create));


                var dto = new MeniAddDTO
                {
                    Id = p.Id,
                    NameFood = p.NameFood,
                    Ingradiant = p.Ingradiant,
                    FileName = newFileName,
                    Price = p.Price,
                    MealId = p.MealId
                };

                _editMeniCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return StatusCode(404, "Meal id not found or id of meni");
            }
            catch (AlredyExistException)
            {
                return StatusCode(422, "Name of food alredy exist");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error try later");
            }
        }

        // GET: Meni/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteMeniCommand.Execute(id);
                return RedirectToAction(nameof(Index));
            }catch
            {
                TempData["error"] = "Ne postoji objekat koji trazite";
                return RedirectToAction(nameof(Index));
            }
        }

      
    }
}