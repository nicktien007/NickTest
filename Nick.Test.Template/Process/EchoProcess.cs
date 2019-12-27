using System;
using MHAT.ConsoleApp.ProcessTemplate;
using Nick.Test.Template.Model;

namespace Nick.Test.Template.Process
{
    public class EchoProcess : BaseExecuteProcessTemplate<EchoProcessOption>
    {
        protected override void PreProcess()
        {
            Console.WriteLine("準備輸出傳入的參數.....");
            base.PreProcess();
        }

        protected override void Process()
        {
            Console.WriteLine($"您輸入的是：{ArugemntOption.Text}");
            base.Process();
        }

        protected override void PostProcess()
        {
            Console.WriteLine("完成輸出輸入的參數");
            Console.WriteLine("程式關閉");
            base.PostProcess();
        }
    }
}
