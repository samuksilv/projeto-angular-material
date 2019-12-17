using Portal.Domain.Models;
using Portal.Infra.Database.Contants.Tables;

namespace Portal.Infra.Database.Contants.Queries {
    public static class SegmentQueries {
        public static readonly string GetAll = $@"
        SELECT * FROM {TableConstants.SegmentTable}
        ORDER BY {TableConstants.SegmentTable}.[{nameof(Segment.Description)}]";

        public static readonly string GetById = $@"
        SELECT TOP 1 * FROM {TableConstants.SegmentTable}
        WHERE {TableConstants.SegmentTable}.[{nameof(Segment.Id)}] = @Id";

        public static readonly string GetAllFilterByDescription = $@"
        SELECT * FROM {TableConstants.SegmentTable}
        WHERE {TableConstants.SegmentTable}.[{nameof(Segment.Description)}] LIKE '%'+ @Description  +'%'
        ORDER BY {TableConstants.SegmentTable}.[{nameof(Segment.Description)}]";

        public static string GetAllPaginatedWithFilter (string description) {

            if (string.IsNullOrEmpty (description))
                return $@"
                    SELECT * FROM {TableConstants.SegmentTable}                  
                    ORDER BY {TableConstants.SegmentTable}.[{nameof(Segment.Description)}]
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
            else
                return $@"
                    SELECT * FROM {TableConstants.SegmentTable}
                    WHERE @Description IS NULL 
                    OR {TableConstants.SegmentTable}.[{nameof(Segment.Description)}] LIKE '%'+ @Description  +'%'
                    ORDER BY {TableConstants.SegmentTable}.[{nameof(Segment.Description)}]
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
        }

        public static string CountWithFilter (string description) {

            if (string.IsNullOrEmpty (description))
                return $@"SELECT COUNT(*) FROM {TableConstants.SegmentTable}";
            else
                return $@"
                    SELECT COUNT(*) FROM {TableConstants.SegmentTable}
                    WHERE {TableConstants.SegmentTable}.[{nameof(Segment.Description)}] LIKE '%'+ @Description  +'%'";
        }
    }
}