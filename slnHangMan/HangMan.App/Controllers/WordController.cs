﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangMan.App.Controllers
{
    public class WordController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
    }
}