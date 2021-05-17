using CoreIdentityExam.BAL;
using CoreIdentityExam.Data;
using CoreIdentityExam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentityExam.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class DetailsController : Controller
    {
  
        private readonly IRepositoryGeneric<UserDetails> repositoryGeneric;

        public DetailsController(IRepositoryGeneric<UserDetails> repositoryGeneric)
        {
            
            this.repositoryGeneric = repositoryGeneric;
        }

        /// <summary>
        /// To insert user record view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InsertDetails()
        {
            return View();
        }

        /// <summary>
        /// Insert user details into database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertDetails(UserDetails model)
        {
            if (ModelState.IsValid)
            {
                repositoryGeneric.Insert(model);
                repositoryGeneric.Save();
            }
           
            return RedirectToAction("GetAllRec");
        }

        
        /// <summary>
        /// To fetch all user records from database
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAllRec()
        {
            
            var model = await repositoryGeneric.GetAll();
            return View(model);
        }


        /// <summary>
        /// Edit user records views
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        //[Route("{id?}")]
        [Route("{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            
            var model = await repositoryGeneric.GetById(id);
            if(model == null)
            {
                Response.StatusCode = 404;
                return View("DetailsNotFound", id);
            }
            return View(model);
        }

        /// <summary>
        /// Update user records
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id:int}")]
        public IActionResult Edit(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                repositoryGeneric.Update(userDetails);
                repositoryGeneric.Save();
            }
            
            return RedirectToAction("GetAllRec");
            TempData["msg"] = "You have saved the restaurant";
        }


       
        /// <summary>
        /// Delete user records view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var userDetails = await repositoryGeneric.GetById(id);
            return View(userDetails);
        }

        /// <summary>
        /// Delete user Records
        /// </summary>
        /// <param name="id"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}")]
        public IActionResult Delete(int id, int c)
        {
            
            repositoryGeneric.Delete(id);
            repositoryGeneric.Save();

            return RedirectToAction("GetAllRec");

        }
    }
}
