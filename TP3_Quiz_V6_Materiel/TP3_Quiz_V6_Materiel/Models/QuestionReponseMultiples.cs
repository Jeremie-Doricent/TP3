using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    internal class QuestionReponseMultiples : Question
    {
        private List<string>? m_option;

        public List<string> Options
        {
            get { return m_option; }
            set
            {
                if (value == null) { throw new ArgumentNullException(); }

                if (value = "")
                {
                    throw new ArgumentNullException();
                }

                m_option = value;
            }
        }
    }
}
