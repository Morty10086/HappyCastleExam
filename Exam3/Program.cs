namespace Exam3
{

    public class TreasureHuntSystem
    {
        public static int MaxTreasureValue(int[] treasures)
        {
            int max = 0;
            FindNextMax(treasures,0,ref max);
            return max;
        }

        public static int FindNextMax(int[] treasures,int start, ref int max)
        { 

            int sum = 0;
            if (start < treasures.Length)
                sum = treasures[start];
            else
                return 0;
            for (int i = start+2; i < treasures.Length; i++)
            {
                if (start < treasures.Length)
                    sum = treasures[start];
                sum += FindNextMax(treasures,i,ref max);
                max=Math.Max(max,sum);
            }
            return sum;
        }
        //进阶
        public static int MaxTreasureValue2(int[] treasures)
        {
            int max = 0;
            int tempMax = 0;
            for(int i=0;i<treasures.Length;i++)
            {
                FindNextMax2(treasures, 0, ref tempMax, i);
                max = Math.Max(max, tempMax);
            }            
            return max;
        }
        public static int FindNextMax2(int[] treasures, int start, ref int max,int useKeyIndex)
        {
            bool hasKey = false;

            int sum = 0;
            if (start < treasures.Length)
                sum = treasures[start];
            else
                return 0;

            if(start==useKeyIndex) 
                hasKey = true;

            if (hasKey)
            {
                hasKey = false;
                for (int i = start + 1; i < treasures.Length; i++)
                {
                    if (start < treasures.Length)
                        sum = treasures[start];
                    sum += FindNextMax2(treasures, i, ref max, useKeyIndex);
                    max = Math.Max(max, sum);
                }
            }
            else
            {
                for (int i = start + 2; i < treasures.Length; i++)
                {
                    if (start < treasures.Length)
                        sum = treasures[start];
                    sum += FindNextMax2(treasures, i, ref max, hasKey);
                    max = Math.Max(max, sum);
                }
            }
            
            return sum;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] treasures = { 3, 1, 5, 2, 4};
            Console.WriteLine(TreasureHuntSystem.MaxTreasureValue(treasures));
        }
    }
}