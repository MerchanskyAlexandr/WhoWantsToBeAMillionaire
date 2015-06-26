﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.WebUi.Code.Pattern.Repository
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAllQuestions();
    }
}
