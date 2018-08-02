using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFormat
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string fileName = "names.txt";
            

            using (var filestream = new System.IO.FileStream(fileName,
                                        System.IO.FileMode.Open,
                                        System.IO.FileAccess.Read,
                                        System.IO.FileShare.ReadWrite))
            using (var file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8))
            {
                string line, first, last;
                int count;
                List<string> nameList = new List<string>();

                while ((line = file.ReadLine()) != null)
                {
                    var words = line.Split(null).Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s));                    
                    count = words.Count();
                    //Console.WriteLine(count);

                    first = words.ElementAt(0);

                    if (count < 3)
                    {
                        last = words.ElementAt(1);
                    }
                    else
                    {
                        if (words.ElementAt(2) == null)
                        {
                            last = words.ElementAt(1);
                        }
                        else
                        {
                            last = words.ElementAt(2);
                        }
                                              
                    }
                    
                    nameList.Add(last + ", " + first);                  
                    
                }

                foreach (var name in nameList)
                {
                    Console.WriteLine(name);
                }

                /*
                using (System.IO.StreamWriter fileOut = new System.IO.StreamWriter("namesOut.txt"))
                {
                    foreach (var name in nameList)
                    {
                        fileOut.WriteLine(name);
                    }
                }  
                */
            }

            Console.WriteLine();
            

        }
    }
}
