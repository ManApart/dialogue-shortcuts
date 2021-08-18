

using StardewModdingAPI;
using StardewValley;
using System;
using StardewValley.Menus;
using StardewModdingAPI.Events;


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
                //Log("In Menu " + Game1.activeClickableMenu);
                switch (be.Button)
                {
                    case SButton.Space:
                    case SButton.F1:
                        ChooseSelection(0, Game1.activeClickableMenu);
                        break;
                    case SButton.F2:
                        ChooseSelection(1, Game1.activeClickableMenu);
                        break;
                    case SButton.F3:
                        ChooseSelection(2, Game1.activeClickableMenu);
                        break;
                    case SButton.F4:
                        ChooseSelection(3, Game1.activeClickableMenu);
                        break;
                    default:
                        break;
                }
               

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
                    Log("Picking " + menu.responses[selection].responseText);
                    menu.responseCC[selection].snapMouseCursorToCenter();
                    
                    //Point click = menu.responseCC[selection].bounds.Center;
                    //menu.receiveLeftClick(click.X, click.Y);
                }

            }
        }

    
        public static void Log(string message) {
            instance.Monitor.Log(message, LogLevel.Debug);
        }
    }
}
