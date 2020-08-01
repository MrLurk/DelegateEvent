using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Services
{
    public delegate void NoReturnNoParameter();
    public class HomeService
    {

        public void FuncMain()
        {
            // 调用没参数,没返回值得方法
            NoReturnNoParameter delegate1 = new NoReturnNoParameter(FuncNoReturnNoParameter);
            delegate1();

            ActionMethod();

            FuncMethod();
            EventMethod();
        }

        #region 委托

        /// <summary>
        /// 没有参数,没有返回值得方法
        /// </summary>
        public void FuncNoReturnNoParameter()
        {
            Console.WriteLine("没有参数,没有返回值得方法");
        }

        public void ActionMethod()
        {
            Action<int, string> action = new Action<int, string>(ActionTest);
            action(18, "张三");
            Action<int, string> action2 = new Action<int, string>((age, name) =>
            {
                Console.WriteLine($"我是{name},今年{age}岁");
            });
            action2(19, "李四");
        }

        public void ActionTest(int age, string name)
        {
            Console.WriteLine($"我是{name},今年{age}岁");
        }

        public void FuncMethod()
        {
            Func<int, string> func = new Func<int, string>(FuncTest);
            var res = func(18);
            Console.WriteLine(res);
            Func<int, string> func2 = new Func<int, string>((age) =>
            {
                return $"我叫李四,今年{age}岁";
            });
            var res2 = func2(19);
            Console.WriteLine(res2);
        }

        public string FuncTest(int age)
        {
            return $"我是张三,今年{age}岁";
        }

        #endregion

        #region 事件
        public void EventMethod() {
            Cat cat = new Cat();
            cat.CatCall += Cat_CatCall;
            cat.Call();
        }

        private void Cat_CatCall()
        {
            Mouse mouse = new Mouse();
            mouse.Run();
        }
        #endregion
    }
}
