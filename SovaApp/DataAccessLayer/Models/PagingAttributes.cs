﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class PagingAttributes
    {
        public const int MaxPageSize = 1;
        private int _pageSize = MaxPageSize;
        public int Page { get; set; } = 0;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = Math.Min(value, MaxPageSize);
        }
    }
}
