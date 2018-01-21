using System;
using System.IO;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

/* ------------ VEHICLE INFO ------------
* If you want to use other Vehicle Spawn Mathods, set the "vehicleSpawnConfig" int to the desired Method.
* Method 1: Spawns the car next to the Player without Deleting the current one
* Method 2: Spawns the car and the Player automatically is spawned within it without deleting the current one
* Method 3: Like Method 1 just whilst deleting the current car
* Method 4: Like Method 2 just whilst deleting the current car
* Default: "0" 
* 
* ------------ GENERAL INFO ------------
* Currently it's only possible to set target as the specified GTMP Name, will maybe be updated later on to SC.
* 
* ------------ DEBUG INFO ------------
* If you want to enable Debug Messages, set the "debug" bool to "true". 
* Default: "false"
*
* ------------ ACL (ADMIN) INFO ------------
* If your highest group has a diffrent Name and is not default (Admin), set the "GroupName" string to your desired ACL Group
* Default: Admin (Case-Sensitive!)
*
*
* root was here <3
*/

public class Commands : Script
{
    // ---------- Config Values ---------- \\
    public bool Debug = false;
    public int vehicleSpawnConfig = 0;
    public string GroupName = "Admin";

    //Main Init
    public Commands()
    {
        if (Debug) 
            Console.WriteLine("[DEBUG] Script started...");
    }

    //Check if User is authorized to use these Commands
    private bool CanUseCommand(Client player)
    {
        var canUse = API.getPlayerAclGroup(player) == GroupName && API.isPlayerLoggedIn(player);
        if (!canUse)
            API.sendChatMessageToPlayer(player, "~r~ [ERROR] You are not authorized or logged in!");
        return canUse;
    }

    // Vehicle Command
    [Command("veh")]
    public void vehCommand(Client player, string request)
    {
        if (!CanUseCommand(player))
            return;
        var hash = API.getHashKey(request);
        var rotation = API.getEntityRotation(player.handle);
        var vehicle = API.createVehicle(hash, player.position, new Vector3(0, 0, rotation.Z), 0, 0);
        if ((vehicleSpawnConfig == 3 || vehicleSpawnConfig == 4) && player.isInVehicle)
            API.deleteEntity(player.vehicle);
        if (vehicleSpawnConfig == 2 || vehicleSpawnConfig == 4)
            API.setPlayerIntoVehicle(player, vehicle, -1);
        if (Debug) {
            API.sendChatMessageToPlayer(player, "~y~ [DEBUG] Requested Hash is: " + hash);
            API.sendChatMessageToPlayer(player, "~g~ [DEBUG] " + request + " has been spawned!");
        }
    }

    //All Weapon Command
    [Command("allwep")]
    public void GiveAllWeaponsCommand(Client player)
    {
        if (!CanUseCommand(player))
            return;
        foreach (WeaponHash Hash in Enum.GetValues(typeof(WeaponHash))) {
            API.givePlayerWeapon(player, Hash, 99999, true, true);
        }
    }

    //Give Weapon Command
    [Command("givewep")]
    public void GiveWeaponCommand(Client player, Client target, string weapon, int ammo)
    {
        if (!CanUseCommand(player))
            return;
        try {
            WeaponHash wep;
            wep = (WeaponHash)System.Enum.Parse(typeof(WeaponHash), weapon);
            API.givePlayerWeapon(target, wep, ammo, true, true);
            if (Debug)
                API.sendChatMessageToPlayer(player, "~y~ [DEBUG] Gave " + target.name + " the Weapon: " + wep + " with " + ammo + " Ammo.");
        } catch (ArgumentException) {
            API.sendChatMessageToPlayer(player, "~r~ [ERROR] An Error occured. Did you specify a right Weapon Value (Case-Sensitive)?");
        }
    }

    //Set Health Command
    [Command("healthset")]
    public void SetHealthCommand(Client player, Client target, int value)
    {
        if (!CanUseCommand(player))
            return;
        API.setPlayerHealth(target, value);
        if (Debug)
            API.sendChatMessageToPlayer(player, "~y~ [DEBUG] Set " + target.name + "'s Health to: " + value);
    }

    //Set Armor Command
    [Command("armorset")]
    public void SetArmorCommand(Client player, Client target, int value)
    {
        if (!CanUseCommand(player))
            return;
        API.setPlayerArmor(target, value);
        if (Debug)
            API.sendChatMessageToPlayer(player, "~y~ [DEBUG] Set " + target.name + "'s Armor to: " + value);
    }

    //Heal Command
    [Command("heal")]
    public void HealCommand(Client player, Client target)
    {
        if (!CanUseCommand(player))
            return;
        API.setPlayerHealth(target, 100);
        if (Debug)
            API.sendChatMessageToPlayer(player, "~y~ [DEBUG] Fully healed Player: " + target.name);
    }

    //Armor Command
    [Command("armor")]
    public void ArmorCommand(Client player, Client target)
    {
        if (!CanUseCommand(player))
            return;
        API.setPlayerArmor(target, 100);
        if (Debug)
            API.sendChatMessageToPlayer(player, "~y~ [DEBUG] Gave full Armor to Player: " + target.name);
    }

    //Fix Vehicle Command
    [Command("fix")]
    public void FixVehicleCommand(Client player)
    {
        if (!CanUseCommand(player))
            return;
        if (!player.isInVehicle) {
            API.sendChatMessageToPlayer(player, "~r~ [ERROR] You are not in a Vehicle!");
            return;
        }
        player.vehicle.repair();
        if (Debug)
            API.sendChatMessageToPlayer(player, "~y~ [DEBUG] Repaired the current Vehicle!");
    }

    // Teleport Command
    [Command("tele")]
    public void teleCommand(Client player, Client target)
    {
        if (!CanUseCommand(player))
            return;
        player.position = target.position;
        if (Debug)
            API.sendChatMessageToPlayer(player, "~y~ [DEBUG] Teleported to: " + target.name);
    }

    //Teleport Here Command
    [Command("tpm")]
    public void teleportHereCommand(Client player, Client target)
    {
        if (!CanUseCommand(player))
            return;
        target.position = player.position;
        if (Debug)
            API.sendChatMessageToPlayer(player, "~y~ [DEBUG] Teleported " + target.name + " to you!");
    }

    //Help Command
    [Command("help")]
    public void helpCommand(Client player)
    {
        if (!CanUseCommand(player))
            return;
        API.sendChatMessageToPlayer(player, "~y~ ---- ADMIN COMMANDS ----");
        API.sendChatMessageToPlayer(player, "~b~[HELP] [ADMIN] || /veh [MODEL] --- Spawns the specified Car");
        API.sendChatMessageToPlayer(player, "~b~[HELP] [ADMIN] || /allwep --- Gives the executing Player all Weapons");
        API.sendChatMessageToPlayer(player, "~b~[HELP] [ADMIN] || /givewep [TARGET] [WEAPON] [AMMO] --- Gives the Target Player the specified Weapon with the specified Ammo");
        API.sendChatMessageToPlayer(player, "~b~[HELP] [ADMIN] || /healthset [TARGET] [VALUE] --- Sets the Health of the specified Player to the specified Amount.");
        API.sendChatMessageToPlayer(player, "~b~[HELP] [ADMIN] || /armorset [TARGET] [VALUE] --- Sets the Armor of the specified Player to the specified Amount.");
        API.sendChatMessageToPlayer(player, "~b~[HELP] [ADMIN] || /heal [TARGET] --- Fully heals the specified target.");
        API.sendChatMessageToPlayer(player, "~b~[HELP] [ADMIN] || /armor [TARGET] --- Gives the specified target full Armor.");
        API.sendChatMessageToPlayer(player, "~b~[HELP] [ADMIN] || /fix --- Repairs the current Vehicle completely.");
        API.sendChatMessageToPlayer(player, "~b~[HELP] [ADMIN] || /tele [TARGET] --- Teleports executing player to the Target.");
        API.sendChatMessageToPlayer(player, "~b~[HELP] [ADMIN] || /tpm [TARGET] --- Teleports target to the executing Player.");
    }
}