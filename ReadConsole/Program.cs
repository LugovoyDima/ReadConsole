using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace ReadConsole
{
	

	class Program
	{
		
		

		static void Main(string[] args)
		{
			string Const_Text = "Text:";
			string Const_Image = "Image:";
			string Const_Movie = "Movie:";
			string Flg_Delimeter = ":";

            string Rezult_Text = "Text files:";
            string Rezult_Image = "Images:";
			string Rezult_Movie="Movies:";

            


			string text = @"Text: file.txt(6B); Some string content
Image: img.bmp(19MB); 1920х1080
  Text:data.txt(12B); Another string
   Text:data1.txt(7B); Yet another string
	Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";

			string[] Arr_Lines = Regex.Split(text, "\r\n|\r|\n");
			int count_arr_l = Arr_Lines.Length;
			for (int i = 0; i <= count_arr_l-1; i++)
			{
				string Current_Line = Arr_Lines[i].Trim();
				var Position_Delimeter = Current_Line.IndexOf(Flg_Delimeter);
				string First_Word = Current_Line.Substring(0, Position_Delimeter+1);
				int Len_Count = Current_Line.Length- Position_Delimeter-1;
				string Text_For_Check = Current_Line.Substring(Current_Line.Length - Len_Count, Len_Count).Trim();
				//text
				bool Check_Text = First_Word.Equals(Const_Text, StringComparison.Ordinal);
				if (Check_Text)
				{
					TextFile ob_text = new TextFile();                   
                    Rezult_Text = Rezult_Text + ob_text.GetContent(Text_For_Check);                    

				}
				//Image
				bool Check_Image = First_Word.Equals(Const_Image, StringComparison.Ordinal);
				if (Check_Image)
				{
                    ImageFile ob_Image = new ImageFile();
                    Rezult_Image = Rezult_Image + ob_Image.GetContent(Text_For_Check);    
				}
				//Movie
				bool Check_Movie = First_Word.Equals(Const_Movie, StringComparison.Ordinal);
				if (Check_Movie)
				{
                    Movie_2 ob_Movie = new Movie_2();
                    Rezult_Movie = Rezult_Movie + ob_Movie.GetContent(Text_For_Check); 
				}
			}

            Console.WriteLine(Rezult_Text.ToString());
            Console.WriteLine(Rezult_Movie.ToString());
            Console.WriteLine(Rezult_Image.ToString());

            Console.ReadKey();
		}
	}
}
