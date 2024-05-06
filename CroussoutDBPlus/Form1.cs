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
using System.Reflection;
using System.Xml.Linq;

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

        long lvl = 0;

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

            
            /*
            treeViewRecipe.AfterExpand += treeViewRecipe_AfterExpand;

            treeViewRecipe.AfterCollapse += treeViewRecipe_AfterCollapse;
            */
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
            FullRecipeClasse crossoutDb = FullRecipeClasse.FromJson(json);

            crossoutDb = await PopulateFullRecipeClasse(crossoutDb);




            var nodes = new List<TreeNode>();

            // Add a root node for the CrossoutDb object
            var crossoutDbNode = new TreeNode(crossoutDb.Recipe.Item.Name);
            

            //crossoutDb.Recipe.Item.Name;

            // Add child nodes for the properties of the CrossoutDb object
            foreach (Recipe recipe in crossoutDb.Recipe.Ingredients)
            {
                var node = new TreeNode(recipe.Item.Name);
                crossoutDbNode.Nodes.Add(node);
                if (recipe.Ingredients != null)
                {
                    Recipe value = recipe;
                    if (value != null)
                    {
                        AddChildNodes(node, value);
                    }
                }
            }

            nodes.Add(crossoutDbNode);
            // put node into treeViewRecipe
            treeViewRecipe.Nodes.AddRange(nodes.ToArray());

            // download the png of the item
            //Image icon = await SendWebRequestForPng(ImageUrlPrefix + id + ".png");

            /*

            TreeNode parentNode = new TreeNode("Parent");

            TreeNode childNode1 = new TreeNode("Child 1");
            parentNode.Nodes.Add(childNode1);

            TreeNode childNode2 = new TreeNode("Child 2");
            parentNode.Nodes.Add(childNode2);

            TreeNode subChildNode1 = new TreeNode("Sub-Child 1");
            childNode1.Nodes.Add(subChildNode1);

            TreeNode subChildNode2 = new TreeNode("Sub-Child 2");
            childNode1.Nodes.Add(subChildNode2);

            treeViewRecipe.Nodes.Add(parentNode);

            */

        }

        private async Task<FullRecipeClasse> PopulateFullRecipeClasse(FullRecipeClasse crossoutDb)
        {
            foreach (Recipe recipe in crossoutDb.Recipe.Ingredients)
            {
                string js = await SendWebRequestForJson(apiUrlPrefix + recipe.Item.Id);
                FullRecipeClasse tempDb = FullRecipeClasse.FromJson(js);

                //Console.WriteLine("####################################");
                //Console.WriteLine("lvl : " + lvl);
                //Console.WriteLine("tempDb.Recipe.Item.Id : " + tempDb.Recipe.Item.Id);
                //Console.WriteLine("tempDb.Recipe.Item.Id : " + tempDb.Recipe.Item.Name);
                //Console.WriteLine("tempDb.Recipe.Item.Id : " + tempDb.Recipe.Item.RarityName);
                //Console.WriteLine("tempDb.Recipe.Item.Craftable : " + tempDb.Recipe.Item.Craftable);
                if (tempDb.Recipe.Item.Craftable == 1 && tempDb.Recipe.Ingredients != null)
                {
                    
                    //Console.WriteLine("_______________________ beguining of recursive jump__________________________________________");
                    //Console.WriteLine("lvl : " + lvl);
                    //Console.WriteLine("success " + tempDb.Recipe.Item.Name);
                    //Console.WriteLine("success " + tempDb.Recipe.Item.RarityName);

                    // assigner les nouveau item de tempDb dans crossoutDb
                    recipe.Item = tempDb.Recipe.Item;
                    recipe.Ingredients = tempDb.Recipe.Ingredients;

                    // Recursively populate sub-recipes
                    //recipe.Ingredients = await PopulateFullRecipeClasse(recipe.Ingredients);
                    //Console.WriteLine("number of element in recipe.Ingredients.Count : " + recipe.Ingredients.Count);
                    int nb = recipe.Ingredients.Count;
                    for (int i = 0; i < nb; i++)
                    {
                        //Console.WriteLine("element " + i + " recipe.Ingredients[i].Item.Name : " + recipe.Ingredients[i].Item.Name);
                    }
                    lvl += 1;
                    tempDb = await PopulateFullRecipeClasse(tempDb); // <------ todo !
                    lvl -= 1;
                }
            }
            return crossoutDb;
        }

        //---------- fonction remplissage de treeNode recursive ----------//
        void AddChildNodes(TreeNode parentNode, Recipe value)
        {
            foreach (Recipe recipe in value.Ingredients)
            {
                var node = new TreeNode(recipe.Item.Name);
                parentNode.Nodes.Add(node);
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
                    Console.WriteLine("Error downloading JSON from {0}: {1}", url, ex.Message);
                    //throw new ApiException("Failed to download JSON from API", ex);
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

            Recipe recipe = GetRecipeFromTreeNode(e.Node);//---------- fonction de selection de la combobox ----------//

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

            string key = treeNode.Text;
            if (recipeDictionary.TryGetValue(key, out Recipe recipe))
            {
                return recipe;
            }

            return null;
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

    }
}
