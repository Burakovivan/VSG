using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG.Model.Enums
{
    [AttributeUsage(AttributeTargets.Method)]
    public class VSGMethodTypeAttribute : Attribute
    {
        public MethodType MethodType { get; set; } 
    }
}
