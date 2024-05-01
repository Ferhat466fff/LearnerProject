namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contactt_and_message_table_addedddd : DbMigration
    {
        public override void Up()
        {
    

            CreateTable(
                "dbo.Messages",
                c => new
                {
                    MessageId = c.Int(nullable: false, identity: true),
                    NameSurname = c.String(),
                    Email = c.String(),
                    Subject = c.String(),
                    MessageContent = c.String(),
                    IsRead = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.MessageId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
