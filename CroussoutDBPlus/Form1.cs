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
using System.Drawing.Drawing2D;
using System.Windows.Data;

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

            // test json to class : ok
            FullRecipeClasse crossoutDb = FullRecipeClasse.FromJson(json);

            crossoutDb = await PopulateFullRecipeClasse(crossoutDb);




            var nodes = new List<TreeNode>();

            // Add a root node for the CrossoutDb object
            var crossoutDbNode = new TreeNode(crossoutDb.Recipe.Item.Name);



            //PopulateTreeView(crossoutDb);


            // Add child nodes for the properties of the CrossoutDb object
            foreach (Recipe recipe in crossoutDb.Recipe.Ingredients)
            {
                var node = new TreeNode(recipe.Item.Name);
                node.Tag = recipe;
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

            crossoutDbNode.Tag = crossoutDb;



            nodes.Add(crossoutDbNode);
            // put node into treeViewRecipe
            treeViewRecipe.Nodes.AddRange(nodes.ToArray());


            listViewRecipe.Items.Clear();

            ///*            foreach (Recipe recipe in crossoutDb.Recipe.Ingredients)
            //            {
            //                ListViewItem item = new ListViewItem(recipe.Item.Name);
            //                item.SubItems.Add(recipe.Item.Craftable.ToString());
            //                item.SubItems.Add(recipe.Item.Id.ToString());
            //                listViewRecipe.Items.Add(item);
            //            }*/


            // download the png of the item
            //Image icon = await SendWebRequestForPng(ImageUrlPrefix + id + ".png");


        }

        private async Task<FullRecipeClasse> PopulateFullRecipeClasse(FullRecipeClasse crossoutDb)
        {
            foreach (Recipe recipe in crossoutDb.Recipe.Ingredients)
            {
                string js = await SendWebRequestForJson(apiUrlPrefix + recipe.Item.Id);
                FullRecipeClasse tempDb = FullRecipeClasse.FromJson(js);
                if (tempDb.Recipe.Item.Craftable == 1 && tempDb.Recipe.Ingredients != null)
                {
                    // assigner les nouveau item de tempDb dans crossoutDb
                    recipe.Item = tempDb.Recipe.Item;
                    recipe.Ingredients = tempDb.Recipe.Ingredients;

                    // Recursively populate sub-recipes
                    tempDb = await PopulateFullRecipeClasse(tempDb); // <------ todo !
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
                node.Tag = recipe;
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

/*        private void PopulateTreeView(FullRecipeClasse crossoutDb)
        {
            // Create a new TreeNode object for the CrossoutDb object
            TreeNode crossoutDbNode = new TreeNode(crossoutDb.Recipe.Item.Name);
            crossoutDbNode.Tag = crossoutDb;

            // Add child nodes for the properties of the CrossoutDb object
            foreach (Recipe recipe in crossoutDb.Recipe.Ingredients)
            {
                TreeNode node = new TreeNode(recipe.Item.Name);
                node.Tag = recipe;
                crossoutDbNode.Nodes.Add(node);

                if (recipe.Ingredients != null)
                {
                    PopulateTreeView(recipe);
                }
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






        //__________//                                                  //__________//
        //__________//         ESSAIS LISTVIEW                          //__________//
        //__________//                                                  //__________//
        private void treeViewRecipe_AfterExpand(object sender, TreeViewEventArgs e)
        {
            Console.WriteLine("expand");
            Console.WriteLine(e.Node.Tag);

            // Get the selected node
            TreeNode selectedNode = e.Node;

            // Get the corresponding recipe object
            object recipe = selectedNode.Tag;

            // Populate the listViewRecipe with the ingredients of the recipe

            // Get the type of the recipe object
            Type recipeType = recipe.GetType();

            // Check if the recipe object is of type Recipe
            if (recipeType == typeof(FullRecipeClasse))
            {
                // Cast the recipe object to FullRecipeClasse
                FullRecipeClasse recipeObj = (FullRecipeClasse)recipe;
                Console.WriteLine(recipeObj.Recipe.Item.Name);

                foreach (Recipe ingredient in recipeObj.Recipe.Ingredients)
                {
                    ListViewItem item = new ListViewItem(ingredient.Item.Name);
                    item.SubItems.Add(ingredient.Item.Craftable.ToString());
                    item.SubItems.Add(ingredient.Item.Id.ToString());
                    listViewRecipe.Items.Add(item);
                }


            }
            else if (recipeType == typeof(Recipe))
            {
                // Cast the recipe object to Recipe
                Recipe recipeObj = (Recipe)recipe;
                Console.WriteLine(recipeObj.Item.Name);

                foreach (Recipe ingredient in recipeObj.Ingredients)
                {
                    ListViewItem item = new ListViewItem(ingredient.Item.Name);
                    item.SubItems.Add(ingredient.Item.Craftable.ToString());
                    item.SubItems.Add(ingredient.Item.Id.ToString());
                    listViewRecipe.Items.Add(item);
                }

            }


/*            foreach (Recipe ingredient in tempDb.Recipe.Ingredients)
            {
                ListViewItem item = new ListViewItem(ingredient.Item.Name);
                item.SubItems.Add(ingredient.Item.Craftable.ToString());
                item.SubItems.Add(ingredient.Item.Id.ToString());
                listViewRecipe.Items.Add(item);
            }*/
        }

        private void treeViewRecipe_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            Console.WriteLine("collapse");
            // Clear the listViewRecipe when the node is collapsed
            listViewRecipe.Items.Clear();
        }


        private void listViewRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
