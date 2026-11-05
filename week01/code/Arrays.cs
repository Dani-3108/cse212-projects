public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //1. Create a double[] of size length.
        //2. Loop i from 0 up to(but not including) length.
        //3. Put number *(i + 1) into slot i.
        //4. Return the array.
        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // 1. Find the index where the chunk starts: data.Count - amount.
        // 2. Copy that chunk out using GetRange.
        // 3. Remove that chunk from the original list using RemoveRange.
        // 4. Insert the copied chunk at index 0 using InsertRange.
        int start = data.Count - amount;
        List<int> chunk = data.GetRange(start, amount);
        data.RemoveRange(start, amount);
        data.InsertRange(0, chunk);
    }
}
