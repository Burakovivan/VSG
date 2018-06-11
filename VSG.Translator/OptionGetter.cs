using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.Enums;
using VSG.ViewModel.OptionsGetter;

namespace VSG.Translator
{
    public static class OptionGetter
    {
        public static IEnumerable<OptionGetterModel> GetElementTypeOptionList()
        {
            return GetEnumOptions(typeof(ElementType));
        }

        public static IEnumerable<OptionGetterModel> GetElementMediaTypeOptionList()
        {
            return GetEnumOptions(typeof(ElementMediaType));
        }

        public static IEnumerable<OptionGetterModel> GetSelectorTypeOptionList()
        {
            return GetEnumOptions(typeof(SelectorType));
        }

        public static IEnumerable<OptionGetterModel> GetActionOptionList(ElementType elementType)
        {
            if(elementType == ElementType.None)
            {
                return null;
            }

            return GetEnumOptions(elementType == ElementType.Event ? typeof(EventAction) : typeof(TrackAction));
        }

        private static IEnumerable<OptionGetterModel> GetEnumOptions(Type enumType)
        {
            foreach(var e in Enum.GetValues(enumType))
            {
                yield return new OptionGetterModel
                {
                    Description = e.ToString(),
                    Value = (int)e
                };
            }
        }

    }
}
