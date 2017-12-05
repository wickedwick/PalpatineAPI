namespace PalpatineApi.Migrations.PalpatineData
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGalleryImageAndTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GalleryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Source = c.String(),
                        Thumbnail = c.String(),
                        ThumbnailHeight = c.Int(nullable: false),
                        ThumbnailWidth = c.Int(nullable: false),
                        Caption = c.String(),
                        IsSelected = c.Boolean(nullable: false),
                        Gallery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.Gallery_Id)
                .Index(t => t.Gallery_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Value = c.String(),
                        Image_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.Image_Id)
                .Index(t => t.Image_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Gallery_Id", "dbo.Galleries");
            DropForeignKey("dbo.Tags", "Image_Id", "dbo.Images");
            DropIndex("dbo.Tags", new[] { "Image_Id" });
            DropIndex("dbo.Images", new[] { "Gallery_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Images");
            DropTable("dbo.Galleries");
        }
    }
}
