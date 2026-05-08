using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    public class Question: IQuestion
    {
        private string m_enonce;
        private int m_point;
        private string m_option;

        private string m_indice;
        private int m_penaliteIndice;
        public string Enonce 
        {  get { return m_enonce; } 
            set { if (value == null || value == "") 
                { throw new ArgumentException(); }
                    m_enonce = value.Trim();
            }
        }
        public int Points { get { return m_point; } 
            set { if (value < 0) 
                { throw new ArgumentException(); } 
            
            m_point = value;
            }
        
        }
        public List<string> Options
        {
            get { return m_option; }
            set
            { if (value == null )  { throw new ArgumentNullException(); }
            
                if ( value.Count < 2)
                {
                    throw new ArgumentException();
                }
                m_option = value;
            }
        }
         
        public string Indice
        {
            get { return m_indice ; }
            set
            {
                if (value == null) { throw new ArgumentException(); }

            
            m_indice = value;
            }
        }
      
        public int PenaliteIndice {

            get { return m_penaliteIndice; }
            set { if (value < 0 || value > 1) { throw new ArgumentOutOfRangeException(); }
            
            PenaliteIndice = value;
            }
        
            
        }
    }
    
}
