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
            await PopulateTreeView(treeViewRecipe, actualRecipe.Recipe);



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

                try

                {

                    string json = await client.DownloadStringTaskAsync(new Uri(url));

                    return json;

                }

                catch (WebException ex)

                {

                    // Handle the error here. For example, you can return an empty string or log the error.

                    Console.WriteLine("Error downloading JSON from {0}: {1}", url, ex.Message);

                    return "";

                }

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


        //void PopulateTreeView(TreeView treeViewRecipe, Recipe recipe)
        //{
        //    TreeNode treeNode = new TreeNode(recipe.Item.Name);
        //    treeViewRecipe.Nodes.Add(treeNode);
        //    recipeDictionary.Add(recipe.Item.Name, recipe);

        //    foreach (Recipe ingredient in recipe.Ingredients)
        //    {
        //        TreeNode childNode = new TreeNode(ingredient.Item.Name);
        //        treeNode.Nodes.Add(childNode);
        //        recipeDictionary.Add(ingredient.Item.Name, ingredient);

        //        //string js = await SendWebRequestForJson(apiUrlPrefix + ingredient.Id);

        //        //// test json to class : ok
        //        //CrossoutDb tempRecipe = CrossoutDb.FromJson(js);

        //        ////PopulateTreeView(treeViewRecipe, actualRecipe.Recipe);
        //        //PopulateTreeView(childNode, tempRecipe.Recipe);
        //    }
        //}

        //void PopulateTreeView(TreeView treeViewRecipe, Recipe recipe)
        //{
        //    TreeNode treeNode = new TreeNode(recipe.Item.Name);
        //    treeViewRecipe.Nodes.Add(treeNode);
        //    recipeDictionary.Add(recipe.Item.Name, recipe);
        //    foreach (Recipe ingredient in recipe.Ingredients)
        //    {
        //        //PopulateTreeViewRecursive(treeNode, ingredient);
        //        PopulateTreeViewRecursive(treeViewRecipe.Nodes[0], ingredient);
        //    }
        //}
        //private async Task PopulateTreeView(TreeView treeViewRecipe, Recipe recipe)

        //{

        //    TreeNode treeNode = new TreeNode(recipe.Item.Name);

        //    treeViewRecipe.Nodes.Add(treeNode);

        //    recipeDictionary.Add(recipe.Item.Name, recipe);


        //    foreach (Recipe ingredient in recipe.Ingredients)

        //    {
        //        MessageBox.Show(ingredient.Id.ToString(), "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        PopulateTreeViewRecursive(treeNode, ingredient);

        //    }

        //}
        private async Task PopulateTreeView(TreeView treeViewRecipe, Recipe recipe)

        {

            TreeNode treeNode = new TreeNode(recipe.Item.Name);

            treeViewRecipe.Nodes.Add(treeNode);

            recipeDictionary.Add(recipe.Item.Name, recipe);


            foreach (Recipe ingredient in recipe.Ingredients)

            {

                await PopulateTreeViewRecursive(treeNode, ingredient);

            }

        }


        //void PopulateTreeViewRecursive(TreeNode parentNode, Recipe recipe)
        //{
        //    TreeNode childNode = new TreeNode(recipe.Item.Name);
        //    parentNode.Nodes.Add(childNode);
        //    recipeDictionary.Add(recipe.Item.Name, recipe);
        //    foreach (Recipe ingredient in recipe.Ingredients)
        //    {
        //        PopulateTreeViewRecursive(childNode, ingredient);
        //    }
        //}

        //private async Task PopulateTreeViewRecursive(TreeNode parentNode, Recipe recipe)

        //{

        //    TreeNode treeNode = new TreeNode(recipe.Item.Name);

        //    parentNode.Nodes.Add(treeNode);

        //    recipeDictionary.Add(recipe.Item.Name, recipe);


        //    foreach (Recipe ingredient in recipe.Ingredients)

        //    {

        //        string json = await SendWebRequestForJson(apiUrlPrefix + ingredient.Id);
        //        MessageBox.Show(ingredient.Id.ToString(), "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        CrossoutDb tempRecipe = CrossoutDb.FromJson(json);

        //        await PopulateTreeViewRecursive(treeNode, tempRecipe.Recipe);

        //    }

        //}

        private async Task PopulateTreeViewRecursive(TreeNode parentNode, Recipe recipe)
        {
            string json = await SendWebRequestForJson(apiUrlPrefix + recipe.Id);
            CrossoutDb tempRecipe = CrossoutDb.FromJson(json);

            if (tempRecipe != null && tempRecipe.Recipe != null && tempRecipe.Recipe.Item != null)
            {
                TreeNode treeNode = new TreeNode(tempRecipe.Recipe.Item.Name);
                parentNode.Nodes.Add(treeNode);
                recipeDictionary.Add(tempRecipe.Recipe.Id.ToString(), tempRecipe.Recipe);

                foreach (Recipe ingredient in tempRecipe.Recipe.Ingredients)
                {
                    await PopulateTreeViewRecursive(treeNode, ingredient);
                }

                // Add sub-children (i.e., ingredients of ingredients) to the tree view
                foreach (Recipe subIngredient in tempRecipe.Recipe.Ingredients)
                {
                    if (subIngredient != null && subIngredient.Item != null)
                    {
                        TreeNode subTreeNode = new TreeNode(subIngredient.Item.Name);
                        parentNode.Nodes.Add(subTreeNode); // Add sub-ingredient to the parent node

                        // Add sub-ingredient to the recipeDictionary with a unique key
                        recipeDictionary.Add(subIngredient.Id.ToString(), subIngredient);

                        // Recursively add sub-ingredients to the subTreeNode
                        await PopulateTreeViewRecursive(subTreeNode, subIngredient);
                    }
                }

                // Print out the keys and values of the recipeDictionary
                Console.WriteLine("Recipe dictionary after populating tree view:");
                foreach (KeyValuePair<string, Recipe> entry in recipeDictionary)
                {
                    Console.WriteLine("Key: {0}, Value: {1}", entry.Key, entry.Value);
                }
            }
            else
            {
                // Handle the null reference exception here. For example, you can log the error or display a message.
                Console.WriteLine("Error: tempRecipe or tempRecipe.Recipe or tempRecipe.Recipe.Item is null");
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

            // Print out the keys and values of the recipeDictionary

            Console.WriteLine("Recipe dictionary when expanding tree view node:");

            foreach (KeyValuePair<string, Recipe> entry in recipeDictionary)

            {

                Console.WriteLine("Key: {0}, Value: {1}", entry.Key, entry.Value);

            }


            // Implement your logic to get the Recipe instance from the TreeNode

            // For example, you can use the Text property of the TreeNode to look up the corresponding Recipe instance in the recipeDictionary

            string key = treeNode.Text;

            if (recipeDictionary.TryGetValue(key, out Recipe recipe))

            {

                return recipe;
            }

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
