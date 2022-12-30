using System.Collections;
using System.Collections.Generic;

namespace OrderlyQueue;

public class Solution
{
      
    public string OrderlyQueue(string s, int k) {
       
        var visitedChars = new HashSet<char>();
        var charArray =  s.ToCharArray();
        var lastPos = charArray.GetUpperBound(0);

       while(ShouldMove(charArray,k, ref visitedChars,out int swapCharPos))
           PushToEnd(ref charArray, swapCharPos);
       return string.Join("",charArray);
    }

    public bool ShouldMove(char[] arr, int sliceSize,ref HashSet<char> visitedChars,out int charPos)
    {
        (charPos, char higherCharFromSlice ) = GetHigherCharFromSlice(arr, sliceSize);

        if (visitedChars.Contains(higherCharFromSlice))
            return false;
        
        visitedChars.Add(higherCharFromSlice);
        var scanCoverage = arr.Length == sliceSize ? 0 : sliceSize;
        
        return arr.Skip(scanCoverage)
            .Any(item=>IsGrater(higherCharFromSlice,item));
    }

    private static (int,char) GetHigherCharFromSlice(char[] arr, int sliceSize )
    {
        var charPos = 0;
        var higherCharFromSlice = arr[0];
        
        if (sliceSize > 1)
        {
            higherCharFromSlice = arr.Take(sliceSize).Max();
            charPos = Array.IndexOf(arr, higherCharFromSlice, 0, sliceSize);
        }

        return (charPos,higherCharFromSlice);
    }
    public void PushToEnd(ref char[] arr, int swapCharPos)
    {
        var temp = new ArrayList(arr);
        temp.RemoveAt(swapCharPos);
        temp.Add(arr[swapCharPos]);
        arr = (temp.ToArray(typeof(char)) as char[])! ;
    }
    public bool IsGrater(char left, char right) => left > right ;

}