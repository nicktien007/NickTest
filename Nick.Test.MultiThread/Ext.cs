using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nick.Test.MultiThread
{
    public static class Ext
    {
        public static IEnumerable<TResult> Convert<TResult>(this IEnumerable sequence)
        {
            foreach (var item in sequence)
            {
                dynamic coercion = (dynamic)item;
                yield return (TResult)coercion;
            }
        }
    }
}
