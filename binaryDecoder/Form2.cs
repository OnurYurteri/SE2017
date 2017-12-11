﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace binaryDecoder
{
    public partial class Form2 : Form
    {
        Structure strToModify;
        public Form2(Structure str)
        {
            strToModify = str;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < strToModify.structure.Count; i++)
            {
                listBox1.Items.Add(strToModify.structure[i].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled)
            {
                listBox1.Items.Add(comboBox1.Text +"-"+ textBox1.Text);
            }
            else
            {
                listBox1.Items.Add(comboBox1.Text);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Enabled)
            {
                listBox1.Items[listBox1.SelectedIndex] = comboBox2.SelectedItem +"-"+ textBox2.Text;
            }
            else
            {
                listBox1.Items.Add(comboBox2.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enabled = false;
            if (comboBox1.SelectedItem.ToString() != "INT" && comboBox1.SelectedItem.ToString() != "ENDLOOP" && comboBox1.SelectedItem.ToString() != "FLOAT")
            {
                textBox1.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Enabled = false;
            if (comboBox2.SelectedItem.ToString() != "INT" && comboBox2.SelectedItem.ToString() != "ENDLOOP" && comboBox2.SelectedItem.ToString() != "FLOAT")
            {
                textBox2.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayList str = new ArrayList();
            if (listBox1.Items.Count > 0)
            {
                if (System.IO.File.Exists(@"C:\BinaryDecoder\" + strToModify.name))
                {
                    
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\BinaryDecoder\" + strToModify.name, false))
                    {
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            file.WriteLine(listBox1.Items[i]);
                        }
                    }
                    MessageBox.Show("Structure saved successfully!");
                    Program.form.RefreshStr();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Structure \"{0}\" doesn't exists.", textBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("Please fill all necessary fields.");
            }
        }
    }
}