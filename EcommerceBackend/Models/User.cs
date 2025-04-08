using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    [Table("Users")]  // tạo 1 lớp
    public class User{
        [Key]  // Khóa chính
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// Tạo phần tử tự sinh tăng dần tránh lập
        public int Id { get; set;} //Tạo phương thức get và set để gán tương tác Id
        
        [Required] // bắt buộc nhập
        [StringLength(50)] // Không quá 50 kí tự
        [Column(TypeName = "varchar(50)")]// Định nghĩa kiểu dữ liệu
        public string Username {get; set;} // Tạo username

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Passwword {get; set;} // Tạo Password

        [Required]
        public string FullName {get; set;} // Nếu không định nghĩa nó sẽ theo kiểu string

        [Required]
        [Column(TypeName= "varchar(20)")]
        public string Role {get; set;} // Các vai trò như người dùng, quản trị

        [MaxLength(255)] 
        [StringLength(20)] // chuỗi kí tự phải dài tối đa 20
        [Column(TypeName = "varchar(20)")]
        public string Phone {get; set;} // Số điện thoại

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// Tạo phần tử tăng dần tránh lập
        public DateTime CreateAt {get; set;} = DateTime.UtcNow; // Ngày giờ

        public bool IsActive {get; set;} = true; // tài khoản kích hoat chưa
    }
}