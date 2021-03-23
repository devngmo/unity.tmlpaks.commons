using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmlpaks.commons
{
    [Serializable]
    public class RowColumn
    {
        public int Row, Column;
        public RowColumn()
        {

        }
        public RowColumn(int row, int col)
        {
            Row = row;
            Column = col;
        }

        public override string ToString()
        {
            return $"({Row}, {Column})";
        }
    }
}
