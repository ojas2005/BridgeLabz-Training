public class MergeSorter
{
    public static void MergeSort(Student[] arr)
    {
        if (arr.Length<=1) return;

        int mid=arr.Length/2;
        Student[] left=new Student[mid];
        Student[] right=new Student[arr.Length-mid];

        Array.Copy(arr,0,left,0,mid);
        Array.Copy(arr,mid,right,0,arr.Length-mid);

        MergeSort(left);
        MergeSort(right);

        Merge(arr,left,right);
    }

    private static void Merge(Student[] arr,Student[] left,Student[] right)
    {
        int i=0,j=0,k=0;

        while (i<left.Length && j<right.Length)
        {
            // Descending order
            if (left[i].getScore()>right[j].getScore())
                arr[k++]=left[i++];
            else
                arr[k++]=right[j++];
        }

        while (i<left.Length)
            arr[k++]=left[i++];

        while (j<right.Length)
            arr[k++]=right[j++];
    }
}
