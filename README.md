# The C# Academy: Math Game

See https://www.thecsharpacademy.com/project/53/math-game for more details.

## Requirements

### Rules

* You need to create a Math game containing the 4 basic operations
* The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
* Users should be presented with a menu to choose an operation
* You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
* You don't need to record results on a database. Once the program is closed the results will be deleted.

### Challenges

* Try to implement levels of difficulty.
* Add a timer to track how long the user takes to finish the game.
* Create a 'Random Game' option where the players will be presented with questions from random operations
* To follow the DRY Principle, try using just one method for all games. Additionally, double-check your project and try to find opportunities to achieve the same functionality with less code, avoiding repetition when possible.

### AI Challenge

* Can you make it so the users of your game are able to reply to the game's questions using their voice?

## Running the game

```bash
dotnet restore
dotnet build
dotnet run --project MathGame
```

## Running tests

```bash
dotnet test
```

## Changing controls

By default, the game is controlled using keyboard. To switch to speech recognition set the environment variable `ControlsConfiguration:Controls` to `Speech` and configure credentials for the Azure Speech Recognition service. 

## Configuring Azure SDK for Speech Recognizer

Add your subscription details into user secrets like this:

```json
{
  "SpeechRecognizer": {
    "Region": "",
    "SubscriptionKey": ""
  }
}
```
