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


        private List<Node> listOfItem;

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


            //factionList = new ImageList();
            //for (int i = 1; i<=10; i++)
            //{
            //    string tempString = i.ToString();
            //    factionList.Images.Add(tempString, Image.FromFile("data/" + i.ToString() + ".png"));
            //}
            


            // set the delegate that the tree uses to know if a node is expandable
            treeListViewItemRecipe.CanExpandGetter = x => (x as Node).Children.Count > 0;
            // set the delegate that the tree uses to know the children of a node
            treeListViewItemRecipe.ChildrenGetter = x => (x as Node).Children;





            // creation des colones pour TLV
            BrightIdeasSoftware.OLVColumn NameColumn = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn FactionColumn = new BrightIdeasSoftware.OLVColumn();
            //BrightIdeasSoftware.OLVColumn IdColumn = new BrightIdeasSoftware.OLVColumn();
            //BrightIdeasSoftware.OLVColumn ImageIndexColumn = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn QuantityColumn = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn FormatBuyPriceColumn = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn FormatSellPriceColumn = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn FormatCraftingBuySumColumn = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn FormatCraftingSellSumColumn = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn BuyCraftColumn = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn FormatCraftingMarginColumn = new BrightIdeasSoftware.OLVColumn();

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

            // Set carriage return in header
            treeListViewItemRecipe.HeaderWordWrap = true;

            // Custumize Faction column
            FactionColumn.IsHeaderVertical = true;
            FactionColumn.MaximumWidth = 28;

            // customize Buy craft column
            BuyCraftColumn.IsHeaderVertical = false;
            BuyCraftColumn.CheckBoxes = true;

            //ImageIndexColumn.ShowTextInHeader = false;

            treeListViewItemRecipe.Columns.Add(NameColumn);
            treeListViewItemRecipe.Columns.Add(FactionColumn);
            //treeListViewItemRecipe.Columns.Add(IdColumn);
            //treeListViewItemRecipe.Columns.Add(ImageIndexColumn);
            treeListViewItemRecipe.Columns.Add(QuantityColumn);
            treeListViewItemRecipe.Columns.Add(FormatBuyPriceColumn);
            treeListViewItemRecipe.Columns.Add(FormatSellPriceColumn);
            treeListViewItemRecipe.Columns.Add(FormatCraftingBuySumColumn);
            treeListViewItemRecipe.Columns.Add(FormatCraftingSellSumColumn);
            treeListViewItemRecipe.Columns.Add(BuyCraftColumn);
            treeListViewItemRecipe.Columns.Add(FormatCraftingMarginColumn);

            //Size size = new Size(48, 48);
            //treeListViewItemRecipe.SmallImageList.ImageSize = size; // <-- fait bugger le bordel (1x icone en 16x16 deux fois plus d'icones 3ieme fois icones en 32x32 ?!)


            treeListViewItemRecipe.AutoResizeColumns();

            NameColumn.ImageGetter = delegate (object rowObject) 
            {
                Node node = (Node)rowObject;
                
                // decide depending on the rowObject which image to return
                return node.Id.ToString();
            };

            //FactionColumn.ImageGetter = delegate (object rowObject)
            //{
            //    Node node = (Node)rowObject;
            //    //Console.WriteLine(node.FactionNumber);
            //    return node.FactionNumber;
            //};

            //ImageDecoration faction = new ImageDecoration();
            //faction.Image = Image.FromFile("data/1.png");

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
            // reset loading count
            count = 0;
            lblProgress.Visible = true;
            // chargement du json dans actualRecipe
            CrossoutDb actualRecipe = CrossoutDb.FromJson(json);

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

            // Cleaning of imageList to be ready for new icones of item in node
            imageList.Images.Clear();
            treeListViewItemRecipe.SmallImageList = imageList;

            /*            for (int i = 1; i <= 10; i++)
                        {
                            string tempString = i.ToString();
                            imageList.Images.Add(tempString, Image.FromFile("data/" + i.ToString() + ".png"));
                        }*/


            Size size = new Size(32, 32);
            treeListViewItemRecipe.SmallImageList.ImageSize = size; // <-- fait bugger le bordel (1x icone en 16x16 deux fois plus d'icones 3ieme fois icones en 32x32 ?!)

            // Dl and feed to imageList the first item of recipe
            Image tempImage = await SendWebRequestForPng(ImageUrlPrefix + actualRecipe.Recipe.Item.Id + ".png");
            Image itemImage = new Bitmap(tempImage, new Size(28, 28));
            imageList.Images.Add(actualRecipe.Recipe.Item.Id.ToString(), itemImage);
            //Set png of item to background
            treeListViewItemRecipe.OverlayImage.Image = tempImage;
            
            //treeListViewItemRecipe.OverlayImage.ReferenceCorner = ContentAlignment.BottomRight;

            // remplissage de actual recipe complète
            actualRecipe = await PopulateFullRecipeClass(actualRecipe);



            // Assign imageList to treeListView for icon display on first column

            //Size size = new Size(48, 48);
            //treeListViewItemRecipe.SmallImageList.ImageSize = size; // <-- fait bugger le bordel (1x icone en 16x16 deux fois plus d'icones 3ieme fois icones en 32x32 ?!)
            //treeListViewItemRecipe.SmallImageList = imageList;

            //treeListViewItemRecipe.LargeImageList = imageList;  

            // 
            Node parent1 = new Node(actualRecipe.Recipe);
            //
            AddChildNodes(parent1,actualRecipe.Recipe);

            // Assign parent1 to listOfItem
            listOfItem = new List<Node> { parent1 };

            //Generator.GenerateColumns(treeListViewItemRecipe, typeof(Node),true); // Auto columns generator / work but doesn't give columns propername so they are able to be called form code
            
            // Assign listOfItem to treeListView
            treeListViewItemRecipe.Roots = listOfItem;

            // Expand first node of TreeviewList whenever it worth being crafted or not
            treeListViewItemRecipe.Expand(parent1);



            //
            treeListViewItemRecipe.RefreshOverlays();

            //treeListViewItemRecipe.Refresh();

        }

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

        //---------- fonction de récupération d'icone d'item sur cdb ----------//

        private async Task<Image> SendWebRequestForPng(string url)
        {
            // Create a new WebClient object
            using (WebClient client = new WebClient())
            {
                // Download the image from the URL as a byte array
                byte[] imageData = client.DownloadData(url);
                // Create a new MemoryStream object from the byte array
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    // Create a new Image object from the MemoryStream
                    Image image = Image.FromStream(ms);

                    return image;

                }
            }

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

        private void TreeListViewItemRecipe_Expand(object sender, TreeBranchExpandedEventArgs e)
        {
            // This event is triggered after a node has been expanded

            // You can add your custom logic here
            treeListViewItemRecipe.AutoResizeColumns();
            //Console.WriteLine($"Node '{e.Item.Name}' expanded.");
        }

        private void treeListViewRecipe_FormatRow(object sender, FormatRowEventArgs e)
        {
            Node node = (Node)e.Model;
            if (node.BuyCraft)
            {
                e.Item.BackColor = Color.LightGreen;
                e.Item.ToolTipText = "craft it !";
                //treeListViewItemRecipe.Expand(e); // don't work
            }
        }

        private void treeListViewRecipe_FormatCell(object sender, FormatCellEventArgs e)
        {
            Node node = (Node)e.Model;
            if (e.ColumnIndex == 1)
            {

                
                if (node.FactionNumber >= 1 && node.FactionNumber <= 10)
                {
                    Image factionImage = new Bitmap(Image.FromFile("data/" + node.FactionNumber + ".png"), new Size(32, 32));
                    e.SubItem.Decoration = new ImageDecoration(factionImage);
                    //Console.WriteLine("cell true");

                }
            }
/*            if (e.ColumnIndex == 0)  // show item icon as decoration on row -> not that convicing
            {
                if (imageList.Images[node.Id.ToString()] != null && node.FormatCraftingSellSum != "0")
                {
                    //int idIndex = (int)node.Id;
                    Image itemImage = new Bitmap(imageList.Images[node.Id.ToString()], new Size(28, 28));
                    e.SubItem.Decoration = new ImageDecoration(itemImage, 100);
                    //Console.WriteLine("cell true");
                }
            }*/
        }

        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            treeListViewItemRecipe.ExpandAll();
        }

        private void buttonCollapseAll_Click(object sender, EventArgs e)
        {
            treeListViewItemRecipe.CollapseAll();
        }

        private void buttonOptRoute_Click(object sender, EventArgs e)
        {
            // Scan what's displayed in treeListView 
            foreach (Node node in treeListViewItemRecipe.Roots)
            {
                ExpandNode(node);
            }

        }
        private void ExpandNode(Node node)
        {
            if (node.BuyCraft)
            {
                treeListViewItemRecipe.Expand(node);
            }
            foreach (Node childNode in node.Children)
            {
                ExpandNode(childNode);
            }
        }

    }
}
