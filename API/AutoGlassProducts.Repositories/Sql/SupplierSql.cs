namespace AutoGlassProducts.Repositories.Sql
{
    internal static class SupplierSql
    {
        public const string Insert = @"
            USE [auto_glass_challenge]

            INSERT INTO [dbo].[supplier]
                       ([supplier_document]
                       ,[description]
                       ,[situation])
                 VALUES
                       (@Document
                       ,@Description
                       ,@Situation);
            SELECT CAST(SCOPE_IDENTITY() as int)
        ";

        public const string Update = @"
            USE [auto_glass_challenge]

            UPDATE [dbo].[supplier]
               SET [supplier_document] = @Document
                  ,[description] = @Description
                  ,[situation] = @Situation
             WHERE [id] = @Id;
            SELECT CAST(SCOPE_IDENTITY() as int)
        ";

        public const string GetById = @"
            USE [auto_glass_challenge]
            
            SELECT [id] as Id
                  ,[supplier_document] as Document
                  ,[description] as Description
                  ,[situation] as Situation
              FROM [dbo].[supplier]
              WHERE [id] = @Id
        ";

        public const string List = @"
            USE [auto_glass_challenge]
            
            SELECT [id] as Id
                  ,[supplier_document] as Document
                  ,[description] as Description
                  ,[situation] as Situation
              FROM [dbo].[supplier]
        ";

        public const string GetTotalRows = @"SELECT COUNT(*) FROM [auto_glass_challenge].[dbo].[supplier]";
    }
}
