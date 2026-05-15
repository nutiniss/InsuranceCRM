using Firma.Data.Data.Common;

namespace Firma.Intranet.Infrastructure;

public static class SoftDeleteExtensions
{
    public static void MarkAsDeleted(this ISoftDeletable entity)
    {
        entity.StatusRekordu = RecordStatus.Deleted;
    }
}
