# [EAC] Extended Admin Commands
## This is the repo for the EAC script.
Here you can get all newest updates/bugfixes and an introduction!



----
## 1. Installation

Installation is easy.
Just go to your GT:MP server folder and paste the `eac` folder into `resources`.
Once thats done, paste following line into your `settings.xml` (Root directory)
```xml
<resource src="eac" />
```

**NOTE**: For this script to work, you need to have an working ACL setup.
Please refer to the [GTMP Wiki](https://wiki.gt-mp.net/index.php/Getting_Started_with_the_Server_%26_ACL) for informations on how to acomplish that.



----
## 2. Configuration
The configuration is done in the `meta.xml` in your `resources\eac` folder.
Following values need to be configured:

| Property      | Default | Description                                        |
| ------------- | ------- | -------------------------------------------------- |
| debugmode     | false    | Toggles debug messages                             |
| vehicleconfig | 0       | Specifies the vehicle spawn method (see README.md) |
| aclgroupname  | Admin   | Name of your desired ACL group                      |


### Vehicle Config Types
| Index | Description                                |
| ----- | ------------------------------------------ |
| 0     | Nothing                                    |
| 1     | Spawns the car next to the player          |
| 2     | Spawns the car and puts the player into it |
| 3     | Like 1, but also deletes the vehicle       |
| 4     | Like 2, but also deletes the vehicle       |



----
## 3. Commands
In this table you can find all commands and their specific usage.

| Command                         | Description                                                   |
| ------------------------------- | ------------------------------------------------------------- |
| `/help`                         				| Displays all possible commands in Chat                        |
| `/veh` ***HASH/NAME***                 		| Spawns the specified Model with the configured variant        |
| `/allwep`                       				| Gives the executing player all weapons                        |
| `/givewep` ***HASH/NAME - AMMO - TARGET*** 	| Gives the target the specified weapon with the specified ammo |
| `/healthset` ***VALUE - TARGET***     		| Sets the Health of the target to the specified amount         |
| `/armorset` ***VALUE - TARGET***      		| Sets the Armor of the target to the specified amount          |
| `/heal` ***TARGET***                			| Heals the specified target completely                         |
| `/armor` ***TARGET***               			| Gives the specified target full Armor                         |
| `/fix`                          				| Repairs the car the executing Player is sitting in            |
| `/tele` ***TARGET***                			| Teleports the executing Player to specified the Target        |
| `/tpm` ***TARGET***                 			| Teleports the specified Target to the executing Player        |

***More to come...***



----
## 4.  Other
First off, thanks for using EAC.
If you find any Bugs or you have any Ideas on other Commands, just contribute, open up an Issue or write me a Message.

**Have fun using EAC** :)
