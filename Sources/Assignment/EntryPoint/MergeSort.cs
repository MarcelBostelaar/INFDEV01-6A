﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public static class MergeSort
    {
        /// <summary>Sorts an IEnumerable according to a function.
        /// <para>Takes any IEnumerable and sorts it using mergesort. Returns a new IEnumerable</para>
        /// </summary>
        public static IEnumerable<T> Sort<T>(IEnumerable<T> toSort, Func<T, T, bool> ABeforeB)
        {
            return Sort(toSort.ToList(), 0, toSort.Count()-1, ABeforeB);
        }
        /// <summary>Sorts a List according to a function.
        /// <para>Takes any List and sorts it using mergesort. Returns a new List</para>
        /// </summary>
        private static List<T> Sort<T>(List<T> toSort, int startIndex, int endIndex, Func<T, T, bool> ABeforeB)
        {
            if(startIndex <endIndex)
            {
                int middle = (endIndex-startIndex) / 2 + startIndex;
                List<T> A, B;
                A = Sort(toSort, startIndex, middle, ABeforeB);
                B = Sort(toSort, middle+1, endIndex, ABeforeB);
                return Merge(A, B, ABeforeB);
            }
            return toSort.GetRange(startIndex, 1);
        }
        /// <summary>Merges two lists in order according to a function.
        /// <para>Takes two lists and sorts it according to a function. Returns a new List</para>
        /// </summary>
        private static List<T> Merge<T>(List<T> A, List<T> B, Func<T, T, bool> ABeforeB)
        {
            List<T> toreturn = new List<T>();

            while (A.Count>0 && B.Count > 0)
            {
                if(ABeforeB(A[0], B[0]))
                {
                    toreturn.Add(A[0]);
                    A.RemoveAt(0);
                }
                else
                {
                    toreturn.Add(B[0]);
                    B.RemoveAt(0);
                }
            }
            while (A.Count > 0)
            {
                toreturn.Add(A[0]);
                A.RemoveAt(0);
            }
            while (B.Count > 0)
            {
                toreturn.Add(B[0]);
                B.RemoveAt(0);
            }
            return toreturn;
        }
    }
}
