using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlassProducts.Repositories.Sql
{
    internal static class ProductSql
    {
        public const string CheckIfTableExists = @"SELECT * FROM sysobjects WHERE name = 'product' and xtype='U'";

        public const string CreateTable = @"
            USE [auto_glass_challenge]
            GO            

            CREATE TABLE [dbo].[product](
	            [id] [int] IDENTITY(1,1) NOT NULL,
	            [supplier_id] [int] NOT NULL,
	            [description] [varchar](200) NOT NULL,
	            [situation] [int] NOT NULL,
	            [made_on] [datetime2](7) NOT NULL,
	            [expires_at] [datetime2](7) NOT NULL,
             CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
            (
	            [id] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY]
            GO
        ";

        public const string CreateForeignKeySupplier = @"
            USE [auto_glass_challenge]
            GO             

            ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_supplier] FOREIGN KEY([supplier_id])
            REFERENCES [dbo].[supplier] ([id])
            GO

            ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_supplier]
            GO
        ";
    }
}
