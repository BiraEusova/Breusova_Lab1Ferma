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

        public Form1()
        {
            InitializeComponent();
            foreach (CheckBox cb in panel1.Controls)
                field.Add(cb, new Cell());
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
        }
    }

    enum CellState
    {
        Empty,
        Planted,
        Green,
        Immature,
        Mature,
        Overgrow
    }

    class Cell
    {
        public CellState state = CellState.Empty;
        public int progress = 0;

        private const int prPlanted = 20;
        private const int prGreen = 100;
        private const int prImmature = 120;
        private const int prMature = 140;

        public void Plant()
        {
            state = CellState.Planted;
            progress = 1;
        }

        public void Harvest()
        {
            state = CellState.Empty;
            progress = 0;
        }

        public void NextStep()
        {
            if ((state != CellState.Empty) && (state != CellState.Overgrow))
            {
                progress++;
                if (progress < prPlanted) state = CellState.Planted;
                else if (progress < prGreen) state = CellState.Green;
                else if (progress < prImmature) state = CellState.Immature;
                else if (progress < prMature) state = CellState.Mature;
                else state = CellState.Overgrow;
            }
        }
    }
}