﻿namespace Wbc.Application.Common.Interfaces
{
    public interface IDataServiceProvider
    {
        T Get<T>();
    }
}
