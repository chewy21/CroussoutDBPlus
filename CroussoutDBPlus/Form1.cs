using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
// librairie ajoutée
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
//using System.Windows.Controls;
using BrightIdeasSoftware;
// fin lib
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;
using System.Xml.Linq;
//using System.Windows.Controls;

namespace CroussoutDBPlus
{
    public partial class Form1 : Form
    {
        //__________//                                                  //__________//
        //__________//         INIT                                     //__________//
        //__________//                                                  //__________//


        //---------- Variable globales ----------//

        // Adress of CrossoutDb
        public static string apiUrlPrefix = "https://crossoutdb.com/api/v1/recipe/";
        public static string ImageUrlPrefix = "https://crossoutdb.com/img/items/";

        // init de la classe weaponlist
        string wljson = "";
        WeaponList weaponList = new WeaponList
        {
            weapons = new List<Weapon>()
        };


        //----------  ----------//

        int count = 0;

        ImageList imageList = new ImageList();

        //MessageBox.Show(Item.item.name.ToString(), "info" , MessageBoxButtons.OK, MessageBoxIcon.Information);

        //---------- fonction d'init de l'interface graphique ----------//



        //__________//                                                  //__________//
        //__________//         INIT Functions                           //__________//
        //__________//                                                  //__________//
        public Form1()
        {
            InitializeComponent();
            // In your form's constructor or Load event handler, wire up the event handlers.
            List<User> items = new List<User>();
            items.Add(new User() { Name = "John Doe", Age = 42, Sex = SexType.Male });
            items.Add(new User() { Name = "Jane Doe", Age = 39, Sex = SexType.Female });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Sex = SexType.Male });

            listViewRecipe.View = View.Details;

            listViewRecipe.Columns.Add("Id", 100);
            listViewRecipe.Columns.Add("Name", 150);
            //listViewRecipe.Columns.Add("Craftable", 100);



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //---------- Checking Files and Data ----------//
            // checking if /data/ is there
            string directoryPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "data");
            // If not create it
            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }
            //Checking if /data/weaponlist.json exist
            string filePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "data", "weaponlist.json");
            if (!System.IO.File.Exists(filePath))
            {
                // Create a new empty weaponlist.json file
                System.IO.File.Create(filePath).Dispose();
            }
            else{
                // chargement de weaponlist.json dans la classe weaponlist
                wljson = LoadWeaponListFromJsonFile();
                //WeaponList weaponList = JsonConvert.DeserializeObject<WeaponList>(wljson);
                weaponList = JsonConvert.DeserializeObject<WeaponList>(wljson);
            }


            //// chargement de weaponlist.json dans la classe weaponlist
            //wljson = LoadWeaponListFromJson();
            //WeaponList weaponList = JsonConvert.DeserializeObject<WeaponList>(wljson);

            // synchronisation de la classe weaponlist avec la combobox de selection d'arme
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = weaponList.weapons;
            comboBoxItemName.DataSource = bindingSource;
            comboBoxItemName.DisplayMember = "Name";
            comboBoxItemName.ValueMember = "Id";


            // creation des colones pour TLV 
            treeListViewItemRecipe.Columns.Add(new OLVColumn("Id", "Id"));
            treeListViewItemRecipe.Columns.Add(new OLVColumn("Name", "Name"));
            treeListViewItemRecipe.Columns.Add(new OLVColumn("BuyPrice", "BuyPrice"));
            treeListViewItemRecipe.Columns.Add(new OLVColumn("CraftingBuySum", "CraftingBuySum"));

            NameColumn.AspectName = "Name";
            FactionColumn.AspectName = "Faction";
            //IdColumn.AspectName = "Id";
            //ImageIndexColumn.AspectName = "imageIndex";
            QuantityColumn.AspectName = "Quantity";
            FormatBuyPriceColumn.AspectName = "FormatBuyPrice";
            FormatSellPriceColumn.AspectName = "FormatSellPrice";
            FormatCraftingBuySumColumn.AspectName = "FormatCraftingBuySum";
            FormatCraftingSellSumColumn.AspectName = "FormatCraftingSellSum";
            BuyCraftColumn.AspectName = "BuyCraft";
            FormatCraftingMarginColumn.AspectName = "FormatCraftingMargin";

            NameColumn.Text = "Nom";
            FactionColumn.Text = "Faction";
            //IdColumn.Text = "Id";
            //ImageIndexColumn.Text = "Icone";
            QuantityColumn.Text = "Quantitée";
            FormatBuyPriceColumn.Text = "achat (Val. basse)";
            FormatSellPriceColumn.Text = "achat (Val. haute)";
            FormatCraftingBuySumColumn.Text = "craft (Val. basse)";
            FormatCraftingSellSumColumn.Text = "craft (Val. haute)";
            BuyCraftColumn.Text = "Craft ?";
            FormatCraftingMarginColumn.Text = "Marge de profit si crafté";

            //formatage de la tree view d'affichage
            //TreeViewColumn column1 = new TreeViewColumn();
            //column1.Header = "Column 1";
            //column1.Width = 100;
            //TreeViewColumn column2 = new TreeViewColumn();
            //column1.Header = "Column 2";
            //column1.Width = 100;
            //treeViewRecipe.Columns.Add(column1);
            //treeViewRecipe.Columns.Add(column2);
        }

        public enum SexType { Male, Female };

        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Mail { get; set; }

            public SexType Sex { get; set; }
        }


        //__________//                                                  //__________//
        //__________//         FCT INTERFACES                           //__________//
        //__________//                                                  //__________//


        //---------- fonction du bouton update de l'interface graphique ----------//

        private async void buttonItemUpdate_Click(object sender, EventArgs e)
        {
            // recuperation de l'id de l'item
            string id = textBoxItemID.Text;
            // telechargement du json de l'item
            string json = await SendWebRequestForJson(apiUrlPrefix + id);
            // chargement du json dans data
            dynamic actualRecipe = JsonConvert.DeserializeObject<dynamic>(json);

            int tempCbIndex = comboBoxItemName.SelectedIndex;
            // add item to the weaponList
            Weapon weapon = new Weapon(actualRecipe.Recipe.Item.Id.ToString(), actualRecipe.Recipe.Item.Name);
            weaponList.weapons.Add(weapon);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = weaponList.weapons;
            comboBoxItemName.DataSource = bindingSource;
            comboBoxItemName.DisplayMember = "Name";
            comboBoxItemName.ValueMember = "Id";
            comboBoxItemName.SelectedIndex = tempCbIndex ;
            if (cbSaveSearchedItem.Checked)
            {
                //weaponList = JsonConvert.DeserializeObject<WeaponList>(wljson);
                string js = JsonConvert.SerializeObject(weaponList);
                SaveWeaponListJsonToFile(js);
            }

            // test json to class : ok
            CrossoutDb test = CrossoutDb.FromJson(json);



            // download the png of the item
            Image icon = await SendWebRequestForPng(ImageUrlPrefix + id + ".png");




            // Add multiple new lines to the TreeListView

/*        private void PopulateTreeView(FullRecipeClasse crossoutDb)
        {
            // Create a new TreeNode object for the CrossoutDb object
            TreeNode crossoutDbNode = new TreeNode(crossoutDb.Recipe.Item.Name);
            crossoutDbNode.Tag = crossoutDb;

            treeListViewItemRecipe.AddObject(test.Recipe.Item);
            treeListViewItemRecipe.AddObject(test.Recipe.Ingredients[0].Item);

            // Add the image to the ImageList of the TreeListView
            //treeListViewItemRecipe.ImageList.Images.Add(icon);
            // Set the ImageIndex property of the TreeListView node
            //treeListViewItemRecipe.Nodes[0].ImageIndex = treeListViewItemRecipe.ImageList.Images.Count - 1;


        }

            // Add the CrossoutDb node to the TreeView
            treeViewRecipe.Nodes.Add(crossoutDbNode);
        }*/


        //---------- fonction de selection de la combobox ----------//
        private void comboBoxItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxItemName.SelectedItem != null)
            {
                // Get the selected Weapon object
                Weapon selectedWeapon = (Weapon)comboBoxItemName.SelectedItem;

                // Use the selectedWeapon object
                textBoxItemID.Text = selectedWeapon.Id;
            }
            else
            {
                MessageBox.Show("No weapon selected.");
            }

        }



        //__________//                                                  //__________//
        //__________//         FCT INTERNES                             //__________//
        //__________//                                                  //__________//

        //---------- fonction remplissage de crossoutDb recursive ---------//
        private async Task<CrossoutDb> PopulateFullRecipeClass(CrossoutDb crossoutDb)
        {
            foreach (Recipe recipe in crossoutDb.Recipe.Ingredients)
            {
                count++;
                lblProgress.Text = $"Items trouvés : {count}";
                // Download icon of item and store it in imageList
                if (!imageList.Images.ContainsKey(recipe.Item.Id.ToString()))
                {
                    Image tempImage = await SendWebRequestForPng(ImageUrlPrefix + recipe.Item.Id + ".png");
                    imageList.Images.Add(recipe.Item.Id.ToString(), tempImage);
                }
                // if item of recipe has sub child explore and store them
                if (recipe.Item.CraftingResultAmount >= 1 )//&& recipe.Ingredients != null)
                {
                    string js = await SendWebRequestForJson(apiUrlPrefix + recipe.Item.Id.ToString());
                    CrossoutDb tempDb = CrossoutDb.FromJson(js);
                    // assigner les nouveau item de tempDb dans crossoutDb
                    recipe.Item = tempDb.Recipe.Item;
                    recipe.Ingredients = tempDb.Recipe.Ingredients;

                    // Recursively populate sub-recipes
                    tempDb = await PopulateFullRecipeClass(tempDb);

                }

            }
            return crossoutDb;
        }


        //---------- fonction remplissage de treeNode recursive ----------//
        void AddChildNodes(Node parentNode, Recipe value)
        {
            foreach (Recipe recipe in value.Ingredients)
            {
                var node = new Node(recipe);
                //node.Tag = recipe;
                parentNode.Children.Add(node);
                if (value != null)
                {
                    var childValue = recipe;
                    if (childValue != null)
                    {
                        AddChildNodes(node, childValue);
                    }
                }
            }
        }

        //---------- fonction de récupération de json sur api Cdb ----------//

        private async Task<string> SendWebRequestForJson(string url)
        {
            using (WebClient client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(new Uri(url));
                return json;
            }

        }

        private async Task<Image> SendWebRequestForPng(string url)
        {
            // Create a new WebClient object
            using (WebClient client = new WebClient())
            {
                // Download the image from the URL as a byte array
                byte[] imageData;
                try
                {
                    imageData = client.DownloadData(url);
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Error downloading image from {0}: {1}", url, ex.Message);
                    return null;
                }

                // Create a new MemoryStream object from the byte array
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    // Create a new Image object from the MemoryStream
                    Image image = Image.FromStream(ms);

                    return image;

                }
            }


            //// Add the image to the ImageList of the TreeListView
            //treeListView1.ImageList.Images.Add(image);
            //// Set the ImageIndex property of the TreeListView node
            //treeListView1.Nodes[0].ImageIndex = treeListView1.ImageList.Images.Count - 1;

            //using (WebClient client = new WebClient())
            //{
            //    byte[] iconData = client.DownloadData(url);
            //    Image iconImage = Image.FromStream(new MemoryStream(iconData));
            //    //string json = await client.DownloadStringTaskAsync(new Uri(url));
            //    return iconImage;
            //}

        }

        private void FeedTreeView( dynamic recipe)
        {
            // remplissage de la treeview
            TreeNode rootNode = new TreeNode("");
            rootNode.Text = recipe.recipe.item.name;
            treeViewRecipe.Nodes.Add(rootNode);

            foreach (var Item in recipe.recipe.ingredients)
            {
                TreeNode childNode = new TreeNode("");
                int quantity;
                if (Item.item.amount != 0)
                {
                    quantity = Item.number / Item.item.amount;
                }
                else
                {
                    quantity = Item.number;
                }

                childNode.Text = Item.item.name;

                //childNode.Text = String.Format("{0} \t\t\t {1} \t\t\t {2}", Item.item.name + " ", " Quantité : " + quantity , " buy price : " + Item.formatBuyPriceTimesNumber);
                //string column1 = Item.item.name + "".PadRight(30);
                //string column2 = "Quantité : " + quantity +"".PadRight(30);
                //string column3 = "Buy price : " + Item.formatBuyPriceTimesNumber + "".PadRight(30);
                //childNode.Text = column1 + column2 + column3;


                rootNode.Nodes.Add(childNode);

            }
        }

        //---------- fonction de test sur les classes ----------//

        public void ChangeNameByValue(Person person)

        {

            person.Name = "Alice";

        }


        public void ChangeNameByReference(ref Person person)

        {

            person.Name = "Alice";

        }



        //---------- fonction de sauvegarde de weaponList en json ----------//

        public void SaveWeaponListJsonToFile(string js)
        {
            //string filePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "weaponlist.json");
            //System.IO.File.WriteAllText(filePath, js);

            string directoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = System.IO.Path.Combine(directoryPath, "data", "weaponlist.json");
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(filePath)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePath));
            }

            System.IO.File.WriteAllText(filePath, js);
            //System.IO.File.WriteAllText(@"C:\path.json", json);
        }

        public string LoadWeaponListFromJsonFile()
        {
            string js = File.ReadAllText("data/weaponlist.json");


            return js;
        }










        //public Recipe ParseClassRecipe ( string js )
        //{
        //    Recipe rec;
        //    dynamic data = JsonConvert.DeserializeObject<dynamic>(js);
        //    rec.sumBuy = data.recipe.sumBuy;
        //    rec.sumSell = data.recipe.sumSell;
        //    rec.item.id = data.recipe.id;
        //    rec.item.name = data.recipe.item.name;


        //    return rec;

        //}

        //private string jsonToString (string)
        //{
        //    //using (StringReader sr = new StringReader(json)) ;

        //    //using (JsonTextReader reader = new JsonTextReader(sr)) ;
        //    JsonTextReader reader = new JsonTextReader(new StringReader(i.JSON));
        //    while (reader.Read())
        //    {
        //        if (reader.Value != null)
        //        {
        //            //Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
        //            listBoxItemRecipe.Items.Add(reader.TokenType);
        //            listBoxItemRecipe.Items.Add(reader.Value);

        //        }
        //        else
        //        {
        //            //Console.WriteLine("Token: {0}", reader.TokenType);
        //            //listBoxItemRecipe.Items.Add(reader.TokenType);
        //        }
        //    }
        //}

        private void buttonOptRoute_Click(object sender, EventArgs e)
        {
            // Scan what's displayed in treeListView 
            foreach (Node node in treeListViewItemRecipe.Roots)
            {
                ExpandNode(node);
            }


        }
    }
}
