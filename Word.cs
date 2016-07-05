using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnSentencesConparator
{
    public class Word
    {
        private string token;

        public string Token
        {
            get { return this.token; }
            set { this.token = value; }
        }

        private string pos;

        public string Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        private int occ;

        public int Occ
        {
            get { return occ; }
            set { occ = value; }
        }

        public Word(string token, int occ)
        {
            this.Token = token;
            this.Occ = occ;
        }
        public Word()
        {
            this.Token = null;
        }
    }
}
