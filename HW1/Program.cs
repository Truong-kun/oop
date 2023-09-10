using System;
using System.Text;

namespace MyInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string fullname = "Nguyễn Văn Trường";
            string studentID = "10122381";
            string className = "12422TN";
            string GitHub_username = "Truong-kun";
            string email = "truongkun2k4@gmail.com";

            Console.WriteLine($"Họ tên: {fullname}\tMã sinh viên: {studentID}\tLớp: {className}\tGitHub: {GitHub_username}\tEmail: {email}");
        }
    }
}
