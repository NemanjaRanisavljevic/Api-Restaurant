using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ImpressionCommand;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ImpressionController : Controller
    {
        private IAddImpresssionCommand _addImpressionCommand;
        private IDeleteImpressionCommand _deleteImpressionCommand;
        private IGetImpressionCommand _getImpressionCommand;
        private IEditImpressionCommand _editImpressionCommand;
        private IGetImpressionsCommand _getImpressionsCommand;
        private IGetAllImpressionWebCommand _getAllImpressionCommand;
        private IGetImpressionWebCommand _getImpressionWebCommand;

        public ImpressionController(IAddImpresssionCommand addImpressionCommand, IDeleteImpressionCommand deleteImpressionCommand, IGetImpressionCommand getImpressionCommand, IEditImpressionCommand editImpressionCommand, IGetImpressionsCommand getImpressionsCommand, IGetAllImpressionWebCommand getAllImpressionCommand, IGetImpressionWebCommand getImpressionWebCommand)
        {
            _addImpressionCommand = addImpressionCommand;
            _deleteImpressionCommand = deleteImpressionCommand;
            _getImpressionCommand = getImpressionCommand;
            _editImpressionCommand = editImpressionCommand;
            _getImpressionsCommand = getImpressionsCommand;
            _getAllImpressionCommand = getAllImpressionCommand;
            _getImpressionWebCommand = getImpressionWebCommand;
        }




        // GET: Impression prikaz svih
        public ActionResult Index(ImpressionSearchWeb request)
        {
            var lista = _getAllImpressionCommand.Execute(request);
            return View(lista);
        }

        // GET: Impression/Details/5 
        public ActionResult Details(int id)
        {

            try
            {
                var dto = _getImpressionCommand.Execute(id);
                return View(dto);
            }
            catch (NotFoundException)
            {
                TempData["error"] = "Ne postoji utisak sa id koji ste uneli";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Impression/Create prikaz forme
        public ActionResult Create()
        {
            return View();
        }

        // POST: Impression/Create unos jednog
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImpressionDTO request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }
            try
            {
                _addImpressionCommand.Execute(request);

                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                TempData["error"] = "Uneli ste id usera koji ne postoji";
            }catch(Exception)
            {
                TempData["error"] = "Serverska greska";
            }
            return View();
        }

        // GET: Impression/Edit/5 prikaz forme
        public ActionResult Edit(int id)
        {
            var obj = _getImpressionWebCommand.Execute(id);
            return View(obj);
        }

        // POST: Impression/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImpressionEditDTO request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            try
            {
                 
                _editImpressionCommand.Execute(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteImpressionCommand.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }


       
    }
}