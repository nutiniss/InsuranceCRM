using Firma.Data.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Intranet.Migrations
{
    [DbContext(typeof(FirmaContext))]
    [Migration("20260515120000_AddSoftDeleteStatus")]
    partial class AddSoftDeleteStatus
    {
        protected override void BuildTargetModel(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.8");
#pragma warning restore 612, 618
        }
    }
}
