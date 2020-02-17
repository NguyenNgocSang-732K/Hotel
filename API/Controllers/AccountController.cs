using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.Models.Entities;
using API.Models.Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API.Supports;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var account = await db.Account.AsNoTracking().Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Phone = s.Phone,
                Address = s.Address,
                Email = s.Email
            }).ToListAsync();
            return Ok(account);
        }

        [HttpGet("{id}")]
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
                    Email = s.Email
                };
                return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VMAccountCreate a)
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
                        Email = account.Email
                    });
                }
                return BadRequest("Dữ liệu không hợp lệ");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modify(int id, [FromBody]VMAccountCreate a)
        {
            try
            {
                Account account = db.Account.Find(id);
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
                        await db.SaveChangesAsync();
                        return Ok(new
                        {
                            Id = account.Id,
                            Name = account.Name,
                            Phone = account.Phone,
                            Address = account.Address,
                            Email = account.Email
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


        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                Account account = db.Account.Where(s => s.Email.ToLower() == email.ToLower()).SingleOrDefault();
                if (account != null)
                {
                    if (MD5_Sang.VerifyMD5(password, account.Password))
                    {
                        return Ok(new
                        {
                            Id = account.Id,
                            Name = account.Name,
                            Phone = account.Phone,
                            Address = account.Address,
                            Email = account.Email
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
    }
}