using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nick.Test
{
    public class ClassB
    {
        public static readonly ClassB Instance = new ClassB();
        private static int _count;
        private ClassB()
        {
            ++_count;



            if (true)
            {
                if (true)
                {
                    if (true)
                    {
                        if (true)
                        {
                            if (true)
                            {
                                if (true)
                                {
                                    if (true)
                                    {
                                        if (true)
                                        {
                                            if (true)
                                            {
                                                if (true)
                                                {
                                                    if (true)
                                                    {
                                                        if (true)
                                                        {
                                                            if (true)
                                                            {
                                                                if (true)
                                                                {
                                                                    string a = "aa";
                                                                    switch (a)
                                                                    {
                                                                        case "a":
                                                                            break;
                                                                        case "b":
                                                                            break;
                                                                        case "c":
                                                                            break;
                                                                        case "d":
                                                                            break;
                                                                            
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public int Count => _count;
    }
}
