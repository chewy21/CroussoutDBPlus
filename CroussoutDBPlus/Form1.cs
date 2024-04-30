using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
// librairie ajoutée
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows.Controls;
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

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // preset du punisher pour tests
            textBoxItemID.Text = "909";

            wljson = LoadWeaponListFromJson();
            WeaponList weaponList = JsonConvert.DeserializeObject<WeaponList>(wljson);



            // synchronisation de la classe weaponlist avec la combobox de selection d'arme
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = weaponList.weapons;
            comboBoxItemName.DataSource = bindingSource;
            comboBoxItemName.DisplayMember = "Name";
            comboBoxItemName.ValueMember = "Id";


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

        //__________//                                                  //__________//
        //__________//         FCT INTERFACES                           //__________//
        //__________//                                                  //__________//



        //---------- fonction du bouton update de l'interface graphique ----------//

        private async void buttonItemUpdate_Click(object sender, EventArgs e)
        {
            // recuperation de l'id de l'item
            string id = textBoxItemID.Text;
            // telechargement du json de l'item
            string json = await SendWebRequest(apiUrlPrefix + id);
            // chargement du json dans data
            dynamic actualRecipe = JsonConvert.DeserializeObject<dynamic>(json);


            // test json to class : ok
            CrossoutDb test = CrossoutDb.FromJson(json);



            // test sur les classes
            //Person person = new Person { Name = "Bob", Age = 30 };

            //ChangeNameByReference(ref person);

            // test fonctionement class CrossoutDb - fonctionel !!
            //MessageBox.Show(test.Recipe.Item.Name, "info", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //textBoxItemName.Text = actualRecipe.recipe.item.name;
            //textBoxItemName.Text = person.Name;

            // remplissage de la treeview
            FeedTreeView(actualRecipe);



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

        private async Task<string> SendWebRequest(string url)
        {
            using (WebClient client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(new Uri(url));
                return json;
            }

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



    }
}
