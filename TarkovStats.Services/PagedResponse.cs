using Microsoft.EntityFrameworkCore;

namespace TarkovStats.Services
{
    public class PagedResponseMetaData
    {
        public bool ShowNext;
        public bool ShowPrevious;
        public int StartIndex;
        public int EndIndex;
        public int CurrentPage;
        public int TotalPages;
        public int ItemsPerPage;
    }
    public class PagedResponse<T> : List<T>
    {
      
        public int Count { get; }
        public int Pages { get; }
        public int PagesPerSide { get; set; }
        public PagedResponseMetaData Metadata { get; set; }
        public PagedResponse(List<T> items, int count, int pageIndex, int pageSize,int pagesPerSide)
        {
            PagesPerSide = pagesPerSide;
            Metadata = new PagedResponseMetaData();
            Count = count;
            Metadata.CurrentPage = pageIndex;
            Metadata.TotalPages = (int)Math.Ceiling((double)count / (double)pageSize);
            AddRange(items);
            BuildMeta();
        }
        
        public static async Task<PagedResponse<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize,int pagesPerSide)
        {
            if (pageIndex == 0) pageIndex = 1;
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var total = (int) Math.Ceiling(count / (double) pageSize);
            if (items.Count == 0 && pageIndex > total)
            {
                items = await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            }

            return new PagedResponse<T>(items, count, pageIndex, pageSize,pagesPerSide);
        }

        private void BuildMeta()
        {
            if (Metadata.CurrentPage > 1)
            {
                Metadata.ShowPrevious = true;
            }

            if (Metadata.CurrentPage < Metadata.TotalPages)
            {
                Metadata.ShowNext = true;
            }

            var halfPagesPerSide = (int)Math.Round((double)PagesPerSide / 2);

            var left = Metadata.CurrentPage - halfPagesPerSide;
            var right = Metadata.CurrentPage + halfPagesPerSide;

            if (left < 1) left = 1;
            if (right > Metadata.TotalPages) right = Metadata.TotalPages;
            Metadata.StartIndex = left;
            Metadata.EndIndex = right;
        }
    }
}