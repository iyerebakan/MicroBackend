using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroBackend.Authorization.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpPost("add")]
        public IActionResult Add(Folder folder)
        {
            _folderService.Add(folder);
            return Ok(folder._id);
        }
    }
}
