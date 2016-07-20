#!/usr/bin/python
import MySQLdb

user = "SortAdmin"
passwd = "Sorted1234"

def dictfetchall(cursor):
    """Returns all rows from a cursor as a list of dicts"""
    desc = cursor.description
    return [dict(zip([col[0] for col in desc], row)) 
            for row in cursor.fetchall()]

tables = {	"users": ["user", "init"],
			"scores": ["user", "score", "move", "time", "clear", "mode", "init"],
			"times": ["user", "game_start", "game_end", "app_start"] }

def isColumn(table, column):
	return column in tables[table]

def isTable(table):
	return table in tables.keys()

class database():
	def __init__(self):
		self.db = MySQLdb.connect("localhost", user, passwd, "sort")
		self.cursor = self.db.cursor()

	def getCursor(self):
		if self.db.open:
			self.db.close()
			self.db = MySQLdb.connect("localhost", user, passwd, "sort")
		self.cursor = self.db.cursor()
		return self.cursor

	def isUser(self, user):
		cursor = self.getCursor()
		cursor.execute("SELECT EXISTS (SELECT * FROM users WHERE user=\"%s\")" % user)
		return cursor.fetchone()[0] == 1

	def getUsers(self):
		cursor = self.getCursor()
		cursor.execute("SELECT * FROM USERS")
		return dictfetchall(cursor)

	def getUserID(self, user):
		cursor = self.getCursor()
		cursor.execute("SELECT id FROM users WHERE user=\"%s\"" % user)
		return cursor.fetchone()[0]

	def getUserData(self, user, table, column):
		if not (isColumn(column) and isTable(table)):
			return False
		try:
			id = self.getUserID(user)
			cursor = self.getCursor()
			cursor.execute("SELECT %s FROM %s WHERE user = %d" % (column, table, id))
		except:
			return False
		return dictfetchall(cursor)

	def getUserTable(self, user, table):
		if not (isTable(table)):
			return False
		try:
			id = self.getUserID(user)
			cursor = self.getCursor()
			cursor.execute("SELECT * FROM %s WHERE user=%d" % (table, id))
		except:
			return False
		return dictfetchall(cursor)

	def getOrderTable(self, table, column, increse=True):
		cursor = self.getCursor()
		if not (isTable(table) and isColumn(table, column)):
			return False
		try:
			cursor.execute("SELECT * FROM %s ORDER BY %s %s" % (table, column, increse and "ASC" or "DESC"))
		except:
			return False
		return dictfetchall(cursor)

	def setUserData(self, id, table, column, value):
		cursor = self.getCursor()
		if not (isTable(table) and isColumn(table, column)):
			return False
		try:
			cursor.execute("UPDATE %s SET %s=\"%s\" WHERE user=%d" % (table, column, value, id))
			self.db.commit()
		except:
			self.db.rollback()
			return False
		return True		

	def setUserTable(self, id, table, value):
		if not (isTable(table)):
			return False
		for x, y in value.items():
			self.setUserDataFlag(id, table, x, y)
		return value

	def newScoreData(self, data, timestamp):
		if not self.isUser(data['name']):
			return False
		id = self.getUserID(data['name'])
		cursor = self.getCursor()
		try:
			text = "INSERT INTO scores (user, score, move, time, clear, init, mode) VALUES ( %d, %d, %d, %d, %d, \"%s\", \"%s\" )" % (id, data['score'], data['move'], data['time'], data['clear'], timestamp, data['mode'])
			cursor.execute(text)
			self.db.commit()
		except:
			self.db.rollback()

	def newUserData(self, user, timestamp):
		if self.isUser(user):
			return False
		cursor = self.getCursor()
		id = False
		try:
			cursor.execute("INSERT INTO users (user, init) VALUES (\"%s\", \"%s\")" % (user, timestamp))
			self.db.commit()
		except:
			self.db.rollback()
		id = self.getUserID(user)
		cursor = self.getCursor()
		try:
			cursor.execute("INSERT INTO times (user, app_start) VALUES ( %d, \"%s\" )" % (id, timestamp))
			self.db.commit()
		except:
			self.db.rollback()
		return id

if __name__ == "__main__":
	db = MySQLdb.connect("localhost", user, passwd, "sort")
	cursor = db.cursor()
	cursor.execute("SELECT VERSION()")

	print ("Login as %s \nDB version : %s " % (user, cursor.fetchone()))

	while True:
		print ("Enter Command: ", end="")
		command = input()
		cursor = db.cursor()
		cursor.execute(command)
		print ("result: %s" % cursor.fetchall())