// Đồng Bá Thùy 20206173
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _20206173_DongBaThuy
{

    class Program
    {
        static void Import(List<Library> p) // Đọc dữ liệu sách có trong thư viện từ file
        {

            try
            {

                using (StreamReader reader = new StreamReader("..\\..\\File\\Import.txt"))
                {
                    string header, line;
                    header = reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] _book = line.Split(';');
                        string SoDangKy = _book[0];
                        string TenSach = _book[1];
                        string TacGia = _book[2];
                        string NhaXuatBan = _book[3];
                        int NamXuatBan = Convert.ToInt32(_book[4]);
                        string SoISBN = _book[5];
                        Library q = new Library(SoDangKy, TenSach, TacGia, NhaXuatBan, NamXuatBan, SoISBN);
                        p.Add(q);
                    }
                    reader.Close();
                }
                Console.WriteLine("Dữ liệu đã được đọc thành công!");
            }
            catch
            {
                Console.WriteLine("Lỗi! Kiểm tra lại file!");
            }
        }
        static void Export(List<Library> p) // Lưu dữ liệu sách có trong thư viện ra file 
        {
            string link = "..\\..\\File\\Export.txt";
            try
            {

                using (StreamWriter writer = new StreamWriter(link))
                {
                    writer.WriteLine("{0,-15} {1,-20} {2,-40} {3,-30} {4,-15} {5,-10}",
                    "Số Đăng Ký", "Tên Sách", "Tên Tác Giả", "Nhà Xuất Bản", "Năm Xuất Bản", "Số ISBN");
                    for (int i = 0; i < p.Count(); i++)

                    {
                        //writer.WriteLine(p[i].ToString());
                        writer.WriteLine("{0,-15} {1,-20} {2,-40} {3,-30} {4,-15} {5,-10}",
                        p[i].SoDangKy, p[i].TenSach, p[i].TacGia, p[i].NhaXuatBan, p[i].NamXuatBan, p[i].SoISBN);

                    }
                    writer.Close();
                }
                Console.WriteLine("Lưu file thành công!");
            }
            catch
            {
                Console.WriteLine("Lỗi nhập file!");
            }

        }
        static void InputBook(List<Library> p)// Nhập thông tin sách
        {
            Library sach = new Library();
            sach.Input();
            p.Add(sach);
        }
        static void ListBook(List<Library> p) // Hiển thị thông tin sách
        {
            if (p.Count() != 0)
            {
                Console.WriteLine("Số sách có trong thư viện:");
                Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                Console.WriteLine("{0,-15} {1,-20} {2,-40} {3,-30} {4,-15} {5, -10}",
                "Số Đăng Ký", "Tên Sách", "Tác Giả", "Nhà Xuất Bản", "Năm Xuất Bản", "Số ISBN");
                Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                for (int i = 0; i < p.Count(); i++)
                {
                    p[i].Display();
                }
                Console.WriteLine("___________________________________________________________________________________________________________________________________________");
            }
            else
            {
                Console.WriteLine("Thư viện chưa có sách, vui lòng nhập thông tin sách!");
            }
        }
        static void Update(List<Library> p) // Cập nhật thông tin sách
        {
            Console.WriteLine("Nhập số đăng ký sách cần cập nhật:");
            string updating = Console.ReadLine();
            /* Khởi tạo 1 biến dem, khi có 1 cuốn sách được cập nhật
             * thì dem tăng lên 1 đơn vị. Mục đích của biến dem là 
             * để khi chạy hết vòng for( quét hết cả danh sách) không tìm thấy
             * cuốn sách nào được cập nhật, thì biến dem sẽ nhận giá trị là dem=0.
             * Lúc này, sẽ in ra:
             * " Không tìm thấy sách có số đăng ký là ... trong thư viện"
             */
            int dem = 0;

            for (int i = 0; i < p.Count(); i++)
            {
                if (p[i].SoDangKy.Equals(updating))
                {
                    Console.WriteLine("Tên sách (nếu không cần cập nhật thì bỏ trống):");
                    string _TenSach = Console.ReadLine();
                    Console.WriteLine("Tác giả (nếu không cần cập nhật thì bỏ trống):");
                    string _TacGia = Console.ReadLine();
                    Console.WriteLine("Nhà xuất bản (nếu không cần cập nhật thì bỏ trống):");
                    string _NhaXuatBan = Console.ReadLine();
                    Console.WriteLine("Năm xuất bản (nếu không cần cập nhật thì bỏ trống):");
                    int _NamXuatBan = int.Parse(Console.ReadLine());
                    Console.WriteLine("Số ISBN (nếu không cần cập nhật thì bỏ trống):");
                    string _SoISBN = Console.ReadLine();
                    if (_TenSach == String.Empty)
                    {
                        p[i].TenSach = p[i].TenSach;
                    }
                    else
                    {
                        p[i].TenSach = _TenSach;
                    }
                    ///
                    if (_TacGia == String.Empty)
                    {
                        p[i].TacGia = p[i].TacGia;
                    }
                    else
                    {
                        p[i].TacGia = _TacGia;
                    }
                    ///
                    if (_NhaXuatBan == String.Empty)
                    {
                        p[i].NhaXuatBan = p[i].NhaXuatBan;
                    }
                    else
                    {
                        p[i].NhaXuatBan = _NhaXuatBan;
                    }
                    ///
                    if (_NamXuatBan == 0)
                    {
                        p[i].NamXuatBan = p[i].NamXuatBan;
                    }
                    else
                    {
                        p[i].NamXuatBan = _NamXuatBan;
                    }
                    ///
                    if (_SoISBN == String.Empty)
                    {
                        p[i].SoISBN = p[i].SoISBN;
                    }
                    else
                    {
                        p[i].SoISBN = _SoISBN;
                    }
                    dem++;
                }

            }
            if (dem != 0)
            {
                Console.WriteLine("Cập nhật thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy quyển sách nào có số đăng ký là {0} trong thư viện", updating);
            }

        }
        static void FindBook(List<Library> p) // Tìm kiếm sách
        {
            if (p.Count() != 0)
            {
                Console.WriteLine("'''''''''''''''''''''''''''''''''''''''''''''''''''");
                Console.WriteLine("1. Tìm kiếm theo số đăng ký");
                Console.WriteLine("2. Tìm kiếm theo tên sách");
                Console.WriteLine("3. Tìm kiếm theo số ISBN");
                Console.WriteLine("'''''''''''''''''''''''''''''''''''''''''''''''''''");
                int search;
                int tmp;
                Console.WriteLine("Bạn muốn tìm kiếm theo gì?");
                search = int.Parse(Console.ReadLine());
                switch (search)
                {
                    case 1:
                        Console.WriteLine("Bạn đã chọn tìm kiếm theo số đăng ký!");
                        Console.WriteLine("Vui lòng nhập số đăng ký:");
                        string searching1 = Console.ReadLine();
                        tmp = 0;
                        for (int i = 0; i < p.Count(); i++)
                        {
                            if (p[i].SoDangKy.Equals(searching1))
                            {
                                tmp++;
                            }
                        }
                        if (tmp == 0)
                        {
                            Console.WriteLine("Không tìm thấy quyển sách nào có số đăng ký là {0}!", searching1);
                        }
                        else
                        {
                            Console.WriteLine("Đã tìm thấy {0} quyển sách có số đăng ký là {1}!", tmp, searching1);
                            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                            Console.WriteLine("{0,-15} {1,-20} {2,-40} {3,-30} {4,-15} {5, -10}",
                            "Số Đăng Ký", "Tên Sách", "Tác Giả", "Nhà Xuất Bản", "Năm Xuất Bản", "Số ISBN");
                            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                            for (int i = 0; i < p.Count(); i++)
                            {
                                if (p[i].SoDangKy.Equals(searching1))
                                {
                                    p[i].Display();
                                }
                            }
                            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Bạn đã chọn tìm kiếm theo tên sách!");
                        Console.WriteLine("Vui lòng nhập tên sách:");
                        string searching2 = Console.ReadLine();
                        tmp = 0;
                        for (int i = 0; i < p.Count(); i++)
                        {
                            if (p[i].TenSach.Equals(searching2))
                            {
                                tmp++;
                            }
                        }
                        if (tmp == 0)
                        {
                            Console.WriteLine("Không tìm thấy quyển sách nào có tên là {0}!", searching2);
                        }
                        else
                        {
                            Console.WriteLine("Đã tìm thấy {0} quyển sách có tên là {1}!", tmp, searching2);
                            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                            Console.WriteLine("{0,-15} {1,-20} {2,-40} {3,-30} {4,-15} {5, -10}",
                            "Số Đăng Ký", "Tên Sách", "Tác Giả", "Nhà Xuất Bản", "Năm Xuất Bản", "Số ISBN");
                            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                            for (int i = 0; i < p.Count(); i++)
                            {
                                if (p[i].TenSach.Equals(searching2))
                                {
                                    p[i].Display();
                                }
                            }
                            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Bạn đã chọn tìm kiếm theo số ISBN!");
                        Console.WriteLine("Vui lòng nhập số ISBN:");
                        string searching3 = Console.ReadLine();
                        tmp = 0;
                        for (int i = 0; i < p.Count(); i++)
                        {
                            if (p[i].SoISBN.Equals(searching3))
                            {
                                tmp++;
                            }
                        }
                        if (tmp == 0)
                        {
                            Console.WriteLine("Không tìm thấy quyển sách nào có số ISBN là {0}!", searching3);
                        }
                        else
                        {
                            Console.WriteLine("Đã tìm thấy {0} quyển sách có số ISBN là {1}!", tmp, searching3);
                            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                            Console.WriteLine("{0,-15} {1,-20} {2,-40} {3,-30} {4,-15} {5, -10}",
                            "Số Đăng Ký", "Tên Sách", "Tác Giả", "Nhà Xuất Bản", "Năm Xuất Bản", "Số ISBN");
                            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                            for (int i = 0; i < p.Count(); i++)
                            {
                                if (p[i].SoISBN.Equals(searching3))
                                {
                                    p[i].Display();
                                }
                            }
                            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                        }
                        break;
                    default:
                        Console.WriteLine("Bạn đã thoát phần tìm kiếm!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Thư viện chưa có sách, vui lòng nhập thông tin sách!");
            }
        }
        static void SortBook(List<Library> p) // Sắp xếp sách
        {
            if (p.Count() != 0)
            {
                Console.WriteLine("'''''''''''''''''''''''''''''''''''''''''''''''''''");
                Console.WriteLine("1. Sắp xếp theo số đăng ký");
                Console.WriteLine("2. Sắp xếp theo nhà xuất bản");
                Console.WriteLine("'''''''''''''''''''''''''''''''''''''''''''''''''''");
                int sort;
                Console.WriteLine("Bạn chọn sắp xếp theo gì?");
                sort = int.Parse(Console.ReadLine());
                switch (sort)
                {
                    case 1:
                        Console.WriteLine("Bạn đã chọn sắp xếp theo số đăng ký!");
                        List<Library> q1 = new List<Library>();
                        q1 = p;
                        q1.Sort((Library sach1, Library sach2) =>
                        {
                            return string.Compare(sach1.SoDangKy, sach2.SoDangKy, StringComparison.OrdinalIgnoreCase);
                        });
                        Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                        Console.WriteLine("{0,-15} {1,-20} {2,-40} {3,-30} {4,-15} {5, -10}",
                        "Số Đăng Ký", "Tên Sách", "Tác Giả", "Nhà Xuất Bản", "Năm Xuất Bản", "Số ISBN");
                        Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                        for (int i = 0; i < q1.Count(); i++)
                        {
                            q1[i].Display();
                        }
                        Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                        break;
                    case 2:
                        Console.WriteLine("Bạn đã chọn sắp xếp theo nhà xuất bản!");
                        List<Library> q2 = new List<Library>();
                        q2 = p;
                        q2.Sort((Library sach1, Library sach2) =>
                        {
                            return string.Compare(sach1.NhaXuatBan, sach2.NhaXuatBan, StringComparison.OrdinalIgnoreCase);
                        });
                        Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                        Console.WriteLine("{0,-15} {1,-20} {2,-40} {3,-30} {4,-15} {5, -10}",
                        "Số Đăng Ký", "Tên Sách", "Tác Giả", "Nhà Xuất Bản", "Năm Xuất Bản", "Số ISBN");
                        Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                        for (int i = 0; i < q2.Count(); i++)
                        {
                            q2[i].Display();
                        }
                        Console.WriteLine("___________________________________________________________________________________________________________________________________________");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Thư viện chưa có sách, vui lòng nhập thông tin sách!");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.WriteLine("---------------------o0o---------------------");
            Console.WriteLine("          Đồng Bá Thùy-20206173              ");
            Console.WriteLine(" CHÀO MỪNG BẠN ĐẾN VỚI THƯ VIỆN QUẢN LÝ SÁCH ");
            Console.WriteLine("---------------------o0o---------------------");
            List<Library> p = new List<Library>();
            Console.WriteLine("Lựa chọn:");
            Console.WriteLine("1. Đọc file");
            Console.WriteLine("2. Nhập thông tin sách");
            Console.WriteLine("3. Hiển thị thông tin sách có trong thư viện");
            Console.WriteLine("4. Cập nhật thông tin sách");
            Console.WriteLine("5. Tìm kiếm thông tin sách");
            Console.WriteLine("6. Sắp xếp sách");
            Console.WriteLine("7. In file");
            Console.WriteLine("8. Thoát chương trình!");
            Console.WriteLine("Vui lòng lựa chọn!");
            Console.WriteLine("---------------------o0o---------------------");
            int choose;
            do
            {
                Console.WriteLine("Bạn chọn gì?");
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {

                    case 1:
                        Import(p);
                        break;
                    case 2:
                        InputBook(p);
                        break;
                    case 3:
                        ListBook(p);
                        break;
                    case 4:
                        Update(p);
                        break;
                    case 5:
                        FindBook(p);
                        break;
                    case 6:
                        SortBook(p);
                        break;
                    case 7:
                        Export(p);
                        break;
                    case 8:
                        Console.WriteLine("Bạn đã thoát chương trình!");
                        break;
                    default:
                        Console.WriteLine("Bạn đã lựa chọn sai!");
                        break;

                }
            }
            while (choose != 8);
        }
    }
}
