

using StardewModdingAPI;
using StardewValley;
using StardewValley.Network;
using Microsoft.Xna.Framework.Net;
using System;
using System.Collections.Generic;
using System.IO;
using StardewValley.Menus;
using StardewModdingAPI.Events;
using StardewValley.Objects;
using Netcode;
using Microsoft.Xna.Framework;


//https://stardewvalleywiki.com/Modding:Modder_Guide/APIs/Events
namespace MenuSkip {

    public class MainModClass : Mod {
        private static MainModClass instance;

        public override void Entry(IModHelper helper) {
           instance = this;            
            helper.Events.Input.ButtonPressed += OnMenu;

            Log("MenuSkip by Iceburg333 => Initialized");
        }

        private void OnMenu(object sender, EventArgs e) {  
            ButtonPressedEventArgs be = e as ButtonPressedEventArgs;
            if (Game1.activeClickableMenu != null)
            {

                if (Game1.activeClickableMenu is ChooseFromListMenu)
                {
                    ChooseFromListMenu menu = Game1.activeClickableMenu as ChooseFromListMenu;
                    Rectangle click = menu.forwardButton.bounds;
                    menu.receiveLeftClick(click.X, click.Y);
                }

                Log("Pressed in Menu");
                if (be.Button == SButton.Space)
                {
                    Log("Pressed Space in Menu");
                }
                
            }
            
            
        }

    
        public static void Log(string message) {
            instance.Monitor.Log(message, LogLevel.Debug);
        }
    }
}
