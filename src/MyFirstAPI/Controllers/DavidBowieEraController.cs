﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/{controller}")]
    public class DavidBowieEraController : Controller
    {
        public DavidBowieEraController(IDavidBowieEraRepository davidBowieEras)
        {
            DavidBowieEras = davidBowieEras;
        }
        public IDavidBowieEraRepository DavidBowieEras { get; set; }

        [HttpGet]
        public IEnumerable<DavidBowieEra> GetAll()
        {
            return DavidBowieEras.GetAll();
        }

        [HttpGet("{id}", Name = "GetDavidBowieEra")]
        public IActionResult GetById(string id)
        {
            var era = DavidBowieEras.Find(id);
            if (era == null)
            {
                return NotFound();
            }
            return new ObjectResult(era);

        }
    }
}