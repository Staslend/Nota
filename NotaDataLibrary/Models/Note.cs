using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaDataLibrary.Models
{
    public class Note
    {
        public Note()
        {
            this.subject = "";
            this.text = "";
        }
        public Note(string subject, string text)
        {
            this.subject = subject;
            this.text = text;
        }

        public int id { get; set; }
        public string subject { get; set; }
        public string text { get; set; }
    }
}
