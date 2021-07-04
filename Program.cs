using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumLoss
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<long> priceList = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

            long loss = minimumLoss(priceList);

            Console.WriteLine(loss);
        }

   
        private static long minimumLoss(List<long> priceList)
        {
            long minLoss = long.MaxValue;
            //O(n)
            Dictionary<long, int> priceDictionary = new Dictionary<long, int>();

            for(int i = 0; i < priceList.Count; i++)
            {
                if (!priceDictionary.ContainsKey(priceList[i]))
                {
                    priceDictionary.Add(priceList[i], i);
                }
                
            }

            var priceArray = priceList.ToArray();

            Array.Sort(priceArray);

            for(int i=priceArray.Length-1; i>0; i--)
            {
                long dif = priceArray[i] - priceArray[i - 1];
                if (dif < minLoss)
                {
                    if (priceDictionary[priceArray[i]] < priceDictionary[priceArray[i - 1]])
                    {
                        minLoss = dif;
                    }
                }

            }


            //O(n^2)
            //for (int i = 0; i < priceList.Count - 1; i++)
            //{
            //    for (int j =i+1; j <= priceList.Count-1; j++)
            //    {
            //        var diffItem = (priceList[i] - priceList[j]);
            //        if (diffItem > 0)
            //        {
            //            minLoss = Math.Min(minLoss, diffItem);
            //        }

            //    }


            //}

            return minLoss;
        }
    }
}
