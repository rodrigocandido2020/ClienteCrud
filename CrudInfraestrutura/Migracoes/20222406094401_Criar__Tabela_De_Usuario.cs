using FluentMigrator;

namespace Crud.Infra.Migracoes
{
    [Migration(20222406094401)]
    public class _20222406094401_Criar__Tabela_De_Usuario : Migration
    {
        public override void Up()
        {
            Create.Table("USUARIO")
                .WithColumn("ID").AsInt64().PrimaryKey().Identity()
                .WithColumn("NOME").AsString(200).NotNullable()
                .WithColumn("SENHA").AsString(600).NotNullable()
                .WithColumn("EMAIL").AsString(200).NotNullable()
                .WithColumn("DATACRIACAO").AsDateTime().NotNullable()
                .WithColumn("DATANASCIMENTO").AsDateTime().Nullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
