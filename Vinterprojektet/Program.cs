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


Raylib.InitWindow(800, 600, "item shop");
Raylib.SetTargetFPS(60);

int categorymenu = 1;

int selectedcategory = 1;

while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.Blue);

    if (categorymenu == 1) {
        
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

        Raylib.DrawRectangle(swordxpos - 100, 400, 200, 100, Color.Lime);

        Raylib.DrawText("Selected", swordxpos, 400, 25, Color.White);

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

    }

    Raylib.EndDrawing();



    
}