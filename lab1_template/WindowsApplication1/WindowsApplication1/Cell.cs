using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsApplication1
{
    class Cell
    {
        public CellState state = CellState.Empty;
        public int progress = 0;
        private Wallet wallet;

        private const int prPlanted = 20;
        private const int prGreen = 100;
        private const int prImmature = 120;
        private const int prMature = 140;

        

        public Cell(Wallet wallet)
        {
            this.wallet = wallet;
        }
        public void Plant()
        {
            wallet.SpendMoney();
            state = CellState.Planted;
            progress = 1;
        }

        public void Harvest()
        {
            wallet.EarnMoney(this);
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
