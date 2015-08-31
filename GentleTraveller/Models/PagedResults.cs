using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GentleTraveller.Models
{
    public class PagedResult<T>
    {
        public int PageNo { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; private set; }

        public long TotalRecordCount { get; set; }

        public PagedResult(IEnumerable<T> items, int pageNo, int pageSize, long totalRecordCount)
        {
            Items = new List<T>(items);

            PageNo = pageNo;
            PageSize = pageSize;
            TotalRecordCount = totalRecordCount;

            PageCount = totalRecordCount > 0
                        ? (int)Math.Ceiling(totalRecordCount / (double)PageSize)
                        : 0;
        }

        public List<T> Items { get; set; }
    }

    public static class QuerySortingExtensions
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, IEnumerable<string> sort) where T : class
        {
            if (sort != null)
            {
                List<string> sortFields = new List<string>();

                foreach (string sortField in sort)
                {
                    //string direction = null;
                    //string fieldName = null;

                    if (sortField.StartsWith("+"))
                    {
                        sortFields.Add(string.Format("{0} ASC", sortField.TrimStart('+')));
                    }
                    else if (sortField.StartsWith("-"))
                    {
                        sortFields.Add(string.Format("{0} DESC", sortField.TrimStart('-')));
                    }
                    else
                    {
                        sortFields.Add(sortField);
                    }
                }

                return query;
                //return query.OrderBy(String.Join(",", sortFields));
            }

            return query;
        }
    }
}