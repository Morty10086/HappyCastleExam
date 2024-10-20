using System;
using System.Collections.Generic;

namespace HappyCastleExam
{
    public class LeaderboardSystem
    {
        public static List<int> GetTopScores(int[] scores, int m)
        {
            // 在这⾥实现你的代码
            if(scores.Length == 0||m>scores.Length)
                return null;

            QuickSort(scores, 0, scores.Length - 1);
            List<int> result = new List<int>();
            for (int i = 0; i < m; i++)
            {
                result.Add(scores[i]);
            }
            return result;

        }

        //快速排序
        public static void QuickSort(int[] array,int left,int right)
        {
            if(left>=right)
                return;
            int temp = array[left];
            int tempLeft=left;
            int tempRight=right;
            while (tempLeft!=tempRight)
            {
                while (tempRight > tempLeft && array[tempRight] < temp)
                    tempRight--;

                array[tempLeft] = array[tempRight];

                while(tempRight>tempLeft && array[tempLeft] > temp)
                    tempLeft++;
                array[tempRight] = array[tempLeft];
            }

            array[tempLeft] = temp;
            QuickSort(array,left,tempLeft-1);
            QuickSort(array,tempLeft+1,right);
        }

        //进阶
        public static List<int> GetTopScores2(int[] scores,int m)
        {
            if (scores.Length == 0 || m > scores.Length)
                return null;

            List<int> result = new List<int>();
            int[] maxNs = new int[m]; 
            int index = GetMaxN(scores, m, 0, scores.Length-1);
            for (int i = 0; i <= index; i++)
            {
                maxNs[i] = scores[i];                
            }
            QuickSort(maxNs, 0, maxNs.Length-1);
            for (int i = 0;i<maxNs.Length;i++)
            {
                result.Add(maxNs[i]);
            }          
            return result;
        }
        //得到第n大的数
        public static int GetMaxN(int[] array, int n,int left,int right)
        {
            if (left==right)
            {
                return left;
            }
            int temp = array[left];
            int tempLeft=left;
            int tempRight=right;
            while (tempLeft!=tempRight)
            {
                while (tempRight > tempLeft && array[tempRight] < temp)
                    tempRight--;

                array[tempLeft] = array[tempRight];

                while (tempRight > tempLeft && array[tempLeft] > temp)
                    tempLeft++;
                array[tempRight] = array[tempLeft];
            }

            if (tempLeft == n - 1)
                return tempLeft;
            else if (tempLeft > n - 1)
                return GetMaxN(array, n, left, tempLeft - 1);
            else
                return GetMaxN(array, n, tempLeft + 1, right);
        }

    }

    //Main函数里测试数据
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sorces = new int[] {100,50,75, 80,65};
            List<int> result=LeaderboardSystem.GetTopScores2(sorces, 3);
            foreach(int i in result)
                Console.WriteLine(i);
        }
    }
}