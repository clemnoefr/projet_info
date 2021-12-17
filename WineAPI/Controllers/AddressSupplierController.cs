﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;
using WineBiblio.Service;
using Microsoft.AspNetCore.Mvc;

namespace WineAPI.Controllers
{
    [ApiController]
    public class AddressSupplierController : ControllerBase
    {
        private readonly MyDataContext _ctx;

        public AddressSupplierController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("/addressSupplier/")]
        public IActionResult Get()
        {
            return Ok(new AddressSupplierService(_ctx).Get());
        }

        [HttpGet("/addressSupplier/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new AddressSupplierService(_ctx).Get(id));
        }

        [HttpDelete("/addressSupplier/{id}")]
        public IActionResult Delete(int id)
        {
            new AddressSupplierService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/addressSupplier/{id}")]

        public IActionResult Edit(AddressSupplier model)
        {
            return Ok(
                /*new AddressSupplierService(_ctx).Update(model)*/
                );

        }
    }
}