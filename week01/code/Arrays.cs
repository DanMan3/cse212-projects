using System.Data.Common;

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
        // Create a new fixed array that is the length of the "length" input. Then create a loop that iterates as many times as the input length. 
        // Inside that loop, multiply the input number by the index (i + 1). Take that multiplied value and add it to the array at the loop (i) index.
        // return the fixed array.

        var multiples = new double[length];

        for (var i = 0; i < length; i++)
        {
            var multiplied = number * (i + 1);

            multiples[i] = multiplied;
        }

        return multiples;
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
        // Create a new vaiable array, making it the initial input list data.
        // Create a new slice of the created data array using GetRange, beginning at the index of the inputted amount (data.Count - amount), and 
        // the amount input as the second data value. Then, use RemoveRange on the created variable array and remove the same range as the 
        // slice created (data.Count - amount, amount). Next, use InsertRange on the created variable array, beginning at index 0, and add the slice.

        var listData = data;
        var slice = listData.GetRange(data.Count - amount, amount);

        listData.RemoveRange(listData.Count - amount, amount);
        listData.InsertRange(0, slice);

    }
}
