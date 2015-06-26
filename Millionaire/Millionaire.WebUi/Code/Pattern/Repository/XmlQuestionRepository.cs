using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Millionaire.WebUi.Code.Pattern.Repository
{
    public class XmlQuestionRepository
    {
        #region Fields

        private readonly string _path;

        public Question[] Questions { get; set; }

        public int QuestionCount { get; set; }

        #endregion

        #region Ctor

        public XmlQuestionRepository(string path)
        {
            QuestionCount = 0;
            _path = path;
        }
        #endregion

        #region IQuestionRepository

        public IEnumerable<Question> GetAllQuestions()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Question[]));
            using (
                FileStream fs =
                    new FileStream(
                        _path,
                        FileMode.OpenOrCreate))
            {
                Questions = (Question[])formatter.Deserialize(fs);
            }
            return Questions;
        }

        #endregion
    }
}