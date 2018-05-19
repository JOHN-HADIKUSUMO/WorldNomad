using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.Logic
{
    public enum FilterType
    {
        NoFilter = 0,
        OddNumberOnly = 1,
        EvenNumberOnly = 2,
        Combination = 3
    }

    public static class Utilities
    {
        public static int[] Create(int limit)
        {
            return Enumerable.Range(1, limit).ToArray();
        }

        public static string[] Filter(int[] item,FilterType filterType)
        {
            if(filterType == FilterType.NoFilter)
            {
                return item.Select(s => s.ToString()).ToArray();
            }
            else
            {
                int max = item.Length;
                string[] result;
                StringBuilder temp = new StringBuilder();
                for (int i = 0; i < max; i++)
                {
                    if(filterType == FilterType.OddNumberOnly)
                    {
                        if((item[i] % 2) > 0)
                        {
                            if (temp.Length > 0)
                                temp.Append(",");
                            temp.Append(item[i]);
                        }
                    }
                    else if(filterType == FilterType.EvenNumberOnly)
                    {
                        if ((item[i] % 2) == 0)
                        {
                            if (temp.Length > 0)
                                temp.Append(",");
                            temp.Append(item[i]);
                        }
                    }
                    else /* Combination */
                    {
                        if (temp.Length > 0)
                            temp.Append(",");

                        bool conditionA = (item[i] % 3 == 0);
                        bool conditionB = (item[i] % 5 == 0);

                        if(!conditionA && !conditionB)
                        {
                            temp.Append(item[i]);
                        }
                        else
                        {
                            if (conditionA && conditionB)
                            {
                                temp.Append("Z");
                            }
                            else
                            {
                                temp.Append(conditionA?"C":"E");
                            }
                        }
                    }
                }
                result = temp.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                return result;
            }
        }
    }
}
