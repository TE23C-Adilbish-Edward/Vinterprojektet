using System.Formats.Asn1;
using System.Numerics;
using Raylib_cs;


/*

Två katoriger, vapen och förbrukningsvaror

UI ska kontrolleras med WASD eller pilar

Pengarsystem och priser för shoppen

vapenmeny = categorymenu = 1 

förbrukningsvarar = categorymenu = 0

*/
public class Program
{
    public static void Main(string[] arga)
    {
        //ljud och sound effects
        Raylib.InitAudioDevice();   
        Sound buyitem = Raylib.LoadSound("snd_buyitem.ogg");
        Sound select = Raylib.LoadSound("snd_bell.ogg");
        Sound back = Raylib.LoadSound("snd_bomb.ogg");
        Sound nomoney = Raylib.LoadSound("mus_badnote1.ogg");
        Sound switching = Raylib.LoadSound("snd_tem.ogg");

        Raylib.InitWindow(800, 600, "item shop");
        Raylib.SetTargetFPS(60);
        
        //variabler

        int categorymenu = 1;

        int hoverselect = 0;

        int transition = 0;

        int shopframeY = 0;

        int shopmenu = 0;

        int selectedcategory = 0;

        int money = 1000;

        int warningtimer = 0;

        //categorymenu logic

        static int selectfunction(int hoverselect, Sound switching)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Right) || Raylib.IsKeyPressed(KeyboardKey.D))
            {
                hoverselect = 1;
                Raylib.PlaySound(switching);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.Left) || Raylib.IsKeyPressed(KeyboardKey.A))
            {
                hoverselect = 0;
                Raylib.PlaySound(switching);
            }
            return hoverselect;
        }

        static void categorymenuactive(int selCat, int money)
        {
            Raylib.DrawText("Money: " + money + "$", 0, 0, 50, Color.White);
            //leftwindow weapons
            Raylib.DrawRectangle(50, 50, 325, 500, Color.SkyBlue);

            //logo

            int swordxpos = 325 / 2 + 50;
            Raylib.DrawRectangle(swordxpos - 10, 200, 20, 100, Color.LightGray);

            // baldetip trianglevectors
            Vector2 corner1 = new(swordxpos, 180);
            Vector2 corner2 = new(swordxpos - 10, 200);
            Vector2 corner3 = new(swordxpos + 10, 200);

            Raylib.DrawTriangle(corner1, corner2, corner3, Color.LightGray);

            Raylib.DrawRectangle(swordxpos - 30, 300, 60, 10, Color.Brown);
            Raylib.DrawRectangle(swordxpos - 10, 310, 20, 30, Color.Brown);

            //text

            Raylib.DrawText("Weapons", swordxpos - 50, 100, 25, Color.White);

            //buybutton

            if (selCat == 0)
            {

                Raylib.DrawRectangle(swordxpos - 100, 400, 200, 100, Color.White);
                Raylib.DrawRectangle(swordxpos - 95, 400 + 5, 190, 90, Color.Lime);
                Raylib.DrawText("Select", swordxpos - 39, 435, 25, Color.White);

            }
            else
            {
                Raylib.DrawRectangle(swordxpos - 100, 400, 200, 100, Color.Lime);
                Raylib.DrawText("Select", swordxpos - 39, 435, 25, Color.White);
            }


            //rightwindow consumables
            Raylib.DrawRectangle(425, 50, 325, 500, Color.SkyBlue);

            //logo
            int potionxpos = 325 / 2 + 425;

            Raylib.DrawCircle(potionxpos, 300, 50, Color.White);
            Raylib.DrawCircle(potionxpos, 300, 45, Color.Purple);

            Raylib.DrawRectangle(potionxpos - 10, 222, 20, 35, Color.Brown);
            Raylib.DrawRectangle(potionxpos - 15, 212, 30, 10, Color.Brown);

            //text

            Raylib.DrawText("Consumables", potionxpos - 70, 100, 25, Color.White);

            //buybutton

            if (selCat == 1)
            {

                Raylib.DrawRectangle(potionxpos - 100, 400, 200, 100, Color.White);
                Raylib.DrawRectangle(potionxpos - 95, 400 + 5, 190, 90, Color.Lime);
                Raylib.DrawText("Select", potionxpos - 39, 435, 25, Color.White);

            }
            else
            {
                Raylib.DrawRectangle(potionxpos - 100, 400, 200, 100, Color.Lime);
                Raylib.DrawText("Select", potionxpos - 39, 435, 25, Color.White);
            }
        }

        static void shopmenuactive(int selCat, int selectedcategory, int money)
        {
            Raylib.DrawText("Money: " + money + "$", 0, 0, 50, Color.White);
            //weapons buymenu
            if (selectedcategory == 0) {
                
            //leftwindow
            Raylib.DrawRectangle(50, 50, 325, 500, Color.SkyBlue);

            int leftwindowX = 325 / 2 + 50;

            Raylib.DrawRectangle(leftwindowX - 10, 200, 20, 100, Color.LightGray);

            //sword
            Vector2 corner1 = new(leftwindowX, 180);
            Vector2 corner2 = new(leftwindowX - 10, 200);
            Vector2 corner3 = new(leftwindowX + 10, 200);

            Raylib.DrawTriangle(corner1, corner2, corner3, Color.LightGray);

            Raylib.DrawRectangle(leftwindowX - 30, 300, 60, 10, Color.Brown);
            Raylib.DrawRectangle(leftwindowX - 10, 310, 20, 30, Color.Brown);

            //text
            Raylib.DrawText("Sword", leftwindowX - 38, 100, 25, Color.White);
            Raylib.DrawText("350$", leftwindowX - 26, 365, 25, Color.White);

            //buybutton

            if (selCat == 0)
            {

                Raylib.DrawRectangle(leftwindowX - 100, 400, 200, 100, Color.White);
                Raylib.DrawRectangle(leftwindowX - 95, 400 + 5, 190, 90, Color.Lime);
                Raylib.DrawText("Buy", leftwindowX - 24, 435, 25, Color.White);

            }
            else
            {
                Raylib.DrawRectangle(leftwindowX - 100, 400, 200, 100, Color.Lime);
                Raylib.DrawText("Buy", leftwindowX - 24, 435, 25, Color.White);
            }

            //rightwindow

            Raylib.DrawRectangle(425, 50, 325, 500, Color.SkyBlue);


            //backshield
            int rightwindowX = 325 / 2 + 425;
            Raylib.DrawRectangle(rightwindowX - 89, 135, 180, 115, Color.LightGray);
            
            Vector2 backshieldcorner1 = new(rightwindowX + 90, 250);
            Vector2 backshieldcorner2 = new(rightwindowX - 90, 250);
            Vector2 backshieldcorner3 = new(rightwindowX, 368);
            Raylib.DrawTriangle(backshieldcorner1, backshieldcorner2, backshieldcorner3, Color.LightGray);

            //shield
            Raylib.DrawRectangle(rightwindowX - 75, 150, 150, 100, Color.DarkBrown);
            
            Vector2 shieldcorner1 = new(rightwindowX + 75, 250);
            Vector2 shieldcorner2 = new(rightwindowX - 75, 250);
            Vector2 shieldcorner3 = new(rightwindowX, 350);
            Raylib.DrawTriangle(shieldcorner1, shieldcorner2, shieldcorner3, Color.DarkBrown);

            //text
            Raylib.DrawText("Shield", rightwindowX - 38, 100, 25, Color.White);
            Raylib.DrawText("200$", rightwindowX - 26, 365, 25, Color.White);

            //buybutton select graphic
            if (selCat == 1)
            {
                Raylib.DrawRectangle(rightwindowX - 100, 400, 200, 100, Color.White);
                Raylib.DrawRectangle(rightwindowX - 95, 400 + 5, 190, 90, Color.Lime);
                Raylib.DrawText("Buy", rightwindowX - 24, 435, 25, Color.White);

            }
            else
            {
                Raylib.DrawRectangle(rightwindowX - 100, 400, 200, 100, Color.Lime);
                Raylib.DrawText("Buy", rightwindowX - 24, 435, 25, Color.White);
            }
            }
           

           //consumables buymenu
            if (selectedcategory == 1) {

            //leftwindow
            Raylib.DrawRectangle(50, 50, 325, 500, Color.SkyBlue);

            //potion
            int leftwindowX2 = 325 / 2 + 50;

            Raylib.DrawCircle(leftwindowX2, 300, 50, Color.White);
            Raylib.DrawCircle(leftwindowX2, 300, 45, Color.Purple);

            Raylib.DrawRectangle(leftwindowX2 - 10, 222, 20, 35, Color.Brown);
            Raylib.DrawRectangle(leftwindowX2 - 15, 212, 30, 10, Color.Brown);

            //text
            Raylib.DrawText("Potion", leftwindowX2 - 38, 100, 25, Color.White);
            Raylib.DrawText("80$", leftwindowX2 - 19, 365, 25, Color.White);

            //buybutton
            if (selCat == 0)
            {

                Raylib.DrawRectangle(leftwindowX2 - 100, 400, 200, 100, Color.White);
                Raylib.DrawRectangle(leftwindowX2 - 95, 400 + 5, 190, 90, Color.Lime);
                Raylib.DrawText("Buy", leftwindowX2 - 24, 435, 25, Color.White);

            }
            else
            {
                Raylib.DrawRectangle(leftwindowX2 - 100, 400, 200, 100, Color.Lime);
                Raylib.DrawText("Buy", leftwindowX2 - 24, 435, 25, Color.White);
            }


            //rightwindow
            Raylib.DrawRectangle(425, 50, 325, 500, Color.SkyBlue);

            //health kit
            int rightwindowX2 = 325 / 2 + 425;

            Raylib.DrawRectangle(rightwindowX2 - 100, 230, 200, 100, Color.LightGray);

            //handle
            Raylib.DrawRectangle(rightwindowX2 - 60, 180, 120, 20, Color.LightGray);

            Raylib.DrawRectangle(rightwindowX2 - 60, 180, 20, 60, Color.LightGray);
            Raylib.DrawRectangle(rightwindowX2 + 40, 180, 20, 60, Color.LightGray);

            //whiteparts
            Raylib.DrawRectangle(rightwindowX2 - 55, 185, 110, 10, Color.White);
            Raylib.DrawRectangle(rightwindowX2 + 45, 190, 10, 60, Color.White);
            Raylib.DrawRectangle(rightwindowX2 - 55, 190, 10, 60, Color.White);
            Raylib.DrawRectangle(rightwindowX2 - 95, 235, 190, 90, Color.White);

            //cross
            Raylib.DrawRectangle(rightwindowX2 - 5, 250, 10, 50, Color.Red);
            Raylib.DrawRectangle(rightwindowX2 - 25, 270, 50, 10, Color.Red);
            

            //text
            Raylib.DrawText("Health Kit", rightwindowX2 - 60, 100, 25, Color.White);
            Raylib.DrawText("150$", rightwindowX2 - 26, 365, 25, Color.White);

            //buybutton
            if (selCat == 1)
            {

                Raylib.DrawRectangle(rightwindowX2 - 100, 400, 200, 100, Color.White);
                Raylib.DrawRectangle(rightwindowX2 - 95, 400 + 5, 190, 90, Color.Lime);
                Raylib.DrawText("Buy", rightwindowX2 - 24, 435, 25, Color.White);

            }
            else
            {
                Raylib.DrawRectangle(rightwindowX2 - 100, 400, 200, 100, Color.Lime);
                Raylib.DrawText("Buy", rightwindowX2 - 24, 435, 25, Color.White);
            }
                
            }
           
        }
        
        //varning om man har för lite pengar
        static int nomoneywarning(int warningtimer) {
            if (warningtimer > 0) {
                warningtimer = warningtimer - 1;
            }
            
            return warningtimer;
        }

        //transition graphic
        static int transitionfunction(int shopframeY)
        {

            shopframeY += 20;
            Raylib.DrawRectangle(0, shopframeY - 600, 800, 600, Color.DarkBrown);

            return shopframeY;
        }

        //själva while loopen som håller applikationen uppe
        while (Raylib.WindowShouldClose() == false)
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.Blue);

            //kollar om kategorimenyn är på
            if (categorymenu == 1)
            {
                hoverselect = selectfunction(hoverselect, switching);
                categorymenuactive(hoverselect, money);
                //select funktion
                if (Raylib.IsKeyPressed(KeyboardKey.Space) || Raylib.IsKeyPressed(KeyboardKey.Enter))
                {   
                    Raylib.PlaySound(select);
                    selectedcategory = hoverselect;
                    categorymenu = 0;
                    transition = 0;
                }
            }
            //om kategorimenyn inte är på så körs:
            else
            {
                    if (shopmenu == 0) {
                        categorymenuactive(hoverselect, money);
                    }
                if (shopmenu == 1) {
                    
                    hoverselect = selectfunction(hoverselect, switching);
                    shopmenuactive(hoverselect, selectedcategory, money);
                    //back funktion
                    if (Raylib.IsKeyPressed(KeyboardKey.Backspace)) {
                        shopframeY = 0;
                        shopmenu = 0;
                        categorymenu = 1;
                        Raylib.PlaySound(back);
                    }
                    //köp funktion
                    if (Raylib.IsKeyPressed(KeyboardKey.Space) || Raylib.IsKeyPressed(KeyboardKey.Enter)) {
                        
                        if (selectedcategory == 0) {
                            if (hoverselect == 0) {
                                if (money >= 350) {
                                    Raylib.PlaySound(buyitem);
                                    money = money - 350;
                                } else {
                                    warningtimer = 50;
                                    Raylib.PlaySound(nomoney);
                                }
                            }
                            if (hoverselect == 1) {
                                if (money >= 200) {
                                    Raylib.PlaySound(buyitem);
                                    money = money - 200;
                                } else {
                                    warningtimer = 50;
                                    Raylib.PlaySound(nomoney);
                                }
                            }
                        }
                        if (selectedcategory == 1) {
                            if (hoverselect == 0) {
                                if (money >= 80) {
                                    Raylib.PlaySound(buyitem);
                                    money = money - 80;
                                } else {
                                    warningtimer = 50;
                                    Raylib.PlaySound(nomoney);
                                }
                            }
                            if (hoverselect == 1) {
                                if (money >= 150) {
                                    Raylib.PlaySound(buyitem);
                                    money = money - 150;
                                } else {
                                    warningtimer = 50;
                                    Raylib.PlaySound(nomoney);
                                }
                            }
                        }
                    }
                }
                //transitions logik
                if (transition == 0)
                {   
                    shopframeY = transitionfunction(shopframeY);
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
                    warningtimer = nomoneywarning(warningtimer);
                }
            }
            //slut
            Raylib.EndDrawing();

        }
    }
}

