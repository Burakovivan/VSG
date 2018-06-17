using System;
using VSG.ViewModel.Enums;

namespace VSG.ViewModel.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class VSGMethodActionTypeAttribute : Attribute
    {
        public MethodAction MethodAction { get; set; }
    }
}
