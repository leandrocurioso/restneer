﻿using System;

namespace Restneer.Core.Infrastructure.Model.ValueObject
{
    public class QueryParamValueObject<T>
    {
        public T Model { get; set; }
        public long? Limit = 25;
        public long? Offset = 0;
        public string SearchTerm { get; set; }
        public DateTime StartAt = DateTime.MinValue;
        public DateTime EndAt = DateTime.MaxValue;
    }
}
