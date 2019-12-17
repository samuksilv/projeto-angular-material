using Portal.Domain.Models;

namespace Portal.Infra.Database.Contants.Tables
{
    public class TableConstants
    {
        public static string UserTable = $"[{nameof(User)}]";
        public static string SegmentTable = $"[{nameof(Segment)}]";
    }
}