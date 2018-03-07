using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadConsole
{
    public class ImageFile:TextFile
    {

        private const string flg_Content = "Content:";
        private const string flg_Resolution = "Resolution:";

        public override string GetContent(string SomeText)
        {
            string Cur_text = base.GetContent(SomeText);
            
            Cur_text = Cur_text.Replace(flg_Content, flg_Resolution);

            return Cur_text;


        }
    }
}
