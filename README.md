# Dota 2 Timer for supporting supports
## *It's 07:00, go get that brain rune*

Uses the Dota 2 GSI (game state interface) to pull game time and display accurate timings for runes, healing lotuses, and tormentor spawn times. 
This is very much just a tech demo of what you can do with the dota GSI, as well as a way for me to test out some new-to-me tech stacks. 

Prerequisites:
* In order for Dota 2 to expose the game data you need to enable it.
* Add a folder named gamestate_integration containing a .cfg file to the /cfg folder in your Dota 2 game installation, e.g. at D:\SteamLibrary\steamapps\common\dota 2 beta\game\dota\cfg\gamestate_integration
* A sample configuration file can be found [here](gamestate_integration_dota.cfg), just download the file or copy the content. It is important that the file is prefixed with gamestate_integration_, for example gamestate_integration_dota.cfg
* It is also important that the uri in the file matches "http://127.0.0.1:3000/", as this is the address that the application listens to for the game data from Dota, and that data.map = 1, as this contains the game time
* In Steam, [add -gamestateintegration to your Dota 2 launch options](https://help.steampowered.com/en/faqs/view/7d01-d2dd-d75e-2955)

Installation: 
* Download the dota-2-timer.exe from the latest release on [this page](https://github.com/andersastor/dota2-timer/releases/latest) and run it
* The .exe is unsigned so depending on how tough your Antivirus software is you may have to click through some warnings before it runs

How to use:
* Launch the application and your Dota 2 client
* Once you get into a game lobby the timer will automatically start tracking the game time
* The application displays 5 items at a time
* When the item spawns, the card will increase in size to alert you, after 30 seconds, the card will fade, and 60 seconds after the spawn time the card will be removed from the list
* Current version only tracks events up til 20 minutes (tormentor spawn, power rune)
* After the game ends, the application needs to be restarted to reset the event list in order to be used again

![Alt](https://repobeats.axiom.co/api/embed/58311baecc3944fbeea0a080296fb9df8abf31b4.svg "Repobeats analytics image")
