// Đồng Bá Thùy 20206173
using System;

namespace _20206173_DongBaThuy
{
    public class Book
    {
        // Các thuộc tính
        public string SoDangKy { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string NhaXuatBan { get; set; }
        public int NamXuatBan { get; set; }
        public string SoISBN { get; set; }
        public Book()
        {

        }
        public Book(string sodangky, string tensach,
                    string tacgia, string nhaxuatban,
                    int namxuatban, string soISBN)
        {
            this.SoDangKy = sodangky;
            this.TenSach = tensach;
            this.TacGia = tacgia;
            this.NhaXuatBan = nhaxuatban;
            this.NamXuatBan = namxuatban;
            this.SoISBN = soISBN;
        }

        public virtual void Input() // Hàm nhập thông tin sách
        {
            Console.WriteLine("Nhập số đăng kí:");
            SoDangKy = Console.ReadLine();
            try
            {
                int.Parse(SoDangKy);
                Console.WriteLine("Nhập tên sách:");
                TenSach = Console.ReadLine();
                Console.WriteLine("Nhập tên tác giả:");
                TacGia = Console.ReadLine();
                Console.WriteLine("Nhập tên nhà xuất bản:");
                NhaXuatBan = Console.ReadLine();
                Console.WriteLine("Nhập năm xuất bản:");
                NamXuatBan = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhập số ISBN:");
                SoISBN = Console.ReadLine();
                Console.WriteLine("Thêm sách thành công!");
            }
            catch
            {
                Console.WriteLine("Vui lòng nhập lại số đăng ký là một số nguyên!");
            }

        }
        public virtual void Display() // Hàm hiển thị thông tin sách
        {
            Console.WriteLine("{0,-15} {1,-20} {2,-40} {3,-30} {4,-15} {5,-10}",
                SoDangKy, TenSach, TacGia, NhaXuatBan, NamXuatBan, SoISBN);
        }
    }
}

