namespace Exam4
{
    public class TalentAssessmentSystem
    {
        public static double FindMedianTalentIndex(int[] fireAbility, int[] iceAbility)
        {
            // 在这⾥实现你的代码
            int left = 0;
            int right = 0;
            int[] array=new int[fireAbility.Length+iceAbility.Length];
            for(int i = 0;i< fireAbility.Length+iceAbility.Length; i++)
            {
                if (left >= fireAbility.Length)
                {
                    array[i] = iceAbility[right];
                    right++;
                    continue;
                }
                else if (right >= iceAbility.Length) 
                {
                    array[i] = fireAbility[left];
                    left++;
                    continue;
                }

                if (fireAbility[left] < iceAbility[right]) 
                {
                    array[i] = fireAbility[left];
                    left++;
                }
                else
                {
                    array[i] = iceAbility[right];
                    right++;
                }
            }

            double mid = 0;
            int num = array.Length;
            if(num%2==0)
            {
                mid = (double)(array[num / 2] + array[num / 2 - 1]) / 2;
            }
            else
            {
                mid = (double)array[num / 2];
            }

            return mid;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fireAbility=new int[]{1,3,7,9,11};
            int[] iceAbility=new int[] {2,4,8,10,12,14};
            Console.WriteLine(TalentAssessmentSystem.FindMedianTalentIndex(fireAbility, iceAbility));
        }
    } 
}