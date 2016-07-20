# Sort-Server API

SSA(Sort-Server API)는 Unity로 제작된 Android Application인
Sort에서 사용되는 API입니다.

## API list

### GET
- Scores

### SET
- Time
- Score

#### Time_Structer
- User
- Flag = ["INSTALL", "APP_START", "APP_END", "GAME_START", "GAME_END"]
- Time
```
{
    "user": "ID_VALUE",
    "flag": "ENUM_VALUE",
    "time": "TIME_VALUE"
}
```

#### Score_Structer
- User
- Scores
```
{
    "user": "ID_VALUE",
    "score": "SCORE_VALUE"
}
```
