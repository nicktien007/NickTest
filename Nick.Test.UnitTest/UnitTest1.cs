using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nick.Test.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            RefPoint rPoint1 = new RefPoint(1);
            RefPoint rPoint2 = new RefPoint(1);

            //act
            var result = (rPoint1 == rPoint2);

            //assert
            Assert.AreEqual(result, false);
        }


        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            ValPoint vPoint1 = new ValPoint(1);
            ValPoint vPoint2 = vPoint1;

            //act
            var result = Object.ReferenceEquals(vPoint1, vPoint2); // 隱式裝箱，指向了堆上的不同對象

            //assert
            Assert.AreEqual(result, false);
        }

        /// <summary>
        /// 定義一個引用類型
        /// </summary>
        public class RefPoint
        {      
            public int x;
            public RefPoint(int x)
            {
                this.x = x;
            }
        }


        /// <summary>
        /// 定義一個值類型
        /// </summary>
        public struct ValPoint
        { 
            public int x;
            public ValPoint(int x)
            {
                this.x = x;
            }
        }
    }
}
