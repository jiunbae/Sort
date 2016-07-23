# Sort - Client
using Unity(C#), plugins FacebookSDK, GooglePlayGames, JSONObject

build for Android Application (Minumum API Level 15)

Version 1.2[2]

## Scenes
- Sort: Scene for login and display rankging
- Sort-Play: Scene for play

## Scripts

- Background: control background (moving back diagonal)
- Buttons: control buttons and click events
- GamePlay: Main code of game play
- GmaePlayUI: Display code of game play
- Global: Main script for integrated
- Network: connecton to server
- SceneMgr: control scene fade effect
- Uitlity: various utilities

#### for Login
call Login function in `Global.cs` to Login
- Login/FacebookLogin
- Login/GoogleLogin
- Login/GuestLogin

#### for Dialog
Dialog means menu box, each dialog has Popup to display Popdown to turn off visible

- Dialog/LoginDialog
- Dialog/MenuDialog
- Dialog/RankDialog
- Dialog/UserDialog

<hr>

## Logic
1. create array[0-9]
2. select six of theme
3. swap each(swap count related with `min_swap_to_solv`, Refer `scripts/SortWith.py`)
4. get min_swap_to_solv(mean array_size - cycle in array with sorted array)
5. calculate score with solv, move, swap, time, min_swap_to_solv

