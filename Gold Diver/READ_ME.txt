 $$$$$$\   $$$$$$\  $$\       $$$$$$$\        $$$$$$$\  $$$$$$\ $$\    $$\ $$$$$$$$\ $$$$$$$\  
$$  __$$\ $$  __$$\ $$ |      $$  __$$\       $$  __$$\ \_$$  _|$$ |   $$ |$$  _____|$$  __$$\ 
$$ /  \__|$$ /  $$ |$$ |      $$ |  $$ |      $$ |  $$ |  $$ |  $$ |   $$ |$$ |      $$ |  $$ |
$$ |$$$$\ $$ |  $$ |$$ |      $$ |  $$ |      $$ |  $$ |  $$ |  \$$\  $$  |$$$$$\    $$$$$$$  |
$$ |\_$$ |$$ |  $$ |$$ |      $$ |  $$ |      $$ |  $$ |  $$ |   \$$\$$  / $$  __|   $$  __$$< 
$$ |  $$ |$$ |  $$ |$$ |      $$ |  $$ |      $$ |  $$ |  $$ |    \$$$  /  $$ |      $$ |  $$ |
\$$$$$$  | $$$$$$  |$$$$$$$$\ $$$$$$$  |      $$$$$$$  |$$$$$$\    \$  /   $$$$$$$$\ $$ |  $$ |
 \______/  \______/ \________|\_______/       \_______/ \______|    \_/    \________|\__|  \__|


Presented by Omar Al-Farajat
SID: 29603387
Submitted on 2019-10-19 (Early AM)
As per the requirements of COMP 376


VIDEO DEMO
	https://youtu.be/XjyPEf7X2iE

CONTROLS
	W, A, S, D	: 	Up, Left, Down, Right
	Space		:	Nitro mode (5 second burst of speed)
	Escape		:	Return to main menu

INSTRUCTIONS
	* Navigate to ..\Gold Diver\Assets\Underwater Diving\Scenes and open MainMenu.unity.
	* If there are problems opening up the project, I have included a build of the game in ..\Gold Diver\Build\Gold Diver.exe
	* The scripts are located in ..\Gold Diver\Assets\Underwater Diving\Scripts

COMMENTS
	* Assets were primarily used from https://assetstore.unity.com/packages/2d/environments/underwater-diving-94029 
	* This is still ultimately a work-in-progress, I do not present this as a "perfect" solution (very much far from it), but at the very least it's functional and meets the minimum requirements described in the assignments.
	* The bulk of the scripts are either spawners (gold, nitro, octopus, shark) or controllers for the same objects. I apologize for the inconsistent naming scheme for the controller classes (some have "controller" as a postfix, whereas others do not). 
	* All the spawners behave much the same way. I make use of Camera.main.orthographicSize to have items and enemies spawn at random locations within the limits of the window regardless of its aspect ratio. Each prefab that spawns has a fixed time before it is destroyed. 
	* The PlayerController class is overburdened with too many roles. A lot of restructuring is needed. 
	