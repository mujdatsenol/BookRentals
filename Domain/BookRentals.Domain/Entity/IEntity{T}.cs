﻿namespace BookRentals.Domain
{
    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }
}
