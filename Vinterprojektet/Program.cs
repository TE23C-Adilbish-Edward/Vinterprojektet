using System.Formats.Asn1;
using System.Numerics;
using Raylib_cs;


/*

Två katoriger, vapen och förbrukningsvaror. Kan väljas med A och D eller med vänsterpil och högerpil. 
bekräfta val med ENTER och för att ångra sig tryck BACKSPACE. Om du är inne på vald kategori köp 
produkter med ENTER. Ska finnas 2 produkter per kategori. För att veta om spelaren är inne i vapenkategorin
eller förbruknings-kategorin så använder jag variabeln "categorymenu". Om variabeln är = 0 så är
förbruknings-kategorin aktiv, annars om variabeln är = 1 så är det vapenkategorin som är aktiv. När
spelet startas börjar spelaren alltid med $1000.    
*/
public class Program
{
    public static void Main(string[] arga)
    {
        //Laddar in ljudfiler så fort spelet startas
        Raylib.InitAudioDevice();   
        Sound buyitem = Raylib.LoadSound("snd_buyitem.ogg");
        Sound select = Raylib.LoadSound("snd_bell.ogg");
        Sound back = Raylib.LoadSound("snd_bomb.ogg");
        Sound nomoney = Raylib.LoadSound("mus_badnote1.ogg");
        Sound switching = Raylib.LoadSound("snd_tem.ogg");

        Raylib.InitWindow(800, 600, "item shop");
        Raylib.SetTargetFPS(60);
        
        //Variabler som kommer att förändras i framtiden

        int categorymenu = 1;

        int hoverselect = 0;

        int transition = 0;

        int shopframeY = 0;

        int shopmenu = 0;

        int selectedcategory = 0;

        int money = 1000;

        int warningtimer = 0;

        //Själva "while loopen" som håller applikationen uppe
        while (Raylib.WindowShouldClose() == false)
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.Blue);

            //Kollar om kategorimenyn är på och visar motsvarande meny grafiskt
            if (categorymenu == 1)
            {
                hoverselect = Shop.SelectFunction(hoverselect, switching);
                Shop.CategoryMenuActive(hoverselect, money);
                //If-stats som körs om spelaren har valt kategori och går in på kategorin som spelaren har valt
                if (Raylib.IsKeyPressed(KeyboardKey.Space) || Raylib.IsKeyPressed(KeyboardKey.Enter))
                {   
                    Raylib.PlaySound(select);
                    selectedcategory = hoverselect;
                    categorymenu = 0;
                    transition = 0;
                }
            }
            //Annars om kategorimenyn inte är på visas produktmenyn om transitionen är klar
            else
            {
                if (shopmenu == 1) {

                    //Uppdaterar spelarens val grafiskt för att visa vad spelaren väljer
                    hoverselect = Shop.SelectFunction(hoverselect, switching);
                    Shop.ShopMenuActive(hoverselect, selectedcategory, money);

                    //Om BACKSPACE trycks så väljer spelaren att gå tillbaka till kategorimenyn
                    if (Raylib.IsKeyPressed(KeyboardKey.Backspace)) {
                        shopframeY = 0;
                        shopmenu = 0;
                        categorymenu = 1;
                        warningtimer = 0;
                        Raylib.PlaySound(back);
                    }

                    //Självaste köplogiken, kollar vad för kategori spelaren är i och vad för produkt spelaren har valt i form av en 2D array (effektiviserad från tidigare kod som endast använde if-satser). Om spelaren inte har tillräckligt mycket pengar för att ha råd med produkten så visas det en varning
                    if (Raylib.IsKeyPressed(KeyboardKey.Space) || Raylib.IsKeyPressed(KeyboardKey.Enter)) {
                        
                        int[,] prices = {
                        {350, 200}, 
                        {80, 150}
                        };

                        if (selectedcategory >= 0 && hoverselect >= 0 && selectedcategory < prices.GetLength(0) && hoverselect < prices.GetLength(1)) {
                            
                            int cost = prices[selectedcategory, hoverselect];
                            
                            if (money >= cost) {
                                Raylib.PlaySound(buyitem);
                                money -= cost;
                            } else {
                                warningtimer = 50;
                                Raylib.PlaySound(nomoney);
                            }
                        }
                    }
                }
                //Hindrar att kategorimenyn göms så fort spelaren har valt kategori för att ha en fin övergång till produktmenyn
                if (shopmenu == 0) {
                        Shop.CategoryMenuActive(hoverselect, money);
                    }

                //Gömmer kategorimenyn när transition-rektangeln täcker hela skärmen och visar produktmenyn
                if (transition == 0)
                {   
                    shopframeY = Shop.TransitionFunction(shopframeY);
                    if (shopframeY == 600)
                    {
                        shopmenu = 1;
                        hoverselect = 0;
                    }
                    if (shopframeY >= 1200)
                    {
                        transition = 1;
                    }

                }
                //varning logik
                if (warningtimer > 0) {
                    Raylib.DrawText("You do not have sufficient funds", 120, 250, 30, Color.Red);
                    warningtimer = Shop.NoMoneyWarning(warningtimer);
                }
            }
            //slut
            Raylib.EndDrawing();

        }
    }
}

