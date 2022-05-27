using Autofac;
using LK.Api;
using LK.EntityFrameworkCore;
using LK.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.LKAutofac
{
    public class AutofacHelper
    {

        private static IContainer container;


        static AutofacHelper()
        {
            //构造函数中添加如下代码
            var builder = new ContainerBuilder();

            //builder.RegisterType<FirstModel>().As<IService>("First").;
            //builder.RegisterType<SecondModel>().Named<IService>("Second");
            //builder.RegisterType<SecondModel>().Named<ISecondService>("Second");
            //builder.RegisterType<ThirdModel>();
            //builder.RegisterInstance(this).As<Form>();

            var ass = AutofacHelper.GetAssembly();
            builder.RegisterAssemblyModules(ass);

            container = builder.Build();
            
        }


        public static Assembly[] GetAssembly()
        {
            Assembly[] ass = {
                typeof(ApplicationMoudle).Assembly,
                typeof(InfrastructureMoudle).Assembly,
                typeof(EntityFrameworkCoreMoudle).Assembly,
                typeof(DomainMoudle).Assembly,
                typeof(ApiMoudle).Assembly };
            return ass;
        }


    }
}
