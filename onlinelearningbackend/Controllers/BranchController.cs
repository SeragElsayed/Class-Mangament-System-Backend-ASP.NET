using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using onlinelearningbackend.Repo.IManager;


namespace onlinelearningbackend.Controllers
{
    [ApiController]

    public class BranchController : Controller
    {

        IBranchManager db;
        public BranchController(IBranchManager _db)
        {
            this.db = _db;
        }



        [HttpGet]
        [Route("api/explore/branches")]
        public async Task<IActionResult> GetAllBranchs()
        {
            var branches = db.GetAllBranchs();

            if (branches == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(branches);
            }

        }
    }
}