// Đồng Bá Thùy 20206173
namespace _20206173_DongBaThuy
{
    public class Library : Book // lớp kế thừa của lớp Book
    {
        public Library()
        {

        }
        public Library(string sodangky, string tensach,
                    string tacgia, string nhaxuatban,
                    int namxuatban, string soISBN) : base(sodangky, tensach, tacgia, nhaxuatban, namxuatban, soISBN)
        {

        }
        public override void Input()
        {
            base.Input();
        }
        public override void Display()
        {
            base.Display();
        }
    }
}

