namespace AutoGlassProducts.Repositories.Sql
{
    internal static class ProductSql
    {
        public const string Insert = @"
            USE [auto_glass_challenge]

            INSERT INTO [dbo].[product]
                       ([supplier_id]
                       ,[description]
                       ,[situation]
                       ,[made_on]
                       ,[expires_at])
                 VALUES
                       (@SupplierId
                       ,@Description
                       ,@Situation
                       ,@MadeOn
                       ,@ExpiresAt);
            SELECT CAST(SCOPE_IDENTITY() as int)
        ";

        public const string Update = @"
            USE [auto_glass_challenge]

            UPDATE [dbo].[product]
            SET [supplier_id] = @SupplierId
                ,[description] = @Description
                ,[situation] = @Situation
                ,[made_on] = @MadeOn
                ,[expires_at] = @ExpiresAt
            WHERE [id] = @Id;
            SELECT CAST(SCOPE_IDENTITY() as int)
        ";

        public const string GetById = @"
            USE [auto_glass_challenge]
            
            SELECT [id] as Id
                  ,[supplier_id] as SupplierId
                  ,[description] as Description
                  ,[situation] as Situation
                  ,[made_on] as MadeOn
                  ,[expires_at] as ExpiresAt
              FROM [auto_glass_challenge].[dbo].[product]
              WHERE [id] = @Id
        ";

        public const string List = @"
            USE [auto_glass_challenge]
            
            SELECT p.[id] as Id
                  ,p.[supplier_id] as SupplierId
                  ,p.[description] as Description
                  ,p.[situation] as Situation
                  ,p.[made_on] as MadeOn
                  ,p.[expires_at] as ExpiresAt
              FROM [auto_glass_challenge].[dbo].[product] as p
              INNER JOIN [auto_glass_challenge].[dbo].supplier as s on s.id = p.supplier_id
        ";

        public const string GetTotalRows = @"SELECT COUNT(*) FROM [auto_glass_challenge].[dbo].[product]";
    }
}
