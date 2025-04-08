// using Microsoft.AspNetCore.UseAuthorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;


    namespace Controllers{
        [ApiController]
        [Route("api/users")]
        public class UserController : ControllerBase
        {
            private readonly AppDbContext _context;

            public UserController(AppDbContext context){
                _context = context;
            }

            [HttpPost] // Tạo mới người dùng
            public async Task<ActionResult<User>> CreateUser(
                [FromBody] CreateUserRequest request)// Xử lý bất đồng bộ khi có nhiều luồng, luồng này phải đợi kết quả luồng kia. From body là lấy thông tin từ data người dùng guuiwr lên, body day vao request
                {
                    //Check tk tồn tại
                    if(await _context.Users.AnyAsync(
                        u => u.Username == request.Username)) // u laf bien tam
                        return BadRequest("Username đã tồn tại.");
                    var user = new User{
                        Username =  request.Username,
                        Password = BCrypt.Net.BCrypt.HashPassword(
                                                        request.Password),
                        FullName = request.FullName,
                        Role ="nhan vien",
                        Phone = request.Phone,
                        IsActive = true
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction(nameof(GetUser),
                                     new {id = user.Id}, user);
                }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id){
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }
        }
        
        public class CreateUserRequest{
            public string Username {get; set;}
            public string Password {get; set;}
            public string FullName {get; set;}
            public string Phone {get; set;}

        }
        
    }