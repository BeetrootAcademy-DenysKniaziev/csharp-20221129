
class Sort

{
    static void Selections(int[]arr)

    {
        for (int i=0; i<arr.Length-1; i++)
        {
            int minIndx = i;
            for (int j=i+1; j<arr.Length; j++) 
            {
                if (arr[j] < arr[minIndx])
                    minIndx = j;
                int tmp = arr[minIndx];
                arr[minIndx] = arr[i];
                arr[i] = tmp;
            }
             
        
        }
    


        
    }



    int[] FirstArr = new int[7] { 7, 34, 76, 11, 23, 4, 17 };




}



