﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrickingLibrary.Api.Models;

namespace TrickingLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/tricks")]
    public class Tricks : ControllerBase
    {
        private readonly TrickyStore _store;

        public Tricks(TrickyStore store)
        {
            _store = store;
        }

        // /api/tricks
        [HttpGet]
        public IActionResult All() => Ok(_store.All);
        
        // /api/tricks/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_store.All.FirstOrDefault(x => x.Id.Equals(id))); 
        
        // /api/tricks/{id}/submissions
        //[HttpGet("{id}")]
        //public IActionResult GetSub(int id) => Ok(_store.All.FirstOrDefault(x => x.Id.Equals(id))); 

        [HttpPost]
        public IActionResult Create([FromBody] Trick trick)
        {
            _store.Add(trick);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Trick trick)
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}