using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangMan.App.App_Start
{
    public class AutomapperConfig
    {
        public static void CreateMaps()
        {
            HangMan.Services.Config.AutomapperConfig.Configure();
        }
    }
}