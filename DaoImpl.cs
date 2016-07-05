using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnSentencesConparator
{
    class DaoImpl
    {
        public static bool checkConnection(string dbName)
        {
            try
            {
                SqlConnection conn = new SqlConnection("SData Source=HP;Initial Catalog=dbVSC;Integrated Security=True");
                conn.Open();
                conn.Close();
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }
        public DataTable convertDictToDataTable(Dictionary<string, Word> dict)
        {
            DataTable dt = new DataTable("tbl_dictionary");
            DataColumn col1 = new DataColumn("word", typeof(String));
            DataColumn col2 = new DataColumn("pos", typeof(String));
            DataColumn col3 = new DataColumn("occ", typeof(Int32));
            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            foreach (var item in dict)
            {
                DataRow row = dt.NewRow();
                string[] path = item.Value.Token.Split('/');
                if (path.Length > 1)
                {
                    row[0] = path[0];
                    row[1] = path[1];
                }
                else
                {
                    row[0] = item.Value.Token;
                    row[1] = null;
                }
                row[2] = item.Value.Occ;
                dt.Rows.Add(row);
            }
            return dt;
        }
        public int updateDictionary(string dbName, DataTable dt)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection("SData Source=HP;Initial Catalog=dbVSC;Integrated Security=True"))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("update_dictionary"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblDictionary", dt);
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("EXCEPTION: " + e.Message);
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                    return 0;
                }
            }
            return result;
        }
        public int getWordNumber(string dbName)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection("SData Source=HP;Initial Catalog=dbVSC;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select count(*) from tbl_dictionary", conn);
            conn.Open();
            count = (Int32)cmd.ExecuteScalar();
            conn.Close();
            return count;
        }
        public int getSentenceNumber(string dbName)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection("SData Source=HP;Initial Catalog=dbVSC;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"select occ from tbl_dictionary where word = '.'", conn);
            conn.Open();
            count = (Int32)cmd.ExecuteScalar();
            conn.Close();
            return count;
        }
        public List<Word> separateWord(string dbName, string sentence)
        {
            List<Word> words = new List<Word>();
            string[] syllables = sentence.Split(' ');
            StringBuilder strBuilder = new StringBuilder("");
            for (int i = 0; i < syllables.Length; i++)
            {
                Word word = new Word(syllables[i], 1);
                word.Pos = "X";
                for (int j = 0; j + i < syllables.Length; j++)
                {
                    strBuilder.Append(syllables[i + j] + " ");
                    string str = strBuilder.ToString().Trim().Replace(" ", "_");
                    if (checkWordExist(dbName, str))
                    {
                        word = getWordFromDB(dbName, str);
                        i = j + i;
                    }
                    else if (j > 3 && word.Pos.Equals("X"))
                    {
                        break;
                    }
                }
                strBuilder.Clear();
                words.Add(word);
            }
            return words;
        }

        public bool checkWordExist(string dbName, string str)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection("SData Source=HP;Initial Catalog=dbVSC;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"select count(*) from tbl_dictionary where word = N'" + str + "' collate SQL_Latin1_General_CP1_CS_AS", conn);
            conn.Open();
            count = (Int32)cmd.ExecuteScalar();
            conn.Close();
            return count != 0;
        }

        public Word getWordFromDB(string dbName, string str)
        {
            Word word = new Word();
            SqlConnection conn = new SqlConnection("SData Source=HP;Initial Catalog=dbVSC;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"select top 1 * from tbl_dictionary where word = N'" + str + "' collate SQL_Latin1_General_CP1_CS_AS", conn);
            conn.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    word.Token = dr["word"].ToString();
                    word.Pos = dr["pos"].ToString();
                    word.Occ = Convert.ToInt32(dr["occ"].ToString());
                }
            }
            conn.Close();
            if (word.Token == null)
            {
                return null;
            }
            else
            {
                return word;
            }
        }
    }
}
