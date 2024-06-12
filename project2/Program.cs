using System;
using System.Collections.Generic;
using project2;
using storeBl.Bl;
 

namespace project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string exit = "a";
            // cheeck if user enter null
            if (exit != null)
            {
                // make loop for exit programe
                while (exit != "e")
                {
                    // call main option
                    uiHelper.MainOption();
                    int options;
                    bool isCheckOptions = int.TryParse(Console.ReadLine(), out options);
                    // make if to check options
                    if (!isCheckOptions || options < 0 || options > 5)
                    {
                        Console.WriteLine("invaled option");
                    }
                    else
                    {
                        while (options != 0)
                        {
                            switch (options)
                            {
                                case 1:
                                    Console.Clear();
                                    uiHelper.storeOPtions();
                                    break;
                                case 2:
                                    Console.Clear();
                                    uiHelper.itemOptions();
                                    break;
                                case 3:
                                    Console.Clear();
                                    uiHelper.orderOPtions();
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    break;

                            }
                            break;

                        }
                    }
                    Console.WriteLine("for exit press e else press any key");
                    exit = Console.ReadLine();
                }
            }
            else { Console.WriteLine("invaled option"); }



            Console.ReadKey();

        }
    }
}
