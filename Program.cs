//*****************************************************************************
//** 3634. Minimum Removals to Balance Array                        leetcode **
//*****************************************************************************
//** Sorted numbers stand in quiet rows,                                     **
//** Each start tests how far its shadow goes.                               **
//** A binary search draws the tightest span,                                **
//** Trim the rest away and keep the strongest clan.                         **
//*****************************************************************************

static int cmpInt(const void* a, const void* b)
{
    int x = *(const int*)a;
    int y = *(const int*)b;
    return (x > y) - (x < y);
}

static int upperBound(int* nums, int n, long long target)
{
    int left = 0;
    int right = n;

    while(left < right)
    {
        int mid = left + ((right - left) >> 1);
        if((long long)nums[mid] <= target)
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }

    return left;
}

int minRemoval(int* nums, int numsSize, int k)
{
    qsort(nums, numsSize, sizeof(int), cmpInt);

    int maxValidElements = 0;
    int n = numsSize;

    for(int i = 0; i < n; i++)
    {
        int rightBoundary = n;
        long long limit = (long long)nums[i] * k;

        if(limit <= nums[n - 1])
        {
            rightBoundary = upperBound(nums, n, limit);
        }

        int count = rightBoundary - i;
        if(count > maxValidElements)
        {
            maxValidElements = count;
        }
    }

    return n - maxValidElements;
}