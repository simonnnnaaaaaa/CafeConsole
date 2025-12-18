using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Preparation
{
    public static class BeveragePreparationFactory
    {
        public static BeveragePreparationTemplate Create(string beverageType)
        {
            if (string.IsNullOrWhiteSpace(beverageType))
            {
                return null;
            }

            return beverageType.ToLower() switch
            {
                "espresso" => new EspressoPreparation(),
                "tea" => new TeaPreparation(),
                "hot chocolate" => new HotChocolatePreparation(),
                _ => throw new ArgumentException("Unknown beverage type")
            };
        }
    }
}
