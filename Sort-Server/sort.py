import json
import time
import hashlib
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

data_empty = {
	"_USER_ID": "VALUE",
	"_USER_INIT" : "VALUE",
	"_APP_INSTALL" : "VALUE",
	"_APP_START" : "VALUE",
	"_APP_END" : "VALUE",
	"_GAME_START" : "VALUE",
	"_GAME_END" : "VALUE"
}

db = database()
datas = {}

class Admin(Resource):

	def get(self):
		return render_template('home.html')
	def put(seelf):
		return { "x" : "x" }

api.add_resource(Admin, '/admin')

tokens = {}

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

	""" put request json {
			"flag": "FLAG_VALUE",
			"time": "TIME_VALUE"	
		}"""
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
		user = request.args.getlist('user')
		if (user):
			return db.getUserTable(user, 'users')
		users = db.getUsers()
		view = []
		for user in users:
			name = user['user']
			view.append({ name : hasToken(name) and "Login" or "Logout"})
		return view
	
	def put(self):
		user = request.args.getlist('user')[0]
		client = request.args.getlist('client')[0]
		flag = request.args.getlist('flag')[0]

		if not db.newUserData(user, timestamp()):
			if client != "application/sort":
				return { 'return' : 'failed'}

		if flag == 'login':
			return { 'return': flag, 'token': getToken(user) }
		outToken(user)
		return { 'return': flag }


api.add_resource(Users, '/users')

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=5009)