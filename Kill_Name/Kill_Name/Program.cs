using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Kill_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入进程前缀：");
            string ProcName = Console.ReadLine();
            while (true)
            {
                try
                { KillProcA(ProcName); }
                catch
                { continue;
                  
                 }
                Thread.Sleep(10);
            }
        }



        public static void KillProcA(string strProcName)
        {
            try
            {
                //模糊进程名  枚举
                //Process[] ps = Process.GetProcesses();  //进程集合
                foreach (Process p in Process.GetProcesses())
                {
                    

                    if (p.ProcessName.IndexOf(strProcName) > -1)  //第一个字符匹配的话为0，这与VB不同
                    {
                        Console.WriteLine(p.ProcessName +": "+ p.Id);
                        try
                        { p.Kill(); }
                        catch
                        { continue; }
                        /*
                        if (!p.CloseMainWindow())
                        {
                            p.Kill();
                        }
                        */
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}
