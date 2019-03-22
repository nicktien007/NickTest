using System;

namespace Nick.Test.Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();

            heater.Boiled += alarm.MakeAlert;   //註冊方法
            heater.Boiled += (new Alarm()).MakeAlert;      //給匿名對象註冊方法
            heater.Boiled += new Heater.BoiledEventHandler(alarm.MakeAlert);    //也可以這麼註冊
            heater.Boiled += Display.ShowMsg;       //註冊靜態方法

            heater.BoilWater();   //燒水，會自動調用註冊過對象的方法
        }


        public class Heater
        {
            private int temperature;
            public string type = "RealFire 001";       // 添加型號作為演示
            public string area = "China Xian";         // 添加產地作為演示
                                                       //聲明委託
            public delegate void BoiledEventHandler(Object sender, BoiledEventArgs e);
            public event BoiledEventHandler Boiled; //聲明事件

            // 定義BoiledEventArgs類，傳遞給Observer所感興趣的信息
            public class BoiledEventArgs : EventArgs
            {
                public readonly int temperature;
                public BoiledEventArgs(int temperature)
                {
                    this.temperature = temperature;
                }
            }

            // 可以供繼承自 Heater 的類重寫，以便繼承類拒絕其他對象對它的監視
            protected virtual void OnBoiled(BoiledEventArgs e)
            {
                // 如果有對象註冊
                Boiled?.Invoke(this, e);  // 調用所有註冊對象的方法
            }

            // 燒水。
            public void BoilWater()
            {
                for (int i = 0; i <= 100; i++)
                {
                    temperature = i;
                    if (temperature > 95)
                    {
                        //建立BoiledEventArgs 對象。
                        BoiledEventArgs e = new BoiledEventArgs(temperature);
                        OnBoiled(e);  // 調用 OnBolied方法
                    }
                }
            }
        }

        // 警報器
        public class Alarm
        {
            public void MakeAlert(Object sender, Heater.BoiledEventArgs e)
            {
                Heater heater = (Heater)sender;     //這裡是不是很熟悉呢？
                                                    //訪問 sender 中的公共字段
                Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
                Console.WriteLine("Alarm: 嘀嘀嘀，水已經 {0} 度了：", e.temperature);
                Console.WriteLine();
            }
        }

        // 顯示器
        public class Display
        {
            public static void ShowMsg(Object sender, Heater.BoiledEventArgs e)
            {   //靜態方法
                Heater heater = (Heater)sender;
                Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
                Console.WriteLine("Display：水快燒開了，當前溫度：{0}度。", e.temperature);
                Console.WriteLine();
            }
        }
    }
}
