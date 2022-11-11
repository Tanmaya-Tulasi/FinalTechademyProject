using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTestProject1.Controllers
{
    public class UnitTestController : Controller
    {
        private readonly ILogger<UnitTestController> logger;

        public UnitTestController(ILogger<UnitTestController> logger)
        {
            this.logger = logger;
        }
        public string GetMessage()
        {
            logger.LogDebug("Index Method Called!!!");
            return "Hi! Reader";
        }
    }
}
