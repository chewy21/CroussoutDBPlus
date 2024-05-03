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

        public static string apiUrlPrefix = "https://crossoutdb.com/api/v1/recipe/";
        public static string ImageUrlPrefix = "https://crossoutdb.com/img/items/";

        //test sur sauvegarde de la liste d'armes
        //public weaponList = new WeaponList();

        Dictionary<string, Recipe> recipeDictionary = new Dictionary<string, Recipe>();


        // init de la classe weaponlist
        string wljson = "";
        WeaponList weaponList = new WeaponList
        {
            weapons = new List<Weapon>()
        };



        //----------  ----------//

        //MessageBox.Show(Item.item.name.ToString(), "info" , MessageBoxButtons.OK, MessageBoxIcon.Information);

        //---------- fonction d'init de l'interface graphique ----------//

        public Form1()
        {
            InitializeComponent();
            // In your form's constructor or Load event handler, wire up the event handlers.


            
            // initialize the TreeView and ListBox

            

            treeViewRecipe.AfterExpand += treeViewRecipe_AfterExpand;

            treeViewRecipe.AfterCollapse += treeViewRecipe_AfterCollapse;
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
            //dynamic actualRecipe = JsonConvert.DeserializeObject<dynamic>(json);

            // test json to class : ok
            CrossoutDb actualRecipe = CrossoutDb.FromJson(json);

            // remplissage de la treeview
            //FeedTreeView(actualRecipe);
            //FeedTreeViewAndListBox(actualRecipe);

            // download the png of the item
            Image icon = await SendWebRequestForPng(ImageUrlPrefix + id + ".png");

            // Add multiple new lines to the TreeView
            PopulateTreeView(treeViewRecipe, actualRecipe.Recipe);


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



        }

        //private void FeedTreeView( dynamic recipe)
        //{
        //    // remplissage de la treeview
        //    TreeNode rootNode = new TreeNode("");
        //    rootNode.Text = recipe.recipe.item.name;
        //    treeViewRecipe.Nodes.Add(rootNode);

        //    foreach (var Item in recipe.recipe.ingredients)
        //    {
        //        TreeNode childNode = new TreeNode("");
        //        int quantity;
        //        if (Item.item.amount != 0)
        //        {
        //            quantity = Item.number / Item.item.amount;
        //        }
        //        else
        //        {
        //            quantity = Item.number;
        //        }

        //        childNode.Text = Item.item.name;

        //        //childNode.Text = String.Format("{0} \t\t\t {1} \t\t\t {2}", Item.item.name + " ", " Quantité : " + quantity , " buy price : " + Item.formatBuyPriceTimesNumber);
        //        //string column1 = Item.item.name + "".PadRight(30);
        //        //string column2 = "Quantité : " + quantity +"".PadRight(30);
        //        //string column3 = "Buy price : " + Item.formatBuyPriceTimesNumber + "".PadRight(30);
        //        //childNode.Text = column1 + column2 + column3;


        //        rootNode.Nodes.Add(childNode);

        //    }
        //}




        void PopulateTreeView(TreeView treeViewRecipe, Recipe recipe)
        {
            TreeNode treeNode = new TreeNode(recipe.Item.Name);
            treeViewRecipe.Nodes.Add(treeNode);
            recipeDictionary.Add(recipe.Item.Name, recipe);

            foreach (Recipe ingredient in recipe.Ingredients)
            {
                TreeNode childNode = new TreeNode(ingredient.Item.Name);
                treeNode.Nodes.Add(childNode);
                recipeDictionary.Add(ingredient.Item.Name, ingredient);

                //string js = await SendWebRequestForJson(apiUrlPrefix + ingredient.Id);

                //// test json to class : ok
                //CrossoutDb tempRecipe = CrossoutDb.FromJson(js);

                ////PopulateTreeView(treeViewRecipe, actualRecipe.Recipe);
                //PopulateTreeView(childNode, tempRecipe.Recipe);
            }
        }


        // populate the ListBox

        void PopulateListBox(ListBox listBoxRecipe, Recipe recipe)

        {
            listBoxRecipe.Items.Clear();
            foreach (Recipe ingredient in recipe.Ingredients)
            {
                listBoxRecipe.Items.Add(new ListViewItem(new[] { ingredient.Item.Name, ingredient.Item.FormatBuyPrice, ingredient.Item.FormatCraftingSellSum }));
            }
        }


        // handle TreeView node expansion and collapse

        void treeViewRecipe_AfterExpand(object sender, TreeViewEventArgs e)

        {

            Recipe recipe = GetRecipeFromTreeNode(e.Node);

            PopulateListBox(listBoxRecipe, recipe);

        }


        void treeViewRecipe_AfterCollapse(object sender, TreeViewEventArgs e)

        {

            listBoxRecipe.Items.Clear();

        }


        // helper method to get the Recipe instance from a TreeNode

        Recipe GetRecipeFromTreeNode(TreeNode treeNode)

        {

            // implement your logic to get the Recipe instance from the TreeNode

            // for example, you can use a Dictionary to store the Recipe instances

            // and retrieve them by the TreeNode's Text property

            //Dictionary<string, Recipe> recipeDictionary = new Dictionary<string, Recipe>(); // got pushed into a global dictionary at beguining of code

            //...

            return recipeDictionary[treeNode.Text];

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

        public void SaveWeaponListJsonToFile (string js)
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

        //---------- fonction de syncro TreeviewRecipe et ListView ----------//



        //public class TreeItem
        //{
        //    public string Text { get; set; }
        //    public List<TreeItem> Children { get; set; }
        //    public TreeItem(string text)
        //    {
        //        Text = text;
        //        Children = new List<TreeItem>();
        //    }
        //}
    }
}
