using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();
        Wallet wallet = new Wallet();
        int time = 0;

        public Form1()
        {
            InitializeComponent();
            foreach (CheckBox cb in panel1.Controls)
                field.Add(cb, new Cell(wallet));
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (sender as CheckBox);
            if (cb.Checked) Plant(cb);
            else Harvest(cb);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (CheckBox cb in panel1.Controls)
                NextStep(cb);
                
            UpdateValue();
        }

        private void Plant(CheckBox cb)
        {
            field[cb].Plant();
            UpdateBox(cb);
        }

        private void Harvest(CheckBox cb)
        {
            field[cb].Harvest();
            UpdateBox(cb);
        }

        private void NextStep(CheckBox cb)
        {
            field[cb].NextStep();
            UpdateBox(cb);
        }

        private void UpdateBox(CheckBox cb)
        {
            Color c = Color.White;

            switch (field[cb].state)
            {
                case CellState.Planted: c = Color.Black;
                    break;
                case CellState.Green: c = Color.Green;
                    break;
                case CellState.Immature: c = Color.Yellow;
                    break;
                case CellState.Mature: c = Color.Red;
                    break;
                case CellState.Overgrow: c = Color.Brown;
                    break;
            }

            cb.BackColor = c;
            labelMoney.Text = $"{wallet.Money}";
        }

        private void UpdateValue()
        {
            label1.Text = $"{field[(CheckBox)panel1.Controls[0]].state}";
            label2.Text = $"{field[(CheckBox)panel1.Controls[1]].state}";
            label3.Text = $"{field[(CheckBox)panel1.Controls[2]].state}";
            label4.Text = $"{field[(CheckBox)panel1.Controls[3]].state}";
            label5.Text = $"{field[(CheckBox)panel1.Controls[4]].state}";
            label6.Text = $"{field[(CheckBox)panel1.Controls[5]].state}";
            label7.Text = $"{field[(CheckBox)panel1.Controls[6]].state}";
            label8.Text = $"{field[(CheckBox)panel1.Controls[7]].state}";
            label9.Text = $"{field[(CheckBox)panel1.Controls[8]].state}";
            label10.Text = $"{field[(CheckBox)panel1.Controls[9]].state}";
            label11.Text = $"{field[(CheckBox)panel1.Controls[10]].state}";
            label12.Text = $"{field[(CheckBox)panel1.Controls[11]].state}";
            label13.Text = $"{field[(CheckBox)panel1.Controls[12]].state}";
            label14.Text = $"{field[(CheckBox)panel1.Controls[13]].state}";
            label15.Text = $"{field[(CheckBox)panel1.Controls[14]].state}";
            label16.Text = $"{field[(CheckBox)panel1.Controls[15]].state}";

        }

        private void nudStepSize_ValueChanged(object sender, EventArgs e)
        {

            timer1.Interval = 1000/(int)nudStepSize.Value;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label19.Text = $"{time} sec";
            time++;
        }
    }

    
}