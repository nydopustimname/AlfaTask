using System.IO;
using System.Windows.Forms;

namespace AlfaTask
{
    public class Load
    {
        public string LoadFile(string rtfPathName)
        {
            using (var rtf = new RichTextBox())
            {
                rtf.Rtf = File.ReadAllText(rtfPathName);
                return rtf.Text;
            }
        }
    }
}
