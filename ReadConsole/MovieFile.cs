using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadConsole
{
    public class MovieFile
    {
        protected readonly string Content;


        private const string flg_Extension = "Extension:";        
        private const string flg_Size = "Size:";

        private const string flg_Resolution = "Resolution:";
        private const string flg_Length = "Length:";

        private const string flg_NewLine = "\r\n";
        private const string flg_Tab = "\t";

        string Flg_1 = "(";
        string Flg_2 = ")";
        string Flg_3 = ";";
        string Flg_Dot = ".";


        public string GetContent(string SomeText)
        {

            //get file name+file extension
            var Position_Flg_1 = SomeText.IndexOf(Flg_1);
            string cur_file = SomeText.Substring(0, Position_Flg_1);
            var Position_Dot = SomeText.IndexOf(Flg_Dot);
            string cur_extension = cur_file.Substring(cur_file.Length - Position_Dot + 1).Trim();

            int Len_Count = SomeText.Length - Position_Flg_1 - 1;
            string Step_2_SomeText = SomeText.Substring(SomeText.Length - Len_Count, Len_Count).Trim();

            //get file size
            var Position_Flg_2 = Step_2_SomeText.IndexOf(Flg_2);
            string cur_size = Step_2_SomeText.Substring(0, Position_Flg_2);
            int Len_Count2 = Step_2_SomeText.Length - Position_Flg_1 - 1;
            string Step_3_SomeText = Step_2_SomeText.Substring(Step_2_SomeText.Length - Len_Count, Len_Count).Trim();

            //get content
            var Position_Flg_3 = Step_3_SomeText.IndexOf(Flg_3);
            int Len_Count3 = Step_3_SomeText.Length - Position_Flg_3;
            string cur_content = Step_2_SomeText.Substring(Step_3_SomeText.Length - Len_Count3, Len_Count3).Trim();
            cur_content = cur_content.Trim();
            string[] Arr_OtherContent = cur_content.Split(';');

           
            
             string cur_resolution = Arr_OtherContent[1].ToString().Trim();
             string cur_length = Arr_OtherContent[2].ToString().Trim();
            

            
            cur_file = flg_NewLine + flg_Tab +
                                    cur_file + flg_NewLine + flg_Tab + flg_Tab +
                                               flg_Extension + " " + cur_extension + flg_NewLine + flg_Tab + flg_Tab +
                                               flg_Size + " " + cur_size + flg_NewLine + flg_Tab + flg_Tab +
                                               flg_Resolution + " " + cur_resolution + flg_NewLine+flg_Tab + flg_Tab +
                                               flg_Length + " " + cur_length+ flg_Tab + flg_Tab ;

            return cur_file;
        }
    }
}
