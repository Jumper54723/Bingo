using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    internal class globalClasses
    {

    }
    internal class BingoCard
    {
        public string cardName;
        public int cardNumber;
        public int[,] bingoCardNumbers = new int[5, 5];
        public int bingoNumberRows;
        public int bingoNumberColumns;
    }
}
