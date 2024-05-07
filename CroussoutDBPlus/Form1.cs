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

        private List<Node> listOfItem;

        int count = 0;

        //MessageBox.Show(Item.item.name.ToString(), "info" , MessageBoxButtons.OK, MessageBoxIcon.Information);

        //---------- fonction d'init de l'interface graphique ----------//

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // preset du punisher pour tests
            textBoxItemID.Text = "909";

            // chargement de weaponlist.json dans la classe weaponlist
            wljson = LoadWeaponListFromJson();
            WeaponList weaponList = JsonConvert.DeserializeObject<WeaponList>(wljson);

            // synchronisation de la classe weaponlist avec la combobox de selection d'arme
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = weaponList.weapons;
            comboBoxItemName.DataSource = bindingSource;
            comboBoxItemName.DisplayMember = "Name";
            comboBoxItemName.ValueMember = "Id";


            // creation des colones pour TLV 

            // set the delegate that the tree uses to know if a node is expandable
            treeListViewItemRecipe.CanExpandGetter = x => (x as Node).Children.Count > 0;
            // set the delegate that the tree uses to know the children of a node
            treeListViewItemRecipe.ChildrenGetter = x => (x as Node).Children;



            // set columns of treelistview
            treeListViewItemRecipe.Columns.Add(new OLVColumn("Nom", "Name"));
            treeListViewItemRecipe.Columns.Add(new OLVColumn("Identificateur", "Id"));
            treeListViewItemRecipe.Columns.Add(new OLVColumn("Icone", "imageIndex"));
            //treeListViewItemRecipe.Row
            treeListViewItemRecipe.Columns.Add(new OLVColumn("Buy Price", "formatBuyPrice"));
            treeListViewItemRecipe.Columns.Add(new OLVColumn("Crafting Buy Sum", "formatCraftingBuySum"));
            treeListViewItemRecipe.AutoResizeColumns();
             //treeListViewItemRecipe.Columns[0];
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
            // chargement du json dans actualRecipe
            CrossoutDb actualRecipe = CrossoutDb.FromJson(json);
            // remplissage de actual recipe complète
            actualRecipe = await PopulateFullRecipeClass(actualRecipe);

            // download the png of the item
            Image icon = await SendWebRequestForPng(ImageUrlPrefix + id + ".png");

            // create fake nodes

            ImageList imageList = new ImageList();
            imageList.Images.Add("909",Image.FromFile("data/909.png"));
            imageList.Images.Add("168",Image.FromFile("data/168.png"));
            string imageIndex = "909";

            treeListViewItemRecipe.SmallImageList = imageList;
            //treeListViewItemRecipe.Columns[1].ImageIndex = 0;
            //treeListViewItemRecipe.SmallImageList.

            var parent1 = new Node(actualRecipe.Recipe.Item.Id, imageIndex, actualRecipe.Recipe.Item.Name, actualRecipe.Recipe.Item.FormatBuyPrice, actualRecipe.Recipe.Item.FormatCraftingBuySum) ;

            foreach (var recipe in actualRecipe.Recipe.Ingredients)
            {
                var node = new Node(recipe.Item.Id, imageIndex, recipe.Item.Name, recipe.FormatBuyPriceTimesNumber, "");
                parent1.Children.Add(node) ; //, Item.formatBuyPrice, Item.FormatCraftingBuySum);
                lblProgress.Text = $"Items added: {count}";
                if(recipe.Ingredients != null)
                {
                    Recipe tempRecipe = recipe;
                    if(tempRecipe != null)
                    {
                        AddChildNodes(node,tempRecipe);
                    }
                }

            }

            // Assign parent1 to listOfItem
            listOfItem = new List<Node> { parent1 };
            // Assign listOfItem to treeListView
            treeListViewItemRecipe.Roots = listOfItem;
            // Resize column width auto
            treeListViewItemRecipe.AutoResizeColumns();


            // Add multiple new lines to the TreeListView

            //treeListViewItemRecipe.AddObject(actualRecipe.Recipe.Item);
            //treeListViewItemRecipe.AddObject(actualRecipe.Recipe.Ingredients[0].Item);
            //int testtlv = treeListViewItemRecipe.Items.Count;
            //MessageBox.Show(testtlv.ToString(), "info" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            //treeListViewItemRecipe.Items.Add(testtlv.ToString());
            //treeListViewItemRecipe.VirtualListSize;

            // Add the image to the ImageList of the TreeListView
            //treeListViewItemRecipe.ImageList.Images.Add(icon);
            // Set the ImageIndex property of the TreeListView node
            //treeListViewItemRecipe.Nodes[0].ImageIndex = treeListViewItemRecipe.ImageList.Images.Count - 1;

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

        private void buttonSaveWeaponList_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(weaponList, Formatting.Indented);
            SaveWeaponListJsonToFile(json);
        }

        //__________//                                                  //__________//
        //__________//         FCT INTERNES                             //__________//
        //__________//                                                  //__________//

        //---------- fonction remplissage de crossoutDb recursive ---------//
        private async Task<CrossoutDb> PopulateFullRecipeClass(CrossoutDb crossoutDb)
        {
            foreach (Recipe recipe in crossoutDb.Recipe.Ingredients)
            {


                lblProgress.Text = $"Items added: {count}";
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
                count++;
                lblProgress.Text = $"Items added: {count}";
            }
            return crossoutDb;
        }


        //---------- fonction remplissage de treeNode recursive ----------//
        void AddChildNodes(Node parentNode, Recipe value)
        {
            foreach (Recipe recipe in value.Ingredients)
            {

                var node = new Node(recipe.Item.Id, "2", recipe.Item.Name, recipe.FormatBuyPriceTimesNumber, "");
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
                byte[] imageData = client.DownloadData(url);
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

        public string LoadWeaponListFromJson()
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

    }
}
