n = int(input())
nums = [int(x) for x in input().split()]
k = int(input())
sortedNums = sorted(nums, reverse=True)
index1 = sortedNums[k - 1]
index2 = nums.index(index1) + 1
print(index2)
