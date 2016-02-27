using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_2_Lab_2
{
    class Rectangle
    {
        public Int16 Left_position { get; set; }
        public Int16 Top_position { get; set; }
        public Int16 Border_width { get; set; }
        public string Border_Symbol { get; set; }
        private string Message;
        public Rectangle()
        {
            Left_position = 30;
            Top_position = 10;
            Border_width = 30;
            Border_Symbol = "*";
        }
        public void Rectangle_Message(ref string Message)
        {
            if(Message.Length>(Border_width*2 - 2))
                 Message = Message.Substring(0, Border_width*2 - 2);
            this.Message = Message;
        }
        public void Drow_Rectangle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(Left_position*2, Top_position);
            for (Int16 i = 1; i <= Border_width*2; i++)
                Console.Write(Border_Symbol);
            for (Int16 i = 1; i <= Border_width - 2; i++)
            {
                Console.SetCursorPosition(Left_position*2, Top_position + i);
                Console.WriteLine(Border_Symbol);
            }
            for (Int16 i = 1; i <= Border_width - 2; i++)
            {
                Console.SetCursorPosition(Left_position*2+ Border_width*2-1, Top_position + i);
                Console.WriteLine(Border_Symbol);
            }
            Console.SetCursorPosition(Left_position*2, Top_position+Border_width-1);
            for (Int16 i = 1; i <= Border_width * 2; i++)
                Console.Write(Border_Symbol);


        }

        public void Drow_Message()
        {
            Console.SetCursorPosition(Left_position*2+ (Border_width*2-Message.Length)/2, Top_position+ Border_width/2);
            Console.Write(Message);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string Message = "A long time ago in a galaxy far, far away...";
            Rectangle Rectangle_1 = new Rectangle();
            //++++++++++++++++++++++++++++++++++++++++++++++++
            /*Юзерские параметры квадрата*/
            Console.WriteLine("Module_2_Lab_2. Ractangle");
            Console.WriteLine("");
            Console.Write("Please set the left position: ");
            Rectangle_1.Left_position=Int16.Parse(Console.ReadLine());
            Console.Write("Please set the Top position: ");
            Rectangle_1.Top_position = Int16.Parse(Console.ReadLine());
            Console.Write("Please set the border width: ");
            Rectangle_1.Border_width = Int16.Parse(Console.ReadLine());
            Console.Write("Please set the message: ");
            Message = Console.ReadLine();
            //++++++++++++++++++++++++++++++++++++++++++++++++
            Rectangle_1.Rectangle_Message(ref Message);
            Rectangle_1.Drow_Rectangle();
            Rectangle_1.Drow_Message();
            Console.ReadLine();
        }
    }
}
