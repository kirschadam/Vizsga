using API_Vizsga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace API_Vizsga
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /*private readonly companyContext Context;
        public HomeController(companyContext context) => Context = context;*/

        [HttpGet]
        [Route("GetCoworkerByEmail")]
        public IActionResult GetCoworkerByEmail(string email)
        {
            try
            {
                var Context = new companyContext();

                var worker = Context.Coworkers.Include(x => x.Phones).Include(x => x.Notebooks).FirstOrDefaultAsync(x => x.Email == email);

                if (worker == null)
                {
                    return StatusCode(200, worker);
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(400, ex.Message); 
            }

            return StatusCode(400, "No worker found!");
        }

        [HttpGet]
        [Route("GetCoworkerNumber")]
        public IActionResult GetCoworkerNumber()
        {
            try
            {
                var Context = new companyContext();

                int workerCount = Context.Coworkers.Count();

                if (workerCount != 0)
                {
                    return StatusCode(200, workerCount);
                }
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }

            return StatusCode(400, "No workers found!");
        }

        [HttpPost]
        [Route("AddCoworker")]
        public IActionResult AddCoworker(Coworker coworker, string uid)
        {
            try
            {
                using (var Context = new companyContext())

                if (uid == Program.UID)
                {
                    Context.Add(coworker);
                    Context.SaveChanges();

                    return StatusCode(200, "Coworker added!");
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(400, ex.Message); 
            }
            
            return StatusCode(400, "No changes were made!");
        }

        [HttpPut]
        [Route("UpdateCoworker")]
        public IActionResult UpdateCoworker(string uid, Coworker coworker)
        {
            try
            {
                using (var Context = new companyContext())

                    if (uid == Program.UID)
                    {
                        Context.Update(coworker);
                        Context.SaveChanges();

                        return StatusCode(200, "Coworker updated!");
                    }
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }

            return StatusCode(400, "No changes were made!");
        }

        [HttpDelete]
        [Route("DeleteCoworker")]
        public IActionResult DeleteCoworker(string uid, int id)
        {
            try
            {
                using (var Context = new companyContext())

                if (uid == Program.UID)
                {
                    Context.Remove(Context.Coworkers.FirstOrDefault(x => x.Id == id));
                    Context.SaveChanges();

                    return StatusCode(200, "Coworker deleted!");
                }

            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }

            return StatusCode(400, "No changes were made!");
        }
    }
}