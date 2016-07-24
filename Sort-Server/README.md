# Sort-Server
using Python, import Flask, Flask-RESTful, PyMySql

on AWS and RDS,

API Help  in Sort-Server/api.md

## APIS
- /users
    + **GET**
        * get data of users { [name]: [isLogin] }
        * with parameter `id`, more get detail data { [id], [init_time], [user_name] }
    + **PUT**
        * with parameter `user`, `client`, `flag` login(or new accout) access return a `token` and `name`

- /time/`<user_name>`
    + **GET**
        * get time data of users { [app_start], [game_end], [game_start] }
    + **PUT**
        * with parameter `token`, `client` and json["flag", "time"], set [flag] to "time" if applied, return json["return": "accept"]
        
- /score
    + **GET**
        * get score data order by decrese {"clear", "id", "init", "mode", "move", "score", "time", "user"}
    + **PUT**
        * with parameter `token` and json[like return of score data], create new score