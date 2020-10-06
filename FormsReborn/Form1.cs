using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsReborn
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton rad, rad2;
        TextBox txt_box;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";

            tree = new TreeView();
            tree.Dock = DockStyle.Right;
            
            
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp/Button"));
            tn.Nodes.Add(new TreeNode("Silt/Label"));
            tn.Nodes.Add(new TreeNode("Märkeruut/Checkbox"));
            tn.Nodes.Add(new TreeNode("Radionupp/Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstkast/Textbox"));
            //button
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(50, 10);
            btn.Height = 100;
            btn.Width = 100;
            btn.Click += Btn_Click;
            //label
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Size = new Size(100, 100);
            lbl.Location = new Point(160, 10);


            tree.AfterSelect += Tree_AfterSelect;

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        string text = File.ReadAllText(@"C:\Users\opilane\source\repos\Konovalov\file.txt");
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp/Button")
            {

                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt/Label")
            {

                this.Controls.Add(lbl);


            }
            else if (e.Node.Text == "Märkeruut/Checkbox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(50, 110);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(50, 150);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
            }
            else if (e.Node.Text == "Radionupp/Radiobutton")
            {
                rad = new RadioButton();
                rad.Text = "Vasakule";
                rad.Location = new Point(50, 300);
                rad.CheckedChanged += Rad_CheckedChanged;

                rad2 = new RadioButton();
                rad2.Text = "Paremale";
                rad2.Location = new Point(50, 350);

                this.Controls.Add(rad);
                this.Controls.Add(rad2);
            }
            else if (e.Node.Text == "Tekstkast/Textbox")
            {
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = text;
                txt_box.Width = 200;
                txt_box.Height = 200;
                txt_box.Location = new Point(300, 300);
                this.Controls.Add(txt_box);
            }
        }

        private void Rad_CheckedChanged(object sender, EventArgs e)
        {
            if (rad.Checked)
            {
                btn.Location = new Point(300, 10);
            }
            else if (rad2.Checked)
            {
                btn.Location = new Point(50, 380);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked == true)
            {
                this.Controls.Add(lbl);
            }
            else
            {
                this.Controls.Remove(lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if(box_btn.Checked==true)
            {
                this.Controls.Add(btn);
            }
            else
            {
                this.Controls.Remove(btn);
            }
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\Users\opilane\source\repos\Konovalov\file.txt", txt_box.Text);
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Aqua;

            }
            else
            {
                lbl.BackColor = Color.Red;
                btn.BackColor = Color.Blue;
            }

        }
    }
}
