using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Controllers
{
    [Authorize]
    [ApiController]
    public class TaskController: ControllerBase
    {
        taskManager _taskManager;
        public TaskController()
        {
                
        }


    }
}
