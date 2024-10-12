﻿using App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.API.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> result)
        {
            return result.Status switch
            {
                HttpStatusCode.NoContent => NoContent(),
                HttpStatusCode.Created => Created(result.UrlAsCreated, result),
                _ => new ObjectResult(result) { StatusCode = result.Status.GetHashCode() }
            };
        }

        [NonAction]
        public IActionResult CreateActionResult(ServiceResult result)
        {
            return result.Status switch
            {
                HttpStatusCode.NoContent => new ObjectResult(null) { StatusCode = result.Status.GetHashCode() },
                _ => new ObjectResult(result) { StatusCode = result.Status.GetHashCode() }
            };
        }
    }
}
