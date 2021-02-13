using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsApplication1
{
    class Wallet
    {
        private int money;
        public int Money => money;
        public Wallet()
        {
            money = 100;
        }

        public void SpendMoney()
        {
            money -= 2;
        }

        public void EarnMoney(Cell cell)
        {
            switch (cell.state)
            {
                case CellState.Green:
                    money += 1;
                    break;
                case CellState.Immature:
                    money += 3;
                    break;
                case CellState.Mature:
                    money += 5;
                    break;
                case CellState.Overgrow:
                    money -= 1;
                    break;
            }
        }
    }
}
