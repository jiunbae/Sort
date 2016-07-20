import json
import time
from flask import Flask, request, make_response
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

def timestamp():
	now = time.localtime()
	return "%04d-%02d-%02d %02d:%02d:%02d" % (now.tm_year, now.tm_mon, now.tm_mday, now.tm_hour, now.tm_min, now.tm_sec)

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

class Time(Resource):
	
	def get(self, user):
		return db.getUserTable(user, 'times')

	""" put request json {
			"flag": "FLAG_VALUE",
			"time": "TIME_VALUE"	
		}"""
	def put(self, user):
		ret = 'accept'
		if db.setUserDataFlag(user, request.args.getlist('flag')[0], request.data.decode('utf-8')):
			ret = 'failed'
		return { 'return': ret }

api.add_resource(Time, '/time/<string:user>')

class Score(Resource):

	def get(self):
		return db.getOrderTable('scores', 'score')

	def put(self):
		db.newScoreData(json.loads(request.data.decode('utf-8')), timestamp())
		return { 'return': "x" }

api.add_resource(Score, '/score')

class Users(Resource):

	def get(self):
		return db.getUsers()
	
	def put(self):
		if not db.newUserData(request.args.getlist('user')[0], timestamp()):
			return { 'return' : 'failed' }
		return { 'return': 'accept' }

api.add_resource(Users, '/users')

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=5009)