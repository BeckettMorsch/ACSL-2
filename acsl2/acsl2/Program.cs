using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace acsl2
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = "{32*51+(8/4)*2+43]/24}";    //File.ReadAllText(@"C:\Users\eahscs\Desktop\text.txt");
            String[] lines = input.Split('\n');

            List<int> output = new List<int> { };
            bool lp = false, rp = false, lb = false, rb = false, ls = false, rs = false;

            //determine what is missing
            for (int i = 0; i < lines[0].Length; i++)
            {
                if (lines[0].Substring(i, 1) == "(")
                    lp = true;

                if (lines[0].Substring(i, 1) == ")")
                    rp = true;

                if (lines[0].Substring(i, 1) == "[")
                    lb = true;

                if (lines[0].Substring(i, 1) == "]")
                    rb = true;

                if (lines[0].Substring(i, 1) == "{")
                    ls = true;

                if (lines[0].Substring(i, 1) == "}")
                    rs = true;
            }


            if (rb == false)
            {
                int l = lines[0].IndexOf(")");
                int r = lines[0].IndexOf("}");
                for (int i = l; i < r; i++)
                {
                    if (lines[0].Substring(i, 1) != "+" && lines[0].Substring(i, 1) != "-" && lines[0].Substring(i, 1) != "*" && lines[0].Substring(i, 1) != "/")
                    {
                        if ((i + 2 < lines[0].Length) && (lines[0].Substring(i + 2, 1) != "}") && (lines[0].Substring(i + 2, 1) != "+" && lines[0].Substring(i + 2, 1) != "-" && lines[0].Substring(i + 2, 1) != "*" && lines[0].Substring(i + 2, 1) != "/") && (lines[0].Substring(i + 1, 1) != "+" && lines[0].Substring(i + 1, 1) != "-" && lines[0].Substring(i + 1, 1) != "*" && lines[0].Substring(i + 1, 1) != "/"))
                        {
                            output.Add(i + 4);
                            i = i + 2;
                        }
                        else if ((i + 1 < lines[0].Length) && (lines[0].Substring(i + 1, 1) != "}") && lines[0].Substring(i + 1, 1) != "+" && lines[0].Substring(i + 1, 1) != "-" && lines[0].Substring(i + 1, 1) != "*" && lines[0].Substring(i + 1, 1) != "/")
                        {
                            output.Add(i + 3);
                            i = i + 1;
                        }
                        else
                            output.Add(i + 2);
                    }
                }
            }

            if (lb == false)
            {
                int l = lines[0].IndexOf("{");

                int p;
                for (p = lines[0].IndexOf("]"); p > 0; p--)
                {
                    if (lines[0].Substring(p, 1) == "+" || lines[0].Substring(p, 1) == "-" || lines[0].Substring(p, 1) == "*" || lines[0].Substring(p, 1) == "/")
                        break;
                }
                int r = p;
                //output.Add(l + 2);  Not detecting a triple
                for (int i = r; i > l; i--)
                {
                    if (lines[0].Substring(i, 1) != "+" && lines[0].Substring(i, 1) != "-" && lines[0].Substring(i, 1) != "*" && lines[0].Substring(i, 1) != "/")
                    {

                        if(lines[0].Substring(i,1) == ")")
                        {
                            int ind = lines[0].IndexOf("(");
                            int sub = i - ind;
                            i = i - sub;
                        }
                        


                        if ((i - 2 > 0) && (lines[0].Substring(i - 2, 1) != "{") && lines[0].Substring(i - 2, 1) != "+" && lines[0].Substring(i - 2, 1) != "-" && lines[0].Substring(i - 2, 1) != "*" && lines[0].Substring(i - 2, 1) != "/" )
                        {
                            output.Add(i - 2 + 1);
                            i = i - 2;
                        }
                        else if ((i - 1 > 0) && (lines[0].Substring(i - 1, 1) != "{") && lines[0].Substring(i - 1, 1) != "+" && lines[0].Substring(i - 1, 1) != "-" && lines[0].Substring(i - 1, 1) != "*" && lines[0].Substring(i - 1, 1) != "/")
                        {
                            output.Add(i - 1 + 1);
                            i = i - 1;
                        }
                        else
                            output.Add(i + 1);
                    }
                }
            }
            output.Sort();
            //Finish
            for (int i = 0; i < output.Count; i++)
            {
                Console.Write(output[i] + " ");
            }






            if (rs == false)
            {
                int l = lines[0].IndexOf("]");
                int r = lines[0].Length;
                for (int i = l; i < r; i++)
                {
                    if (lines[0].Substring(i, 1) != "+" && lines[0].Substring(i, 1) != "-" && lines[0].Substring(i, 1) != "*" && lines[0].Substring(i, 1) != "/")
                    {
                        if ((i + 2 < lines[0].Length) && (lines[0].Substring(i + 2, 1) != "}") && (lines[0].Substring(i + 2, 1) != "+" && lines[0].Substring(i + 2, 1) != "-" && lines[0].Substring(i + 2, 1) != "*" && lines[0].Substring(i + 2, 1) != "/") && (lines[0].Substring(i + 1, 1) != "+" && lines[0].Substring(i + 1, 1) != "-" && lines[0].Substring(i + 1, 1) != "*" && lines[0].Substring(i + 1, 1) != "/"))
                        {
                            output.Add(i + 4);
                            i = i + 2;
                        }
                        else if ((i + 1 < lines[0].Length) && (lines[0].Substring(i + 1, 1) != "}") && lines[0].Substring(i + 1, 1) != "+" && lines[0].Substring(i + 1, 1) != "-" && lines[0].Substring(i + 1, 1) != "*" && lines[0].Substring(i + 1, 1) != "/")
                        {
                            output.Add(i + 3);
                            i = i + 1;
                        }
                        else
                            output.Add(i + 2);
                    }
                }
            }

            if (rp == false)
            {
                int p;
                for (p = lines[0].IndexOf("("); p < lines[0].Length; p++)
                {
                    if (lines[0].Substring(p, 1) == "+" || lines[0].Substring(p, 1) == "-" || lines[0].Substring(p, 1) == "*" || lines[0].Substring(p, 1) == "/")
                        break;
                }
                int l = p;
                int r = lines[0].IndexOf("]");
                for (int i = l; i < r; i++)
                {
                    if (lines[0].Substring(i, 1) != "+" && lines[0].Substring(i, 1) != "-" && lines[0].Substring(i, 1) != "*" && lines[0].Substring(i, 1) != "/")
                    {
                        if ((i + 2 < lines[0].Length) && (lines[0].Substring(i + 2, 1) != "]") && (lines[0].Substring(i + 2, 1) != "+" && lines[0].Substring(i + 2, 1) != "-" && lines[0].Substring(i + 2, 1) != "*" && lines[0].Substring(i + 2, 1) != "/") && (lines[0].Substring(i + 1, 1) != "+" && lines[0].Substring(i + 1, 1) != "-" && lines[0].Substring(i + 1, 1) != "*" && lines[0].Substring(i + 1, 1) != "/"))
                        {
                            output.Add(i + 4);
                            i = i + 2;
                        }
                        else if ((i + 1 < lines[0].Length) && (lines[0].Substring(i + 1, 1) != "]") && lines[0].Substring(i + 1, 1) != "+" && lines[0].Substring(i + 1, 1) != "-" && lines[0].Substring(i + 1, 1) != "*" && lines[0].Substring(i + 1, 1) != "/")
                        {
                            output.Add(i + 3);
                            i = i + 1;
                        }
                        else
                            output.Add(i + 2);
                    }
                }
            }




            //Finish
            for (int i = 0; i < output.Count; i++)
            {
                Console.Write(output[i] + " ");
            }

        }
    }
}


