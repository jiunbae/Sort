u = { "a": "A", "b": "B", "c": "C" }

c = {x : y for x in u.keys() for y in u.values() }

print(c['a'])