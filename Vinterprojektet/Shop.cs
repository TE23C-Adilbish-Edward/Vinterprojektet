using Microsoft.VisualBasic;
using Raylib_cs;
using System.Numerics;
//Fil reserverad för funktioner

public class Shop
{
    //Funktionens syfte är att hantera grafiken och körs konstant när en kategori är vald
    public static void ShopMenuActive(int selCat, int selectedcategory, int money)
    {
        Raylib.DrawText("Money: $" + money, 0, 0, 50, Color.White);
        //weapons buymenu
        if (selectedcategory == 0)
        {

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
            Raylib.DrawText("$350", leftwindowX - 26, 365, 25, Color.White);

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
            Raylib.DrawText("$200", rightwindowX - 26, 365, 25, Color.White);

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
        if (selectedcategory == 1)
        {

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
            Raylib.DrawText("$80", leftwindowX2 - 19, 365, 25, Color.White);

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
            Raylib.DrawText("$150", rightwindowX2 - 26, 365, 25, Color.White);

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
    
    //Funktionen ändrar vald kategori eller vald produkt om spelaren trycker vänster eller högerpil

    //Uppfyller kriteriet "En metod som returnerar resultat och tar emot flera parametrar"
    public static int SelectFunction(int hoverselect, Sound switching)
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
    
    //Funktionens syfte är att hantera grafiken och körs konstant när en kategori är vald
    public static void CategoryMenuActive(int selCat, int money)
        {
            Raylib.DrawText("Money: $" + money, 0, 0, 50, Color.White);
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

    //Funktionen tar hand om övergången från att visa kategorimenyn till produktmenyn
    public static int TransitionFunction(int shopframeY)
        {

            shopframeY += 20;
            Raylib.DrawRectangle(0, shopframeY - 600, 800, 600, Color.DarkBrown);

            return shopframeY;
        }

    //En "popup" med instruktioner för att informera spelaren vad man kan göra
    public static bool InstructionMenu(bool instructionMenu)
    {
        Raylib.DrawRectangle(0, 0, 800, 600, Color.White);

        Raylib.DrawText("Välkommen till shoppen!", 130, 0, 50, Color.Black);

        Raylib.DrawText("Här kan du köpa items från två olika kategorier.", 130, 100, 25, Color.Black);

        Raylib.DrawText("För att välja en kategori tryck SPACE eller ENTER", 100, 150, 25, Color.Black);

        Raylib.DrawText("För att växla mellan alternativen använd VÄNSTERPIL eller HÖGERPIL", 30, 200, 20, Color.Black);

        Raylib.DrawText("A och D fungerar också", 260, 220, 20, Color.Black);

        Raylib.DrawText("När du har valt en kategori kan du välja att", 140, 270, 25, Color.Black);

        Raylib.DrawText("köpa en produkt med SPACE eller ENTER", 150, 290, 25, Color.Black);

        Raylib.DrawText("För att återvända till kategorimenyn tryck BACKSPACE", 60, 340, 25, Color.Black);

        Raylib.DrawText("Lycka till! Du har nu fått $1000", 140, 390, 30,Color.Black);

        Raylib.DrawText("Tryck ENTER eller SPACE för att fortsätta till shoppen", 50, 500, 25, Color.Gold);

         if (Raylib.IsKeyPressed(KeyboardKey.Space) || Raylib.IsKeyPressed(KeyboardKey.Enter))
                {   
                    instructionMenu = false;
                }
        return instructionMenu;
    }

    //En timer som visar text i en viss mängd tid
    public static int Timer(int timer, Color color, string lastPurchased)
    {
        for (int i = 0; i < timer; i++) {
            
            if (lastPurchased.Length > 0) {
                Raylib.DrawText("Du köpte " + lastPurchased, 300, 250, 30, color);
            } else
            {
                Raylib.DrawText("Du har inte råd till det här", 200, 250, 30, color);
            }
            }
        timer--;   
        return timer;
    }
}
