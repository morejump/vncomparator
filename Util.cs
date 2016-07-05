using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace VnSentencesConparator
{
    public static class Util
    {
        /// <summary>
        /// kiểm tra file có phải txt file không
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool isTextFile(this string fileName)
        {
            return (fileName.EndsWith(".txt"));
        }
        /// <summary>
        /// copy file
        /// </summary>
        /// <param name="source"></param>
        /// <param name="des"></param>
        /// <returns></returns>
        public static bool copyFile(string source, string des)
        {
            try
            {
                // copy overwrite
                File.Copy(source, des, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// lấy thông tin vector đặc trưng để hiển thị
        /// </summary>
        /// <param name="vecN"></param>
        /// <param name="vecV"></param>
        /// <param name="vecA"></param>
        /// <param name="vecO"></param>
        /// <returns></returns>
        public static string getVectorInfo(double[] vecN, double[] vecV, double[] vecA, double[] vecO)
        {
            string vectorInfo = "Feature vector: "
                + "\nNoun:  (";
            if (vecN.Length == 0)
            {
                vectorInfo += "0";
            }
            else
            {
                for (int i = 0; i < vecN.Length; i++)
                {
                    vectorInfo += string.Format("{0:0.#####}", vecN[i]);
                    if (i < vecN.Length - 1)
                    {
                        vectorInfo += "  ";
                    }
                }
            }
            vectorInfo += ")\nVerb:   (";
            if (vecV.Length == 0)
            {
                vectorInfo += "0";
            }
            else
            {
                for (int i = 0; i < vecV.Length; i++)
                {
                    vectorInfo += string.Format("{0:0.#####}", vecV[i]);
                    if (i < vecV.Length - 1)
                    {
                        vectorInfo += "  ";
                    }
                }
            }
            vectorInfo += ")\nAdj:     (";
            if (vecA.Length == 0)
            {
                vectorInfo += "0";
            }
            else
            {
                for (int i = 0; i < vecA.Length; i++)
                {
                    vectorInfo += string.Format("{0:0.#####}", vecA[i]);
                    if (i < vecA.Length - 1)
                    {
                        vectorInfo += "  ";
                    }
                }
            }
            vectorInfo += ")\nOther: (";
            if (vecO.Length == 0)
            {
                vectorInfo += "0";
            }
            else
            {
                for (int i = 0; i < vecO.Length; i++)
                {
                    vectorInfo += string.Format("{0:0.#####}", vecO[i]);
                    if (i < vecO.Length - 1)
                    {
                        vectorInfo += "  ";
                    }
                }
            }
            vectorInfo += ")";
            return vectorInfo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listWord"></param>
        /// <param name="numOfSentences"></param>
        /// <returns></returns>
        public static string combineListWordToString(List<Word> listWord, int numOfSentences)
        {
            string output = "";
            foreach (Word word in listWord)
            {
                output += word.Token + "(" + word.Pos + ";" + String.Format("{0:0.#####}", (double)word.Occ / numOfSentences) + ") ";
            }
            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string normalizeString(string input)
        {
            string output;
            output = Regex.Replace(input.Trim(), @"\W", " ");
            output = Regex.Replace(input.Trim(), @"\s+", " ");
            return output;
        }
        ///
        public static double cosineSimilarity(double[] vec1, double[] vec2)
        {
            double multipleVec = 0;
            double magVec1 = 0;
            double magVec2 = 0;
            double multipleVecMagtitude = 0;
            for (int i = 0; i < vec1.Length; i++)
            {
                multipleVec += (vec1[i] * vec2[i]);
                magVec1 += (vec1[i] * vec1[i]);
                magVec2 += (vec2[i] * vec2[i]);
            }
            magVec1 = Math.Sqrt(magVec1);
            magVec2 = Math.Sqrt(magVec2);
            multipleVecMagtitude = magVec1 * magVec2;
            if (multipleVec == 0)
            {
                if (magVec1 != 0 || magVec2 != 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            return multipleVec / multipleVecMagtitude;
        }
    }
}
