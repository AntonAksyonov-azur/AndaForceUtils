using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndaForceExtensions.com.andaforce.arazect.collections.linq
{
    public static class ClonedLinqSumMethods
    {
        public static float ClonedSum(this List<float> list)
        {
            var result = 0.0f;
            foreach (var f in list)
            {
                result += f;
            }

            return result;
        }
    }
}
