using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using Microsoft.SqlServer.Server;

namespace Millionaire
{
    public class Question
    {
        public string Title { get; set; }

        public string[] Answers { get; set; }

        public int Correct { get; set; }
    }
}
