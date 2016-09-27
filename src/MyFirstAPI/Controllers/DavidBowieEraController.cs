using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;
using System;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost]
        public IActionResult Create([FromBody] DavidBowieEra era)
        {
            if (era == null)
            {
                return BadRequest();
            }
            DavidBowieEras.Add(era);
            return CreatedAtRoute("GetDavidBowieEra", new { id = era.Key }, era);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] DavidBowieEra era)
        {
            if (era == null || era.Key != id)
            {
                return BadRequest();
            }

            var DavidBowieEra = DavidBowieEras.Find(id);
            if (DavidBowieEra == null)
            {
                return NotFound();
            }

            DavidBowieEras.Update(era);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] DavidBowieEra era, string id)
        {
            if (era == null)
            {
                return BadRequest();
            }

            var davidBowieEra = DavidBowieEras.Find(id);
            if (davidBowieEra == null)
            {
                return NotFound();
            }

            era.Key = davidBowieEra.Key;

            DavidBowieEras.Update(era);
            return new NoContentResult();
        }

        [HttpPost("{id}/upvote")]
        public IActionResult UpVote(string id)
        {
            var davidBowieEra = DavidBowieEras.Find(id);
            if (davidBowieEra == null)
            {
                return NotFound();
            }

            davidBowieEra.UpVotes ++;

            DavidBowieEras.Update(davidBowieEra);
            return new NoContentResult();
        }

        [HttpPost("{id}/downvote")]
        public IActionResult DownVote(string id)
        {
            var davidBowieEra = DavidBowieEras.Find(id);
            if (davidBowieEra == null)
            {
                return NotFound();
            }

            davidBowieEra.DownVotes++;

            DavidBowieEras.Update(davidBowieEra);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var davidBowieEra = DavidBowieEras.Find(id);
            if (davidBowieEra == null)
            {
                return NotFound();
            }

            DavidBowieEras.Remove(id);
            return new NoContentResult();
        }

        [HttpGet("timesincebowiedied")]
        public string Version()
        {
            DateTime bowieDate = new DateTime(2016, 1, 10, 12, 0, 0);
            DateTime currentDate = DateTime.Now;
            int difference = (int) (currentDate - bowieDate).TotalDays;
            return "It's been " + difference.ToString() + " days since Bowie died.";

        }
    }
}