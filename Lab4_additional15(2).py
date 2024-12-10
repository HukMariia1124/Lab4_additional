import random
def quicksort(arr):
    if len(arr) <= 1:
        return arr
    pivot = arr[len(arr) // 2]
    left = [x for x in arr if x > pivot] #Масив елементів, менших за півот.
    middle = [x for x in arr if x == pivot] #Сам півот
    right = [x for x in arr if x < pivot] #Масив елементів, більших за півот.
    return quicksort(left) + middle + quicksort(right) #Рекурсія, поки метод не виведе відсортований список

n = int(input())
nums = [int(x) for x in input().split()]
k = int(input())
sortedNums = nums.copy()
sortedNums=quicksort(sortedNums)
index1 = sortedNums[k - 1]
index2 = nums.index(index1) + 1
print(index2)
