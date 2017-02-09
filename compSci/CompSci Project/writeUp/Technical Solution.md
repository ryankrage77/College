```
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace compSciProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //this is where global variables go
        public static class Globals
        {
            //selectedItem isused to store the index of the last selected employee so it can be programatically re-selected when needed.
            public static int selectedItem = 0;
            //path is the directory the program is running in, so all filepaths are relative that.
            //this makes the application portable. Just copy the release folder to another PC or USB stick.
            public static string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }

        private void navigatewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //SELECT EMPLOYEE
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check that only one item is selected
            if (listView1.SelectedItems.Count == 1)
            {
                //assign the selected item to a var so if deselected it can be programatically re-selected later.
                Globals.selectedItem = listView1.SelectedIndices[0];

                //update the labels to match their subItem text
                label8.Text = listView1.SelectedItems[0].SubItems[1].Text;
                label9.Text = listView1.SelectedItems[0].SubItems[2].Text;
                label10.Text = listView1.SelectedItems[0].SubItems[3].Text;
                label11.Text = listView1.SelectedItems[0].SubItems[4].Text;
                //update the image from the filepath in the 5th SubItem
                pictureBox1.Image = Image.FromFile(listView1.SelectedItems[0].SubItems[5].Text);

                //Now to re-populate ListView2 with tasks specific to the employee, from the employees file.
                //each line of [file].txt becomes an element of the array lines
                //first, clear the listView
                listView2.Clear();
                //then, we generate the filepath for the selected employee;
                int filename = Globals.selectedItem;
                string name = filename.ToString();
                string path = Globals.path + "\\data\\" + name + ".txt";
                //then we re-populate the listview from that file
                string[] lines = System.IO.File.ReadAllLines(path);
                //each element is dealt with one at a time
                foreach (string line in lines)
                {
                    //create an array 'info'. Each element in info is one peice of information from the line in [file].txt
                    string[] info = line.Split(',');
                    ListViewItem item = listView2.Items.Add(info[0]);
                    item.SubItems.Add(info[1]);
                    item.SubItems.Add(info[2]);
                    item.SubItems.Add(info[3]);
                    item.SubItems.Add(info[4]);
                }
                //check if ListView is populated, and if so, select the first item & then calculate the employees due pay
                if (listView2.Items.Count != 0)
                {
                    listView2.Items[0].Selected = true;

                    //calculate the employee's pay
                    float pay = 0;
                    foreach (ListViewItem item in listView2.Items)
                    {
                        if (item.SubItems[4].Text == "Yes")
                        {
                            pay += float.Parse(item.SubItems[3].Text);
                        }
                    }
                    //update label showing pay
                    label23.Text = String.Format("{0:0,0.00}", pay);
                }
                else
                {
                    label23.Text = "00.00";
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //LOAD APPLICATION. POPULATE EMPLOYEE LISTVIEW.
        private void Form1_Load(object sender, EventArgs e)
        {
            //read employees.txt and populate the ListView with employees & info
            //each line of employees.txt becomes an element of lines
            string[] lines = System.IO.File.ReadAllLines(Globals.path + "\\data\\" + "employees.txt");
            //each element is dealt with one at a time
            foreach (string line in lines)
            {
                //create an array info. Each element in info is one peice of info from the line in employees.txt
                string[] info = line.Split(',');
                ListViewItem item = listView1.Items.Add(info[0]);
                item.SubItems.Add(info[1]);
                item.SubItems.Add(info[2]);
                item.SubItems.Add(info[3]);
                item.SubItems.Add(info[4]);
                item.SubItems.Add(info[5]);
            }

            //check if ListView is populated, and if so, select the first item
            if(listView1.Items.Count != 0)
            {
                listView1.Items[0].Selected = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        //EDIT PICTURE
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //open a file dialog to chose an image and assign to the 5th subitem of the selected item
            if(DialogResult.OK == openFileDialog1.ShowDialog())
            {
                //assign the image filepath to the 5th SubItem
                listView1.SelectedItems[0].SubItems[5].Text = openFileDialog1.FileName;
                //update the picture
                pictureBox1.Image = Image.FromFile(listView1.SelectedItems[0].SubItems[5].Text);
            }

        }


        private void listView1_ItemActivate(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate_1(object sender, EventArgs e)
        {

        }

        //ADD EMPLOYEE
        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create a new item and its subitems
            ListViewItem item = listView1.Items.Add("Employee");
            item.SubItems.Add("Name");
            item.SubItems.Add("Position");
            item.SubItems.Add("Contact");
            item.SubItems.Add("Employee Since");
            //add a default image.
            item.SubItems.Add(Globals.path +"\\resources\\"+ "gaming masters custom size.png");

            //create a text file to store the tasks
            //first, get the position of the item just created. This will be used to name the file so it can be associated with the employee later
            int index = item.Index;
            //convert that index to a string so it can be put in the filename
            string fileName = index.ToString();
            //finally, create the filepath & then create & then close the file.
            string path = Globals.path + "\\data\\" + fileName + ".txt";
            var myFile = File.Create(path);
            myFile.Close();


        }

        //EDIT EMPLOYEE
        private void button1_Click(object sender, EventArgs e)
        {
            //check there is something to edit
            if (listView1.Items.Count != 0)
            {
                //show the textboxes and make the other button visible
                textBox1.Visible = !textBox1.Visible;
                textBox2.Visible = !textBox2.Visible;
                textBox3.Visible = !textBox3.Visible;
                textBox4.Visible = !textBox4.Visible;
                button1.Visible = !button1.Visible;
                button2.Visible = !button2.Visible;

                //check if an item is not selected, and if so, select the first item
                if (listView1.SelectedItems.Count == 0)
                {
                    listView1.Items[0].Selected = true;
                }
            }
            //otherwise prompt the user to add an employee.
            else
            {
                MessageBox.Show("You need to add an employee before you can edit one! Try Edit>Add Employee in the menu.");
            }

        }

        //FINSIH EDITING EMPLOYEE (CLICK DONE)
        private void button2_Click(object sender, EventArgs e)
        {
            //find the selected item and update each of the subItems to the contents of the textboxes
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.SubItems[1].Text = textBox1.Text;
                item.SubItems[2].Text = textBox2.Text;
                item.SubItems[3].Text = textBox3.Text;
                item.SubItems[4].Text = textBox4.Text;
            }

            //Update the labels
            label8.Text = listView1.SelectedItems[0].SubItems[1].Text;
            label9.Text = listView1.SelectedItems[0].SubItems[2].Text;
            label10.Text = listView1.SelectedItems[0].SubItems[3].Text;
            label11.Text = listView1.SelectedItems[0].SubItems[4].Text;
            //hide the textboxes and make the other button visible
            textBox1.Visible = !textBox1.Visible;
            textBox2.Visible = !textBox2.Visible;
            textBox3.Visible = !textBox3.Visible;
            textBox4.Visible = !textBox4.Visible;
            button1.Visible = !button1.Visible;
            button2.Visible = !button2.Visible;
        }

        //REMOVE EMPLOYEE
        private void removeEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //find the selected employee
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                //delete their task file & re-order the other ones
                int index = item.Index;
                //convert that index to a string so it can be put in the filename
                string fileName = index.ToString();
                //finally, create the filepath & then create & then close the file.
                string path = Globals.path + "\\data\\" + fileName + ".txt";
                File.Delete(path);
                int fileCount = (Directory.GetFiles(Globals.path + "\\data").Length) - 1;

                while(index < fileCount)
                {
                    //rename file (index+1).txt as (index).txt (move every file down by 1)
                    File.Move(Globals.path + "\\data\\" + (index+1) + ".txt", Globals.path + "\\data\\" + (index) + ".txt");
                    index += 1;
                }
                //remove the employee
                listView1.Items.Remove(item);
            }
        }

        //SAVE.
        //Writes each item in the Listview to a new line, with the subitems also on that line.
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb;
            //set apendExistingFile to false so the new save overwrites the old one.
            bool appendExistingFile = false;
            //tell it where to save to.
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Globals.path + "\\data\\" + "employees.txt", appendExistingFile))
                //check that there is something actually in the listview.
                if (listView1.Items.Count > 0)
            {
                //for each Item in the Listview, write it to file and then write each of its subitems, seperated by commas
                foreach (ListViewItem lvi in listView1.Items)
                {
                    sb = new StringBuilder();

                    foreach (ListViewItem.ListViewSubItem listViewSubItem in lvi.SubItems)
                    {
                        sb.Append(string.Format("{0},", listViewSubItem.Text));
                    }
                    sw.WriteLine(sb.ToString());
                }
            }
        }

        //ADD TASK
        private void button3_Click(object sender, EventArgs e)
        {
            //create a new task and its subitems
            ListViewItem item = listView2.Items.Add("Task");
            item.SubItems.Add("Set");
            item.SubItems.Add("Due");
            item.SubItems.Add("Value");
            item.SubItems.Add("Status");
        }

        //UPDATE INFO WHEN A TASK IS SELECTED
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check that only one item is selected
            if (listView2.SelectedItems.Count == 1)
            {
                //update the labels to match their subItem text
                label12.Text = listView2.SelectedItems[0].SubItems[1].Text;
                label13.Text = listView2.SelectedItems[0].SubItems[2].Text;
                label14.Text = listView2.SelectedItems[0].SubItems[3].Text;
                label15.Text = listView2.SelectedItems[0].SubItems[4].Text;
            }

        }

        //EDIT TASK
        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0 && listView2.Items.Count != 0)
            {
                //when the 'Edit' button for tasks is clicked, show the textboxes and make the 'Done' button visible
                maskedTextBox2.Visible = !maskedTextBox2.Visible;
                maskedTextBox3.Visible = !maskedTextBox3.Visible;
                maskedTextBox1.Visible = !maskedTextBox1.Visible;
                comboBox1.Visible = !comboBox1.Visible;
                button4.Visible = !button4.Visible;
                button5.Visible = !button5.Visible;

                //check if an item is not selected, and if so, select the first item
                if (listView2.SelectedItems.Count == 0)
                {
                    listView2.Items[0].Selected = true;
                }
            }
            else
            {
                MessageBox.Show("You need to add a task before you can edit one! Try clicking 'Add Task'.");
            }

        }

        //FINSIH EDITING TASK
        private void button5_Click(object sender, EventArgs e)
        {
            {
                //find the selected item and update each of the subItems to the contents of the textboxes
                foreach (ListViewItem item in listView2.SelectedItems)
                {
                    item.SubItems[1].Text = maskedTextBox2.Text;
                    item.SubItems[2].Text = maskedTextBox3.Text;
                    //if a task has been marked as completed without a value supply a default one.
                    //this prevents the pay calculator from complaining about incorrectly formatted strings when converting to a float.
                    if (comboBox1.Text == "Yes" && maskedTextBox1.Text == "  .")
                    {
                        item.SubItems[3].Text = "00.00";
                    }
                    else
                    {
                        item.SubItems[3].Text = maskedTextBox1.Text;
                    }
                    item.SubItems[4].Text = comboBox1.Text;
                }

                //Update the labels
                label12.Text = listView2.SelectedItems[0].SubItems[1].Text;
                label13.Text = listView2.SelectedItems[0].SubItems[2].Text;
                label14.Text = listView2.SelectedItems[0].SubItems[3].Text;
                label15.Text = listView2.SelectedItems[0].SubItems[4].Text;
                //hide the textboxes and make the other button visible
                maskedTextBox2.Visible = !maskedTextBox2.Visible;
                maskedTextBox3.Visible = !maskedTextBox3.Visible;
                maskedTextBox1.Visible = !maskedTextBox1.Visible;
                comboBox1.Visible = !comboBox1.Visible;
                button4.Visible = !button4.Visible;
                button5.Visible = !button5.Visible;

                //now to save the tasks so they aren't lost when another employee is selected.
                //first, select the last selected item in ListView1
                listView1.Items[Globals.selectedItem].Selected = true;
                listView1.Select();
                //now to write all the tasks in listView2 to the selectedItem'th file in the data folder
                //that is, write the tasks to the file associated with the employee
                {
                    StringBuilder sb;
                    //set apendExistingFile to false so the new save overwrites the old one.
                    bool appendExistingFile = false;
                    //tell it where to save to.
                    int filename = listView1.SelectedIndices[0];
                    string name = filename.ToString();
                    string filepath = Globals.path + "\\data\\" + name + ".txt";
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filepath, appendExistingFile))

                        //check that there is something actually in the listview.
                        if (listView2.Items.Count > 0)
                        {
                            //for each Item in the Lsitview, write it to file and then write each of its subitems, seperated by commas
                            foreach (ListViewItem lvi in listView2.Items)
                            {
                                sb = new StringBuilder();

                                foreach (ListViewItem.ListViewSubItem listViewSubItem in lvi.SubItems)
                                {
                                    sb.Append(string.Format("{0},", listViewSubItem.Text));
                                }
                                sw.WriteLine(sb.ToString());
                            }
                        }
                }

            }
        }

        //REMOVE TASK
        private void button6_Click(object sender, EventArgs e)
        {
            //find the selected task
            foreach (ListViewItem Item in listView2.SelectedItems)
            {
                //remove it
                listView2.Items.Remove(Item);
            }
        }

        //OPEN HELP
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open a HTML file with the default browser to give help
            System.Diagnostics.Process.Start(Globals.path + "\\resources\\" + "help.HTML");
        }
    }
}

```
