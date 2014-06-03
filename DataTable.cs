using System.Collections.Generic;
using System.ComponentModel;

namespace TableDataSource
{
    [DataObjectAttribute]
    static public class DataTable
    {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static System.Data.DataTable GetTable(System.Data.DataTable dt)
        {
            return dt;
        }
    }
}
