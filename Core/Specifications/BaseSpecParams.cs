﻿namespace Core.Specifications
{
    public abstract class BaseSpecParams
    {
        private const int MaxPageSize = 50;
        
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 5;
        
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
        
    }
}