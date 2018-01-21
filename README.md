# [EAC] Extended Admin Commands
## This is the Repo for the EAC Script.
Here you can get all newest Updates/Bugfixes and an Introduction!



----
## 1. Installation

Installation is easy.
Just go to your GT:MP Server Folder and paste the "*cmds*" folder into "*resources*".
Once thats done, paste following line into your settings.xml (Root Directory)
```xml
<resource src="cmds" />
```

**NOTE**: For this Script to work, you need to have an working ACL Setup.
Please refer to the [GTMP Wiki](https://wiki.gt-mp.net/index.php/Getting_Started_with_the_Server_%26_ACL) for Informations on how to acomplish that.



----
## 2. Configuration
The Configuration is done in the commands.cs in your resources\cmds Folder.
Following Values/Bool/Int need to be configured:
```c#
    public bool Debug = false;                 //<- Here you need to specify if you want to have debug enabled. (Possible Values: true, false)
    public int vehicleSpawnConfig = 0;                   //<- Here you can set the Variant which is used to spawn Vehicles in. Please look on Line 10-16 for Informations on that.
    public string GroupName = "Admin";                 //<- Here you need to specify which Group you want these Commands used by. Anything under that can't access them.
```
***Everything is documented in the commands.cs if you need further explaination***



----
## 3. Commands
In this Table you can find all Commands and their specific Usage.

| Command | Description                    |
| ------------- | ------------------------------ |
| `/help`      | Displays all possible Commands in Chat       |
| `/veh` *model*   | Spawns the specified Model with the configured Variant     |
| `/allwep`      | Gives the executing Player all Weapons       |
| `/givewep` *target weapon ammo*     | Gives the target the specified Weapon (Case-Sensitive!) with the specified Ammo.       |
| `/healthset` *target value*      | Sets the Health of the target to the specified amount       |
| `/armorset` *target value*     | Sets the Armor of the target to the specified amount       |
| `/heal` *target*      | Heals the specified target completely       |
| `/armor` *target*      | Gives the specified target full Armor       |
| `/fix`      | Repairs the car the executing Player is sitting in       |
| `/tele` *target*      | Teleports the executing Player to specified the Target      |
| `/tpm` *target*     | Teleports the specified Target to the executing Player       |

***More to come...***



----
## 4.  Other
First off, thanks for using EAC.
If you find any Bugs or you have any Ideas on other Commands, just contribute, open up an Issue or write me a Message.

**Have fun using EAC** :)