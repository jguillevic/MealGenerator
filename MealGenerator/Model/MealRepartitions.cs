using MealGenerator.Helper;
using System.Collections.Generic;

namespace MealGenerator.Model
{
    public class MealRepartitions
    {
        private Dictionary<Days, MealTimes> _innerDic;

        public MealTimes this[Days day]
        {
            get { return _innerDic[day]; }
            set { _innerDic[day] = value; }
        }

        public MealRepartitions() : this(Days.Monday 
            | Days.Tuesday 
            | Days.Wednesday 
            | Days.Thursday 
            | Days.Friday 
            | Days.Saturday 
            | Days.Sunday) { }

        public MealRepartitions(Days days)
        {
            _innerDic = new Dictionary<Days, MealTimes>();

            foreach (Days day in EnumHelper.GetFlags(days))
            {
                    _innerDic.Add(day, MealTimes.None);
            }
        }

        public List<KeyValuePair<Days, MealTimes>> GetAllElements()
        {
            var elements = new List<KeyValuePair<Days, MealTimes>>();

            foreach (var key in _innerDic.Keys)
            {
                elements.Add(new KeyValuePair<Days, MealTimes>(key, _innerDic[key]));
            }

            return elements;
        }
    }
}
