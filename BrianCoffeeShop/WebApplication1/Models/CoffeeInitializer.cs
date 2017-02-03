using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    //Note the database will be dropped and re-created only if the model changes.  This will persist any
    //photos added by the user.
    public class CoffeeInitializer : DropCreateDatabaseIfModelChanges<CoffeeContext>
    {
        //This method puts sample data into the database
        protected override void Seed(CoffeeContext context)
        {
            base.Seed(context);

            //Create the Brands
            var brands = new List<Brand>
            {
                new Brand{
                    BrandID = 1,
                    Name = "Barcaffe",
                    Description = "Barcaffe is a Slovenian coffee brand manufactured by Droga Kolinska.",
                    PhotoFile = getFileBytes("\\Images\\barcaffe_logo.png"),
                    ImageMimeType = "image/png"
                },
                new Brand{
                    BrandID = 2,
                    Name = "Black Ivory Coffee",
                    Description = "Black Ivory Coffee is a brand of coffee produced by the Black Ivory Coffee Company Ltd in Northern Thailand from Arabica coffee beans consumed by elephants and collected from their feces.",
                    PhotoFile = getFileBytes("\\Images\\blackivory.png"),
                    ImageMimeType = "image/png"
                },
                new Brand{
                    BrandID = 3,
                    Name = "Caribou Coffee",
                    Description = "Caribou Coffee Company is a specialty coffee and espresso retailer, the second largest in the United States after Starbucks.",
                    PhotoFile = getFileBytes("\\Images\\caribou_logo.png"),
                    ImageMimeType = "image/png"
                },
                new Brand{
                    BrandID = 4,
                    Name = "Costa Coffee",
                    Description = "Costa Coffee is a British multinational coffeehouse company headquartered in Dunstable, England, and a wholly owned subsidiary of Whitbread. It is the second largest coffeehouse chain in the world behind Starbucks and the largest in the United Kingdom.",
                    PhotoFile = getFileBytes("\\Images\\costa_logo.png"),
                    ImageMimeType = "image/png"
                },
                new Brand{
                    BrandID = 5,
                    Name = "Dallmayr",
                    Description = "Today, the company has grown to become an internationally well-known manufacturer of quality coffee, and since 1930 has owned and operated a cafe, housed in a historic building in Munich where freshly roasted coffee can be enjoyed with salads and small appetizers or chocolate truffles and other pastries.",
                    PhotoFile = getFileBytes("\\Images\\dallmayr_logo.png"),
                    ImageMimeType = "image/png"
                },
                new Brand{
                    BrandID = 6,
                    Name = "Folgers",
                    Description = "Folgers Coffee is a popular brand of coffee in the United States, part of the food and beverage division of The J.M. Smucker Company.",
                    PhotoFile = getFileBytes("\\Images\\folgers_logo.png"),
                    ImageMimeType = "image/png"
                },
                new Brand{
                    BrandID = 7,
                    Name = "Kona Coffee",
                    Description = "Kona coffee is the market name for coffee cultivated on the slopes of Hualalai and Mauna Loa in the North and South Kona Districts of the Big Island of Hawaii. It is one of the most expensive coffees in the world.",
                    PhotoFile = getFileBytes("\\Images\\kona_logo.png"),
                    ImageMimeType = "image/png"
                },
                new Brand{
                    BrandID = 8,
                    Name = "Keurig",
                    Description = "Keurig is an American manufacturer of coffee brewers for both home and commercial use.",
                    PhotoFile = getFileBytes("\\Images\\keurig_logo.png"),
                    ImageMimeType = "image/png"
                },
                new Brand{
                    BrandID = 9,
                    Name = "Nescafé",
                    Description = "Nescafé is a brand of instant coffee made by Nestlé.",
                    PhotoFile = getFileBytes("\\Images\\nescafe_logo.png"),
                    ImageMimeType = "image/png"
                },
                new Brand{
                    BrandID = 10,
                    Name = "Seattle's Best Coffee",
                    Description = "Seattle's Best Coffee, a wholly owned subsidiary of Starbucks, is a specialty coffee retailer and wholesaler based in Seattle, Washington.",
                    PhotoFile = getFileBytes("\\Images\\seattle_logo.png"),
                    ImageMimeType = "image/png"
                }
            };
            brands.ForEach(s => context.Brands.Add(s));
            context.SaveChanges();

            //Create some coffees
            var coffees = new List<Coffee>
            {
                new Coffee {
                    CoffeeID = 1,
                    BrandID = 1,
                    Name = "Selection",
                    Description = "Distinctive, Savory, Bitter, Sour",
                    UserName = "Admin",
                    PhotoFile = getFileBytes("\\Images\\barcaffe_Selection.jpg"),
                    ImageMimeType = "image/jpeg",
                },
                new Coffee {
                    CoffeeID = 2,
                    BrandID = 2,
                    Name = "Whole Roasted",
                    Description = "Gentle, Fruity",
                    UserName = "Admin",
                    PhotoFile = getFileBytes("\\Images\\blackivory.png"),
                    ImageMimeType = "image/png",
                },
                new Coffee {
                    CoffeeID = 3,
                    BrandID = 3,
                    Name = "LakeShore Blend",
                    Description = "Medium Roast, Smooth, Fresh",
                    UserName = "Admin",
                    PhotoFile = getFileBytes("\\Images\\caribou.jpg"),
                    ImageMimeType = "image/jpg",
                },
                new Coffee {
                    CoffeeID = 4,
                    BrandID = 4,
                    Name = "Old Paradise Street",
                    Description = "Fruity, Maple Syrup, Bitter Sweet aftertaste",
                    UserName = "Admin",
                    PhotoFile = getFileBytes("\\Images\\costa.jpg"),
                    ImageMimeType = "image/jpg",
                },
                new Coffee {
                    CoffeeID = 5,
                    BrandID = 5,
                    Name = "Classic",
                    Description = "Aromatic Flavor",
                    UserName = "Admin",
                    PhotoFile = getFileBytes("\\Images\\dallmayr.jpg"),
                    ImageMimeType = "image/jpg",
                },
                new Coffee {
                    CoffeeID = 6,
                    BrandID = 6,
                    Name = "French Vanilla",
                    Description = "Mellow, Creamy",
                    UserName = "Admin",
                    PhotoFile = getFileBytes("\\Images\\folgers.jpg"),
                    ImageMimeType = "image/jpg",
                },
                new Coffee {
                    CoffeeID = 7,
                    BrandID = 7,
                    Name = "Medium Roast",
                    Description = "Delicate, Mild",
                    UserName = "Admin",
                    PhotoFile = getFileBytes("\\Images\\kona.jpg"),
                    ImageMimeType = "image/jpg",
                },
                new Coffee {
                    CoffeeID = 8,
                    BrandID = 8,
                    Name = "Mocha Nut Fudge",
                    Description = "Nutty, Chocolately, Caramely",
                    UserName = "Admin",
                    PhotoFile = getFileBytes("\\Images\\keurig.jpg"),
                    ImageMimeType = "image/jpg",
                },
                new Coffee {
                    CoffeeID = 9,
                    BrandID = 9,
                    Name = "Alta Rica",
                    Description = "Roch, Bold, Smouldering",
                    UserName = "Admin",
                    PhotoFile = getFileBytes("\\Images\\nescafe.png"),
                    ImageMimeType = "image/png",
                },
                new Coffee {
                    CoffeeID = 10,
                    BrandID = 10,
                    Name = "Breakfast Blend",
                    Description = "Dark Chocolate, Smooth Finish",
                    UserName = "Admin",
                    PhotoFile = getFileBytes("\\Images\\seattle_best.jpg"),
                    ImageMimeType = "image/jpg",
                }
            };
            coffees.ForEach(s => context.Coffees.Add(s));
            context.SaveChanges();
        }

        //This gets a byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }

}