using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Cat
    {
        /// <summary>
        /// 猫叫了事件处理委托
        /// </summary>
        public delegate void CatCallEventHander();

        public event CatCallEventHander CatCall;

        /// <summary>
        /// 猫叫了
        /// </summary>
        public void Call()
        {
            Console.WriteLine("猫发出叫声!");
            CatCall?.Invoke();
        }
    }
}
