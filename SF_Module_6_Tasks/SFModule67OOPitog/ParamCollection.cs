using System;
using System.Collections.Generic;
using static SFModule67OOPitog.Methods;
using System.Text;
using System.Threading.Tasks;

namespace SFModule67OOPitog
{
    internal class Param
    {
        public string ParamName { get; set; }
        public object ParamValue { get; set; }
        public Param(string paramName, object paramValue)
            {
                ParamName = paramName;
                ParamValue = paramValue;
            }
    }

    internal class ParamCollection
    {
        private Param[] Collection;
        public ParamCollection(Param[] collection)
        {
            this.Collection = collection;
        }
        public void ShowParams()
        {
            foreach (var item in Collection)
            {
                WriteInColor(item.ParamName + ": ", false, 3);
                WriteInColor(Convert.ToString(item.ParamValue), true, 5);
            }
        }
        // Индексатор по массиву
        internal Param this[int index]
        {
            get
            {
                // Проверяем, чтобы индекс был в диапазоне для массива
                if (index >= 0 && index < Collection.Length)
                {
                    return Collection[index];
                }
                else
                {
                    return null;
                }
            }

            private set
            {
                // Проверяем, чтобы индекс был в диапазоне для массива
                if (index >= 0 && index < Collection.Length)
                {
                    Collection[index] = value;
                }
            }
        }

        internal Param? this[string paramName]
        {
            get
            {
                for (int i = 0; i < Collection.Length; i++)
                {
                    if (Collection[i].ParamName == paramName)
                    {
                        return Collection[i];
                    }
                }

                return null;
            }
        }
    }

}
