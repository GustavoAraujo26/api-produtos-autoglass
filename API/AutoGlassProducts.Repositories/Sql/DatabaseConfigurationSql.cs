namespace AutoGlassProducts.Repositories.Sql
{
    internal static class DatabaseConfigurationSql
    {
        public const string CreateDatabase = @"
            CREATE DATABASE [auto_glass_challenge]
        ";

        public const string CheckIfDatabaseExists = @"SELECT DB_ID('auto_glass_challenge')";
        
        public const string CheckIfProductTableExists = @"
            USE [auto_glass_challenge]
            
            SELECT COUNT(*) FROM sysobjects WHERE name = 'product' and xtype='U'
        ";

        public const string CheckIfSupplierTableExists = @"
            USE [auto_glass_challenge]
            
            SELECT COUNT(*) FROM sysobjects WHERE name = 'supplier' and xtype='U'
        ";

        public const string CreateProductTable = @"
            USE [auto_glass_challenge]
            
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
        ";

        public const string CreateForeignKeySupplierOnProductTable = @"
            USE [auto_glass_challenge]
            
            ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_supplier] FOREIGN KEY([supplier_id])
            REFERENCES [dbo].[supplier] ([id])
            
            ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_supplier]
        ";

        public const string CreateSupplierTable = @"
            USE [auto_glass_challenge]
            
            CREATE TABLE [dbo].[supplier](
	            [id] [int] IDENTITY(1,1) NOT NULL,
	            [supplier_document] [varchar](14) NOT NULL,
	            [description] [varchar](200) NOT NULL,
	            [situation] [int] NOT NULL,
             CONSTRAINT [PK_supplier] PRIMARY KEY CLUSTERED 
            (
	            [id] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY]
        ";
    }
}
