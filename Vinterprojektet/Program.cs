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
    struct Product {
        public string Name;
        public string Price; 
        public Product(string name, string price) {
            Name = name;
            Price = price;
        }
    }

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

        int warningTimer = 0;

        int purchaseTimer = 0;

        string lastPurchased = "";

        bool instructionMenu = true;

        //Namn och pris på produkterna, jag har valt att använda mig av en array eftersom att jag inte kommer att lägga till något när programmet körs
        Product[,] products = {
          {new Product("Sword", "350"), new Product("Shield", "200")},
          {new Product("Potion", "80"), new Product("Health Kit", "150")}
        };

        //Själva "while loopen" som håller applikationen uppe
        while (Raylib.WindowShouldClose() == false)
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.Blue);

            //Sätter igång instruktionsmenyn i början och fortsätter till shoppen när spelaren väljer att göra det
            if (instructionMenu == true) 
            {
                instructionMenu = Shop.InstructionMenu(instructionMenu);
            }
            else
            {

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

                        if (categorymenu == 0) {
                            shopframeY = 0;
                            shopmenu = 0;
                            categorymenu = 1;
                            warningTimer = 0;
                            purchaseTimer = 0;
                            Raylib.PlaySound(back);
                        }                        
                    }
                    
                    //Självaste köplogiken, kollar vad för kategori spelaren är i och vad för produkt spelaren har valt i form av en 2D array (effektiviserad från tidigare kod som endast använde if-satser). Om spelaren inte har tillräckligt mycket pengar för att ha råd med produkten så visas det en varning
                    if (Raylib.IsKeyPressed(KeyboardKey.Space) || Raylib.IsKeyPressed(KeyboardKey.Enter)) {
                        
                        Product selectedProduct = products[selectedcategory, hoverselect];

                        int productprice = Convert.ToInt32(selectedProduct.Price);

                        if (selectedcategory >= 0 && hoverselect >= 0 && selectedcategory < products.GetLength(0) && hoverselect < products.GetLength(1)) {
                            if (money >= productprice) {
                                Raylib.PlaySound(buyitem);
                                money -= productprice;
                                purchaseTimer = 50;
                                
                                lastPurchased = selectedProduct.Name;
                            } else {
                                warningTimer = 50;
                                Raylib.PlaySound(nomoney);
                            }
                        }
                    }
                }
                //Hindrar att kategorimenyn göms så fort spelaren har valt kategori för att ha en fin övergång till produktmenyn
                if (shopmenu == 0) {
                        Shop.CategoryMenuActive(hoverselect, money);
                    }

                //Gömmer kategorimenyn när transition-rektangeln täcker hela skärmen och visar produktmenyn, flyttar även transition-rektangeln
                if (transition == 0)
                {   
                    shopframeY = Shop.TransitionFunction(shopframeY);
                    if (shopframeY == 600)
                    {
                        shopmenu = 1;
                        hoverselect = 0;
                    } 
                    else if (shopframeY >= 1200)
                    {
                        transition = 1;
                    }

                }
                //om spelaren inte har råd med produkten hen försöker köpa visas det en varning för att informera spelaren
                if (warningTimer > 0) {
                    warningTimer = Shop.Timer(warningTimer, Color.Red, "");
                    purchaseTimer = 0;
                }
                //responsiv köplogik, visar med grön text att du har köpt en produkt
                if (purchaseTimer > 0) {
                    purchaseTimer = Shop.Timer(purchaseTimer, Color.Green, lastPurchased);
                    warningTimer = 0;
                }
                
            }
            }
            //slut
            Raylib.EndDrawing();
        }
    }
}

