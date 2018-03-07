using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ReadConsole
{
    public class Movie_2 : TextFile
    {
        private const string flg_Extension = "Extension:";
        private const string flg_Size = "Size:";
        private const string flg_Content = "Content:";

        private const string flg_Resolution = "Resolution:";
        private const string flg_Length = "Length:";

        private const string flg_NewLine = "\r\n";
        private const string flg_Tab = "\t";

        string Flg_1 = "(";
        string Flg_2 = ")";
        string Flg_3 = ";";
        string Flg_Dot = ".";
        string val_result = "";

        public override string GetContent(string SomeText)
        {
            string Cur_text = base.GetContent(SomeText);

            //get resolution
            var Position_Flg_3 = SomeText.IndexOf(Flg_3);
            int Len_Count3 = SomeText.Length - Position_Flg_3;
            string cur_content = SomeText.Substring(SomeText.Length - Len_Count3, Len_Count3).Trim();
            cur_content = cur_content.Trim();
            string[] Arr_OtherContent = cur_content.Split(';');

            string cur_resolution = Arr_OtherContent[1].ToString().Trim();
            string cur_length = Arr_OtherContent[2].ToString().Trim();

            //create lines Resolution and Length 
            string line_Resolution=flg_Resolution + " " + cur_resolution + flg_NewLine+flg_Tab + flg_Tab ;
            string line_Lenght = flg_Length + " " + cur_length + flg_Tab + flg_Tab;

            string[] Arr_Lines = Regex.Split(Cur_text, "\r\n|\r|\n");
            int count_arr_l = Arr_Lines.Length;

            string val_result = "";
            for (int i = 0; i <= count_arr_l - 1; i++)
            {
                string Current_Line = Arr_Lines[i].Trim();
                Boolean Contain_Word = Current_Line.Contains(flg_Content);
                if (Contain_Word)
                {
                    string Current_Line_New;
                    Current_Line_New = flg_Tab + flg_Tab + flg_Resolution + " " + cur_resolution + flg_NewLine + flg_Tab + flg_Tab +
                                               flg_Length + " " + cur_length + flg_Tab + flg_Tab;
                    Arr_Lines[i] = Current_Line_New;
                }
                val_result = val_result + Arr_Lines[i] + flg_NewLine;
            }
            //''''''''''''''''''''''''
            return val_result;

        }
    }
}
