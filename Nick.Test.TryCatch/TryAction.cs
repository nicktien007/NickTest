using System;
using System.Collections.Generic;
using System.Text;

namespace Nick.Test.TryCatch
{
    public static class TryAction
    {
        public static bool TryExec(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception e)
            {
                //log..
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static bool TryExec(Action action, Action<Exception> actionFailed)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                // 保存日誌
                actionFailed(ex);
            }
            return false;
        }
    }
}
