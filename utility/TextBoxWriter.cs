using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Oxage
{
    public class TextBoxWriter : TextWriter
    {
        private TextBox textbox;
        private StringBuilder content = new StringBuilder();

        public bool Debug { get; set; }

        public TextBoxWriter(TextBox textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            base.Write(value);
            content.Append(value);
            if (value == '\n')
            {
                textbox.Invoke(new CrossThreadDelegate(() =>
                {
                    string message = content.ToString();

                    if (this.Debug)
                    {
                        message = message.Replace("\r", "<cr>");
                        message = message.Replace("\n", "<lf>\n");
                    }

                    textbox.AppendText(message);
                    content = new StringBuilder();
                }));
            }
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }

    public delegate void CrossThreadDelegate();
}
