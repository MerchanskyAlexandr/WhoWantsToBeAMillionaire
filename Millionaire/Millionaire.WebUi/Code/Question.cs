using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millionaire.WebUi.Code
{
    public class Question
    {
        public string Title { get; set; }

        public string[] Answers { get; set; }

        public int Correct { get; set; }

    }
}