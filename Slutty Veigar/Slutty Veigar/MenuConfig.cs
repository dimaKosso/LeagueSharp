﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp.Common;

namespace Slutty_Veigar
{
    class MenuConfig : Helper
    {
        public static void OnLoad()
        {

            Config = new Menu(Menuname, Menuname, true);
            Config.AddSubMenu(new Menu("Orbwalking", "Orbwalking"));

            var targetSelectorMenu = new Menu("Target Selector", "Target Selector");
            TargetSelector.AddToMenu(targetSelectorMenu);
            Config.AddSubMenu(targetSelectorMenu);

            Orbwalker = new Orbwalking.Orbwalker(Config.SubMenu("Orbwalking"));

            var combomenu = new Menu("Combo Settings", "Combo Settings");
            {
                AddBool(combomenu, "Use [Q]", "useqcombo");
                combomenu.AddItem(new MenuItem("usewmode", "[W] Mode"))
                    .SetValue(new StringList(new[] {"Regular", "Only Stunned", "Don't Use"}));

                AddBool(combomenu, "Use [E]", "useecombo");
                var rsettings = new Menu("[R] [S]ettings", "[R] [S]ettings");
                foreach (var hero in HeroManager.Enemies)
                {
                    rsettings.AddItem(new MenuItem("user" + hero.ChampionName, "Use [R] " + hero.ChampionName))
                        .SetValue(new StringList(new[] {"Use", "Don't Use"}));
                }
                AddBool(rsettings, "Use R", "user");
                AddBool(combomenu, "Block AA in Combo", "aablock", false);
                combomenu.AddSubMenu(rsettings);
            }
            Config.AddSubMenu(combomenu);

            var harassmenu = new Menu("Harass Settings", "Harass Settings");
            {
                AddBool(harassmenu, "Use [Q]", "useqharass");
                AddBool(harassmenu, "Smart Q Enable", "smartq"); // so much kappa
                harassmenu.AddItem(new MenuItem("usewmodeharass", "[W] Mode"))
                    .SetValue(new StringList(new[] { "Regular", "Only Stunned", "Don't Use" }));
                AddBool(harassmenu, "Use [E]", "useeharass");
            }
            Config.AddSubMenu(harassmenu);

            var lanemenu = new Menu("Lane Clear Settings", "Lane Clear Settings");
            {
                AddValue(lanemenu, "Min %Mana To Lane Clear", "minmana", 40);
                AddBool(lanemenu, "Use [Q]", "useqlaneclear");
                lanemenu.AddItem(new MenuItem("qmode", "Q Modes"))
                    .SetValue(new StringList(new[] {"2 Minions Kills", "1 Minion Kill", "None"}));
                AddBool(lanemenu, "Use [W]", "usewlaneclear");
                AddValue(lanemenu, "Min Minions For w", "wminionjigolo", 3, 1, 20);           
            }
            Config.AddSubMenu(lanemenu);

            var drawingmenu = new Menu("Drawing Menu", "[D]rawing Menu");
            {
                AddBool(drawingmenu, "Display Player Damage On Target", "FillDamage");
                AddBool(drawingmenu, "Fill Damage", "RushDrawWDamageFill");
            }
            Config.AddSubMenu(drawingmenu);

            var lasthit = new Menu("Last Hit", "[L]ast Hit");
            {
                AddValue(lasthit, "Min %Mana To Lane Clear", "minmanalast", 40);
                AddBool(lasthit, "Use [Q]", "useqlaneclearlast");
                lasthit.AddItem(new MenuItem("qmodelast", "Q Modes"))
                    .SetValue(new StringList(new[] { "2 Minions Kills", "1 Minion Kill", "None" }));     
            }
            Config.AddSubMenu(lasthit);
            var enviorment = new Menu("enviorment", "eviorment");
            {
                AddBool(enviorment, "Auto Tear Stacks In Fountain", "tearoptions");
                AddKeyBind(enviorment, "Flee Mode", "fleemode", 'Z', KeyBindType.Press);
                AddBool(enviorment,"Use E In Flee Mode", "efleemode");
            }
            Config.AddSubMenu(enviorment);

            
        }
    }
}
