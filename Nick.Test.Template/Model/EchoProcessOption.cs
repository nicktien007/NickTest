using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace Nick.Test.Template.Model
{
    public class EchoProcessOption
    {
        [Option('t', "text", Required = true, HelpText = "要console呈現的內容")]
        public string Text { get; set; }
    }
}
