using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Data;
using ContosoUniversity.Dtos;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoUniversity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly SchoolContext _context;
        public MasterController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet("seed")]
        public async Task<IActionResult> SeedAsync()
        {
            if (_context.Masters.Any())
            {
                return Ok(0);   // DB has been seeded
            }

            var masters = new Master[]
            {
                new Master { ID= Guid.NewGuid(),  MasterName = "Master1", Subs = new Sub[] { new Sub { SubName = "Master1-Sub1" }, new Sub { SubName = "Master1-Sub2" }, new Sub { SubName = "Master1-Sub3" } } },
                new Master { ID= Guid.NewGuid(),MasterName = "Master2", Subs = new Sub[] { new Sub { SubName = "Master2-Sub1" }, new Sub { SubName = "Master2-Sub2" }, new Sub { SubName = "Master2-Sub3" } } },
                new Master { ID= Guid.NewGuid(),MasterName = "Master3", Subs = new Sub[] { new Sub { SubName = "Master3-Sub1" }, new Sub { SubName = "Master3-Sub2" }, new Sub { SubName = "Master3-Sub3" } } }
            };

            await _context.Masters.AddRangeAsync(masters);
            var num = await _context.SaveChangesAsync();
            return Ok(num);
        }

        // GET: api/<MasterController>
        [HttpGet("family")]
        public async Task<IActionResult> GetMasterSubAsync()
        {
            var list = await _context.Masters
                .Include(x => x.Subs).Select(x => new Master { ID = x.ID, MasterName = x.MasterName, Subs = x.Subs.Select(y => new Sub { ID = y.ID, MasterID = y.MasterID, SubName = y.SubName }).ToList() })
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("self")]
        public async Task<IActionResult> GetMasterAsync()
        {
            var list = await _context.Masters.Select(x => new Master { ID = x.ID, MasterName = x.MasterName, Subs = x.Subs.Select(y => new Sub { ID = y.ID, MasterID = y.MasterID, SubName = y.SubName }).ToList() })
                .ToListAsync();
            return Ok(list);
        }

        [HttpPost("family")]
        public async Task<IActionResult> UpdateMasterSubAsync([FromBody] MasterDto request)
        {
            if (request == null || request.ID == null)
                throw new Exception("master is required!");

            var entity = await _context.Masters
                .Include(x=>x.Subs)
                .SingleOrDefaultAsync(x => x.ID == request.ID.Value);

            if (entity == null)
                throw new Exception("master entity not found!");

            entity.MasterName = request.MasterName;

            entity.Subs = null;
            _context.Masters.Update(entity);

            int num = await _context.SaveChangesAsync();

            var updatedEntity = await _context.Masters
                .Include(x => x.Subs)
                .SingleOrDefaultAsync(x => x.ID == request.ID.Value);
            var responseDto = new Master { ID = updatedEntity.ID, MasterName = updatedEntity.MasterName, Subs = updatedEntity.Subs.Select(x => new Sub { ID = x.ID, SubName = x.SubName, MasterID = updatedEntity.ID }).ToList() };
            return Ok(responseDto);
        }

        [HttpPost("family2")]
        public async Task<IActionResult> UpdateMasterSub2Async([FromBody] MasterDto request)
        {
            if (request == null || request.ID == null)
                throw new Exception("master is required!");

            var entity = await _context.Masters
                .Include(x => x.Subs)
                .SingleOrDefaultAsync(x => x.ID == request.ID.Value);

            if (entity == null)
                throw new Exception("master entity not found!");

            entity.MasterName = request.MasterName;



            if (request.Subs != null)
            {
                foreach (var subRequest in request.Subs)
                {
                    Sub sub;
                    if (subRequest.ID == null)
                    {
                        sub = new Sub();
                        sub.ID = Guid.NewGuid();
                        sub.SubName = subRequest.SubName;
                        sub.MasterID = entity.ID;
                        await _context.Subs.AddAsync(sub);
                    }
                    else
                    {
                        sub = _context.Subs.FirstOrDefault(x => x.ID == subRequest.ID);
                        sub.SubName = subRequest.SubName;
                        sub.MasterID = entity.ID;
                        _context.Subs.Update(sub);
                    }
                }
            }

            _context.Masters.Update(entity);

            int num = await _context.SaveChangesAsync();


            var updatedEntity = await _context.Masters
                .Include(x => x.Subs)
                .SingleOrDefaultAsync(x => x.ID == request.ID.Value);
            var responseDto = new Master { ID = updatedEntity.ID, MasterName = updatedEntity.MasterName, Subs = updatedEntity.Subs.Select(x => new Sub { ID = x.ID, SubName = x.SubName, MasterID = updatedEntity.ID }).ToList() };
            return Ok(responseDto);
        }

        [HttpPost("family3")]
        public async Task<IActionResult> UpdateMasterSub3Async([FromBody] MasterDto request)
        {
            if (request == null || request.ID == null)
                throw new Exception("master is required!");

            var entity = await _context.Masters
                .Include(x => x.Subs)
                .SingleOrDefaultAsync(x => x.ID == request.ID.Value);

            if (entity == null)
                throw new Exception("master entity not found!");

            entity.MasterName = request.MasterName;


            List<Sub> subs = new List<Sub>();
            if (request.Subs != null)
            {
                for (int i = 0; i < request.Subs.Count; i++)
                {
                    var subRequest = request.Subs[i];
                    if (subRequest.ID == null)
                    {
                        Sub sub = new Sub();
                        sub.ID = Guid.NewGuid();
                        sub.SubName = subRequest.SubName;
                        sub.MasterID = entity.ID;
                        subs.Add(sub);
                    }
                    else
                    {

                        Sub sub = entity.Subs.FirstOrDefault(x => x.ID == subRequest.ID.Value);
                        sub.MasterID = entity.ID;
                        sub.SubName = subRequest.SubName;
                        subs.Add(sub);
                    }
                }
            }
            entity.Subs = subs;
            _context.Masters.Update(entity);
            int num = await _context.SaveChangesAsync();


            var updatedEntity = await _context.Masters
                .Include(x => x.Subs)
                .SingleOrDefaultAsync(x => x.ID == request.ID.Value);
            var responseDto = new Master { ID = updatedEntity.ID, MasterName = updatedEntity.MasterName, Subs = updatedEntity.Subs.Select(x => new Sub { ID = x.ID, SubName = x.SubName, MasterID = updatedEntity.ID }).ToList() };
            return Ok(responseDto);
        }

       
        [HttpPost("self")]
        public async Task<IActionResult> UpdateMasterAsync([FromBody] MasterDto request)
        {
            if (request == null || request.ID == null)
                throw new Exception("master is required!");

            var entity = await _context.Masters
                .SingleOrDefaultAsync(x => x.ID == request.ID.Value);

            if (entity == null)
                throw new Exception("master entity not found!");

            entity.MasterName = request.MasterName;

            _context.Masters.Update(entity);

            int num = await _context.SaveChangesAsync();

            var updatedEntity = await _context.Masters
                .Include(x => x.Subs)
                .SingleOrDefaultAsync(x => x.ID == request.ID.Value);
            var responseDto = new Master { ID = updatedEntity.ID, MasterName = updatedEntity.MasterName, Subs = updatedEntity.Subs.Select(x => new Sub { ID = x.ID, SubName = x.SubName, MasterID = updatedEntity.ID }).ToList() };
            return Ok(responseDto);
        }

        [HttpPost("self2")]
        public async Task<IActionResult> UpdateMaster2Async([FromBody] MasterDto request)
        {
            if (request == null || request.ID == null)
                throw new Exception("master is required!");

            var entity = await _context.Masters
                .SingleOrDefaultAsync(x => x.ID == request.ID.Value);

            if (entity == null)
                throw new Exception("master entity not found!");

            entity.MasterName = request.MasterName;

            entity.Subs = null;

            _context.Masters.Update(entity);

           
            int num = await _context.SaveChangesAsync();

            var updatedEntity = await _context.Masters
                .Include(x => x.Subs)
                .SingleOrDefaultAsync(x => x.ID == request.ID.Value);
            var responseDto = new Master { ID = updatedEntity.ID, MasterName = updatedEntity.MasterName, Subs = updatedEntity.Subs.Select(x => new Sub { ID = x.ID, SubName = x.SubName, MasterID = updatedEntity.ID }).ToList() };
            return Ok(responseDto);
        }

    }
}
