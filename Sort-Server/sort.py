import json
import time
import hashlib
from random import randrange
from flask import Flask, request, make_response, render_template
from flask_restful import Resource, Api
from sort_db import database

app = Flask(__name__)
api = Api(app)

class SortAPIHelp(Resource):
    def get(self):
        return {
        "Hello" : "This is Sort API using RESTful",
        "Method - GET" : {
        	"/users" : "return users in db",
        	"/time/<user>" : "return user data(json)",
        	"/score/<user>" : "return user data(json)"
        },
        "Method - PUT" : {
			"/time/<user>" : "set user data with flag",
			"/score/<user>" : "set user data with flag"
        }
        }

api.add_resource(SortAPIHelp, '/')

db = database()
datas = {}

class Admin(Resource):

	def get(self):
		return render_template('home.html')
	def put(seelf):
		return { "x" : "x" }

api.add_resource(Admin, '/admin')

tokens = {}

def outGuest():
	guests = db.getGuests()
	if (not guests):
		return
	for guest in guests:
		name = guest['name']
		if not name in tokens:
			db.delUserData(name)

def newGuest():
	outGuest()
	name = "Guest"
	while True:
		name += str(randrange(0, 10))
		if not name in tokens:
			break
	db.newGuest(name)
	return name

def timestamp():
	now = time.localtime()
	return "%04d-%02d-%02d %02d:%02d:%02d" % (now.tm_year, now.tm_mon, now.tm_mday, now.tm_hour, now.tm_min, now.tm_sec)

def hasToken(user):
	return user in tokens

def getToken(user):
	if (not db.isUser(user)):
		return None
	if (hasToken(user)):
		return tokens[user]
	key = timestamp() + user + "sortsalt"
	tokens[user] = hashlib.sha1(key.encode('utf-8')).hexdigest()
	return tokens[user]

def outToken(user):
	if (user in tokens):
		del tokens[user]

class Time(Resource):
	
	def get(self, user):
		return db.getUserTable(user, 'times')

	def put(self, user):
		if (not request.args):
			return { 'return': 'require more(less) argument' }
		token = request.args.getlist('token')[0]
		if not token in tokens.values():
			return { 'return': 'Invalidate access' }
		ret = 'failed'
		data = json.loads(request.data.decode('utf-8'))
		if db.setUserData(user, 'times', data['flag'], data['time']):
			ret = 'accept'
		return { 'return': ret }

api.add_resource(Time, '/time/<string:user>')

class Score(Resource):

	def get(self):
		return db.getOrderTable('scores', 'score')

	def put(self):
		if (not request.args.getlist('token') or not request.data):
			return { 'return': 'require more(less) argument' }
		token = request.args.getlist('token')[0]
		if not token in tokens.values():
			return { 'return': 'Invalidate access' }
		db.newScoreData(json.loads(request.data.decode('utf-8')), timestamp())
		return { 'return': "updated" }

api.add_resource(Score, '/score')

class Users(Resource):

	def get(self):
		id = request.args.getlist('id')
		if (id):
			return db.getUserTable(id, 'users')
		users = db.getUsers()
		view = []
		for user in users:
			name = user['user']
			view.append({ name : hasToken(name) and "Login" or "Logout"})
		return view
	
	def put(self):
		if not (request.args.getlist('user') and request.args.getlist('client') and request.args.getlist('flag')):
			return { 'return' : 'Invalidate access'}
		client = request.args.getlist('client')[0]
		user = request.args.getlist('user')[0]
		if client != "Guest":
			user = str(user.encode('utf-8'))
		flag = request.args.getlist('flag')[0]

		if flag == 'login':
			if client == "Guest":
				user = newGuest();
			db.newUserData(user, timestamp())
			return { 'return': flag, 'token': getToken(user), 'name': user  }
		if flag == 'logout':
			if client == "Guest":
				print(user)
			if tokens[user] == request.args.getlist('token')[0]:
				outToken(user)
				return { 'return': flag }
		return { 'return' : 'Invalidate access'}

api.add_resource(Users, '/users')

if __name__ == "__main__":
    app.run(debug=False, host='0.0.0.0', port=5009)
