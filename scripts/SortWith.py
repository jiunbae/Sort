import random

def isSorted(ary):
	for i in range(1, len(ary)):
		if ary[i - 1] > ary[i]:
			return False
	return True

def getMinSwap(ary):
	sorted = ary[:]
	sorted.sort()

	chk = [False for _ in range(len(ary))]

	cycle = 0

	for i in range(len(ary)):
		if chk[i]:
			continue
		chk[i] = True
		idx = i
		while(sorted[i] != ary[idx]):
			idx = sorted.index(ary[idx])
			chk[idx] = True
		cycle += 1
	return len(ary) - cycle


for swap_count in range(1, 25):
	sum = 0;
	for _ in range(10000):
		ary = [1,2,3,4,5,6]
		for _ in range(swap_count):
			i = random.randrange(0, 6)
			j = random.randrange(0, 6)
			ary[i], ary[j] = ary[j], ary[i]
		sum += getMinSwap(ary)
	print ("" + str(swap_count) + ": " + str(sum / 10000.0))

