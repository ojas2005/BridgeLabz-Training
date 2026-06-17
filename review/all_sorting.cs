//bubblesort
static void BubbleSort(int[] arr)
{
    int n = arr.Length;
    for (int i = 0; i < n - 1; i++)
    {
        bool swapped = false;
        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
                swapped = true;
            }
        }
        if (!swapped) break;
    }
}

//selection sort
static void SelectionSort(int[] arr)
{
    int n = arr.Length;
    for (int i = 0; i < n - 1; i++)
    {
        int min = i;
        for (int j = i + 1; j < n; j++)
            if (arr[j] < arr[min])
                min = j;

        int temp = arr[min];
        arr[min] = arr[i];
        arr[i] = temp;
    }
}

//insertion sort
static void InsertionSort(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        int key = arr[i];
        int j = i - 1;

        while (j >= 0 && arr[j] > key)
        {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = key;
    }
}

//merge sort
static void MergeSort(int[] arr, int left, int right)
{
    if (left < right)
    {
        int mid = (left + right) / 2;
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }
}

static void Merge(int[] arr, int l, int m, int r)
{
    int[] temp = new int[r - l + 1];
    int i = l, j = m + 1, k = 0;

    while (i <= m && j <= r)
        temp[k++] = arr[i] <= arr[j] ? arr[i++] : arr[j++];

    while (i <= m) temp[k++] = arr[i++];
    while (j <= r) temp[k++] = arr[j++];

    Array.Copy(temp, 0, arr, l, temp.Length);
}

//quick sort
static void QuickSort(int[] arr, int low, int high)
{
    if (low < high)
    {
        int pi = Partition(arr, low, high);
        QuickSort(arr, low, pi - 1);
        QuickSort(arr, pi + 1, high);
    }
}

static int Partition(int[] arr, int low, int high)
{
    int pivot = arr[high];
    int i = low - 1;

    for (int j = low; j < high; j++)
    {
        if (arr[j] < pivot)
        {
            i++;
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }
    (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
    return i + 1;
}

//heap sort
static void HeapSort(int[] arr)
{
    int n = arr.Length;
    //building max heap- [4, 10, 3, 5, 1] to [10, 5, 3, 4, 1]
    for (int i = n / 2 - 1; i >= 0; i--)
        Heapify(arr, n, i);
    //sorting phase,swapping 10 with last element(arr[0],arr[i]=arr[i],arr[0])
    for (int i = n - 1; i > 0; i--)
    {
        (arr[0], arr[i]) = (arr[i], arr[0]);
        Heapify(arr, i, 0);
    }
}
//to build max heap
static void Heapify(int[] arr, int n, int i)
{
    int largest = i;
    int l = 2 * i + 1, r = 2 * i + 2;

    if (l < n && arr[l] > arr[largest]) largest = l;
    if (r < n && arr[r] > arr[largest]) largest = r;

    if (largest != i)
    {
        (arr[i], arr[largest]) = (arr[largest], arr[i]);
        Heapify(arr, n, largest);
    }
}

//counting sort
static void CountingSort(int[] arr, int max)
{
    int[] count = new int[max + 1];
    foreach (int num in arr) count[num]++;

    int index = 0;
    for (int i = 0; i <= max; i++)
        while (count[i]-- > 0)
            arr[index++] = i;
}


//Radix sort

static void RadixSort(int[] arr)
{
    int max = arr.Max();
    for (int exp = 1; max / exp > 0; exp *= 10)
        CountSortByDigit(arr, exp);
}
static void CountSortByDigit(int[] arr, int exp)
{
    int n = arr.Length;
    int[] output = new int[n];   // sorted array for this digit
    int[] count = new int[10];   // digits 0–9

    // 1️⃣ Count occurrences of digits
    for (int i = 0; i < n; i++)
    {
        int digit = (arr[i] / exp) % 10;
        count[digit]++;
    }

    // 2️⃣ Prefix sum (positions)
    for (int i = 1; i < 10; i++)
        count[i] += count[i - 1];

    // 3️⃣ Build output array (RIGHT to LEFT for stability)
    for (int i = n - 1; i >= 0; i--)
    {
        int digit = (arr[i] / exp) % 10;
        output[count[digit] - 1] = arr[i];
        count[digit]--;
    }

    // 4️⃣ Copy back to original array
    for (int i = 0; i < n; i++)
        arr[i] = output[i];
}
