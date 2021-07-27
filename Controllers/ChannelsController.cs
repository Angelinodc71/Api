// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.AspNetCore.Mvc;

// namespace Api.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class ChannelsController : ControllerBase
//     {
//         private DataContext _context;

//         public ChannelsController(DataContext context)
//         {
//             _context = context ?? throw new ArgumentNullException(nameof(context));   
//         }
//         public IActionResult Get()
//         {
//             var channels = new string[] {".NetCore","ReactJs","Angular"};

//             return Ok(channels);
//         }

//     }
// }