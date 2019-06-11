using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CourseTask1
{
    public partial class Form1 : Form
    {
        public static class Globals
        {
            //public static String Dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName 
            //                           + "\\Data",                        //project folder for testing
            //                    File = Dir+"\\database.csv";

            public static String Dir = Application.StartupPath + "\\Data", //folder where the program is running
                File = Dir + "\\database.csv";
        }

        public Form1()
        {
            InitializeComponent();

            if (File.Exists(Globals.File))
            {
                int lineCount = File.ReadLines(Globals.File).Count(); // length of the array

                string[] split = new string[5];
                StreamReader read = new StreamReader(Globals.File); //the array to the screen
                for (int i = 0; i < lineCount; i++)
                {
                    split = read.ReadLine().Split(';'); //break the line for output in the form
                    ListViewItem lvi = new ListViewItem(split);
                    listView1.Items.Add(lvi); //bring out one by one to the screen
                }

                read.Close();
            }
            else
            {
                MessageBox.Show("Database is empty!");
                if (!Directory.Exists(Globals.Dir)) Directory.CreateDirectory(Globals.Dir);
                File.Create(Globals.File).Close();
            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(authorTextBox.Text)) // checking the author empty input
            {

                string fullLine = authorTextBox.Text // full line to write to file
                                  + ";"
                                  + bookTextBox.Text
                                  + ";"
                                  + yearTextBox.Text
                                  + ";"
                                  + publisherTextBox.Text
                                  + ";"
                                  + editionComboBox.Text;

                //create an array of the size of the number of lines in the file
                string[] readArray = new string[File.ReadLines(Globals.File).Count()];

                StreamReader read2 = new StreamReader(Globals.File);
                for (int i = 0; i < readArray.Length; i++)
                {
                    readArray[i] = read2.ReadLine();
                }

                read2.Close();

                if (!readArray.Contains(fullLine)) // looking for a string in the array, 
                                                    //if there is not one I write to the file
                {

                    using (StreamWriter flow2 = File.AppendText(Globals.File))
                        flow2.WriteLine(fullLine);

                    string[] arrayShow = new string[5] //line to display in the form
                    {
                        authorTextBox.Text,
                        bookTextBox.Text,
                        yearTextBox.Text,
                        publisherTextBox.Text,
                        editionComboBox.Text
                    };
                    ListViewItem lvi = new ListViewItem(arrayShow);
                    listView1.Items.Add(lvi);

                    //authorTextBox.Clear(); a code that can clear all fields filled in by the user in the form
                    //bookTextBox.Clear();      
                    //yearTextBox.Clear();
                    //publisherTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Book already exists!"); // the line was in the array
                }
            }
            else
            {
                MessageBox.Show("Please enter author!"); // when empty input
            }
        }



        private void buttonRec_Click(object sender, EventArgs e)
        {
            int lineCount = File.ReadLines(Globals.File).Count(); // count the lines in the file

            if (lineCount != 0)
            {
                if (!String.IsNullOrEmpty(DelTextBox.Text)) // letter for deleting
                {
                    char deleteChar = DelTextBox.Text[0]; // crop if you enter more

                    if (DelTextBox.Text.Length > 1)
                    {
                        MessageBox.Show(
                            String.Format("You entered more then one letter! " +
                                          "Filter will be applied to letter '{0}'", deleteChar));
                    }

                    string[] arrayDel = new string[lineCount]; // read an array for work

                    StreamReader read = new StreamReader(Globals.File);
                    for (int i = 0; i < lineCount; i++)
                        arrayDel[i] = read.ReadLine();
                    read.Close();

                    //create a list of indexes of array strings beginning with a letter
                    List<int> order = new List<int>();
                    int orderString = 0;
                    foreach (string j in arrayDel)
                    {
                        if (j.IndexOf(deleteChar) == 0)
                        {
                            order.Add(orderString); //fill out the list
                        }

                        orderString++;
                    }

                    if (order.Count == 0) // if the list is empty
                    {
                        MessageBox.Show("No authors found! Please choose another letter.");
                        DelTextBox.Clear();
                    }

                    order.Reverse(); //reverse the list

                    foreach (int j in order) // delete the rows in a combo list from the bottom of the array
                    {
                        arrayDel = arrayDel.Where(w => w != arrayDel[j]).ToArray(); // Linq
                    }

                    listView1.Items.Clear(); //clear the screen

                    string[] split = new string[5]; //write a new array into a file and bring it to the screen
                    StreamWriter flow = new StreamWriter(Globals.File);
                    foreach (string j in arrayDel)
                    {
                        flow.WriteLine(j);
                        split = j.Split(';');
                        ListViewItem lvi = new ListViewItem(split);
                        listView1.Items.Add(lvi);
                    }

                    flow.Close();
                    DelTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Please, choose a letter!"); //the letter was not entered
                    DelTextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Database is empty!");
                DelTextBox.Clear();
            }


        }

        private void DelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar)) //Input protection. Only the letters

            {
                e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char) Keys.Back);
            }
        }

        private void authorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Input protection. Only the letters
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char) Keys.Back);
        }

        private void publisherTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Input protection. Only the letters
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char) Keys.Back);
        }

        private void yearTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Input protection. Only the numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DelTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void publisherTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
