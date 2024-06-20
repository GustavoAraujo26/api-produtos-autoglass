using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlassProducts.Repositories.Sql
{
    internal static class SupplierSql
    {
        public const string CheckIfTableExists = @"SELECT * FROM sysobjects WHERE name = 'product' and xtype='U'";
    }
}
