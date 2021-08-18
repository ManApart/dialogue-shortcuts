

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


//https://stardewvalleywiki.com/Modding:Modder_Guide/APIs/Events
namespace MenuSkip {

    public class MainModClass : Mod {
        private static MainModClass instance;

      private String statsFilePath;
        private int lastDayRun = -1;
        private Dictionary<Chest, List<Item>> chestsToShip;
        private Dictionary<Farmer, List<Item>> farmerItems;


        public override void Entry(IModHelper helper) {
           instance = this;            
            helper.Events.GameLoop.Saved += AfterSaveEvent;

            chestsToShip = new Dictionary<Chest, List<Item>>();
            farmerItems = new Dictionary<Farmer, List<Item>>();

            Log("MenuSkip by Iceburg333 => Initialized");
        }

        private void AfterSaveEvent(object sender, EventArgs e) {            
            Log("after save");
            
        }

    
        public static void Log(string message) {
            instance.Monitor.Log(message, LogLevel.Debug);
        }
    }
}
