def find_k(N, arr, K):
    arr = nums.copy()
    
    def partition(left, right, pivot_index):
        pivot = arr[pivot_index]
        arr[pivot_index], arr[right] = arr[right], arr[pivot_index]
        cnt = left
        
        #Переміщуємо елементи, які > півот вліво
        for i in range(left, right):
            if arr[i] > pivot:
                arr[cnt], arr[i] = arr[i], arr[cnt]
                cnt += 1
        
        #Ставимо півот між числами, які більші за нього (зліва) і менші (справа)
        arr[right], arr[cnt] = arr[cnt], arr[right]
        #print(pivot, arr)
        
        return cnt
    
    def select(left, right, K):
        if left == right:
            return left
        
        import random
        pivot_index = random.randint(left, right)
        
        #Розділяємо масив по півоту
        pivot_index = partition(left, right, pivot_index)
        
        #В результаті кількість елементів, які >= півот має дорівнювати К (тобто приводимо до того, що півот і є К-те число за зменшенням)
        if K == pivot_index - left + 1:
            return pivot_index
        elif pivot_index - left + 1 > K: #Якщо кількість елементів більших за півот більше ніж К, то повторюємо ті самі операції з лівою частиною масиву.
            return select(left, pivot_index - 1, K)
        else: #Якщо кількість елементів більших за півот менше ніж К, то повторюємо ті самі операції з правою частиною масиву.
            return select(pivot_index + 1, right, K - (pivot_index - left + 1))
        #Приклади
        #K = 3
        #pivot = 6, [9, 8, 6, 5, 3, 2, 1]
        #pivot = 2, [9, 5, 3, 8, 6, 2, 1]
        #pivot = 8, [9, 8, 3, 6, 5, 2, 1]
    
    k_position = select(0, N - 1, K)
    return nums.index(arr[k_position]) + 1

N = int(input())
nums = [int(x) for x in input().split()]
K = int(input())
print(find_k(N, nums, K))
