

using StardewModdingAPI;
using StardewValley;
using System;
using StardewValley.Menus;
using StardewModdingAPI.Events;
using Microsoft.Xna.Framework;


//https://stardewvalleywiki.com/Modding:Modder_Guide/APIs/Events
namespace MenuSkip {

    public class MainModClass : Mod {
        private static MainModClass instance;
        private IClickableMenu confirmMenu = null;

        public override void Entry(IModHelper helper) {
           instance = this;            
            helper.Events.Input.ButtonPressed += OnMenu;
            helper.Events.GameLoop.UpdateTicked += OnUpdate;

            Log("MenuSkip by Iceburg333 => Initialized");
        }

        private void OnMenu(object sender, EventArgs e) {  
            ButtonPressedEventArgs be = e as ButtonPressedEventArgs;
            if (Game1.activeClickableMenu != null)
            {
                //Log("In Menu " + Game1.activeClickableMenu);
                switch (be.Button)
                {
                    case SButton.Space:
                    case SButton.F1:
                    case SButton.W:
                        ChooseSelection(0, Game1.activeClickableMenu);
                        break;
                    case SButton.F2:
                    case SButton.S:
                        ChooseSelection(1, Game1.activeClickableMenu);
                        break;
                    case SButton.F3:
                    case SButton.A:
                        ChooseSelection(2, Game1.activeClickableMenu);
                        break;
                    case SButton.F4:
                    case SButton.D:
                        ChooseSelection(3, Game1.activeClickableMenu);
                        break;
                    default:
                        break;
                }

            }
            
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            if (confirmMenu != null && Game1.activeClickableMenu == confirmMenu)
            {
                confirmMenu.receiveKeyPress(Microsoft.Xna.Framework.Input.Keys.Space);
            } else if (confirmMenu != null)
            {
                Game1.input.SetMousePosition(Game1.viewport.Width/2, Game1.viewport.Height/2);
                confirmMenu = null;
            }

        }

        private void ChooseSelection(int selection, IClickableMenu menuIn)
        {
            if (menuIn is DialogueBox)
            {
                DialogueBox menu = menuIn as DialogueBox;
                if (selection >= menu.responses.Count)
                {
                    selection = menu.responses.Count - 1;
                }

                if (menu.responses.Count > 0)
                {
                    //Log("Picking " + menu.responses[selection].responseText);
                    menu.responseCC[selection].snapMouseCursorToCenter();
                    confirmMenu = menu;

                }

            }
        }

    
        public static void Log(string message) {
            instance.Monitor.Log(message, LogLevel.Debug);
        }
    }
}
