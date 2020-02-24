using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API.Supports;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private HotelContext db;
        public AccountController(HotelContext _db)
        {
            db = _db;
        }

        [HttpGet("get")]
        [Consumes("application/json")]
        public async Task<IActionResult> Get()
        {
            var account = await db.Account.AsNoTracking().Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Phone = s.Phone,
                Address = s.Address,
                Password = s.Password,
                Email = s.Email,
                Roles = s.Roles
            }).ToListAsync();
            return Ok(account);
        }

        [HttpGet("get/{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Account s = await db.Account.FindAsync(id);
                if (s == null)
                {
                    return NotFound("Không tìm thấy");
                }
                var account = new
                {
                    Id = s.Id,
                    Name = s.Name,
                    Phone = s.Phone,
                    Address = s.Address,
                    Password = s.Password,
                    Email = s.Email,
                    Roles = s.Roles
                };
                return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]Account a)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Account account = new Account
                    {
                        Email = a.Email,
                        Address = a.Address,
                        Name = a.Name,
                        Password = a.Password,
                        Phone = a.Phone,
                        Roles = 2
                    };
                    await db.Account.AddAsync(account);
                    await db.SaveChangesAsync();
                    return Ok(new
                    {
                        Id = account.Id,
                        Name = account.Name,
                        Phone = account.Phone,
                        Address = account.Address,
                        Email = account.Email,
                        Roles = account.Roles,
                        Password = account.Password
                    });
                }
                return BadRequest("Dữ liệu không hợp lệ");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("modify")]
        public async Task<IActionResult> Modify([FromBody]Account a)
        {
            try
            {
                Account account = db.Account.Find(a.Id);
                if (account == null)
                {
                    return NotFound("Không tìm thấy");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        account.Address = a.Address;
                        account.Phone = a.Phone;
                        account.Email = a.Email;
                        account.Name = a.Name;
                        account.Password = a.Password;
                        account.Roles = a.Roles;
                        await db.SaveChangesAsync();
                        return Ok(new
                        {
                            Id = account.Id,
                            Name = account.Name,
                            Phone = account.Phone,
                            Address = account.Address,
                            Email = account.Email,
                            Roles = account.Roles,
                            Password = account.Password
                        });
                    }
                    else
                    {
                        return BadRequest("Dữ liệu không hợp lệ");
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpDelete("{remove}/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                Account account = db.Account.Find(id);
                if (account == null)
                {
                    return NotFound("Không tìm thấy");
                }
                db.Account.Remove(account);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Account acc)
        {
            try
            {
                Account account = await db.Account.Where(s => s.Email.ToLower() == acc.Email.ToLower()).SingleOrDefaultAsync();
                if (account != null)
                {
                    if (MD5_Sang.VerifyMD5(acc.Password, account.Password))
                    {
                        return Ok(new
                        {
                            Id = account.Id,
                            Name = account.Name,
                            Phone = account.Phone,
                            Address = account.Address,
                            Email = account.Email,
                            Roles = account.Roles,
                            Password = account.Password
                        });
                    }
                    else
                    {
                        return NotFound("Không tìm thấy");
                    }
                }
                else
                {
                    return NotFound("Không tìm thấy");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("test")]
        public async Task<IActionResult> Test([FromHeader]int id)
        {
            try
            {
                Account s = await db.Account.FindAsync(id);
                if (s == null)
                {
                    return NotFound("Không tìm thấy");
                }
                var account = new
                {
                    Id = s.Id,
                    Name = s.Name,
                    Phone = s.Phone,
                    Address = s.Address,
                    Email = s.Email,
                    Roles = s.Roles
                };
                return Ok(account);
            }
            catch
            {
                return BadRequest("Sángggggggggggggg");
            }
        }
    }
}