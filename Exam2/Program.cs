namespace Exam2
{
    public class EnergyFieldSystem
    {
        public static float MaxEnergyField(int[] heights)
        {
            float maxEnergy = 0;
            float energy = 0;
            for(int i=0;i<heights.Length; i++)
            {
                if (heights[i] == 0)
                    continue;
                for(int j=i+1;j<heights.Length;j++)
                {
                    if (heights[j] == 0)
                        continue;
                    energy = (float)(j-i)*(heights[i] + heights[j])/2;
                    maxEnergy=Math.Max(maxEnergy, energy);
                }
            }
            return maxEnergy;
        }
    }

    //main函数中测试
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.WriteLine(EnergyFieldSystem.MaxEnergyField(heights));
        }
    }
}