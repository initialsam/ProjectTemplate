using EF.Diagnostics.Profiling;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure.AOP
{
    class NanoPrifilerBehavior : IInterceptionBehavior
    {
        public bool WillExecute
        {
            get { return true; }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn msg;
            using (ProfilingSession.Current.Step($"{input.MethodBase.DeclaringType.Name} - {input.MethodBase.Name}"))
            {
                var a = input.Arguments["appName"].ToString();
                if (a == "z")
                {
                    return input.CreateMethodReturn("87");
                }
               
                msg = getNext()(input, getNext);
            }
            return msg;
        }
    }
}