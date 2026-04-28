using System;

namespace GoodsSales.Core.Model;

public record Sale(
    int Id,
    int PersonId,
    DateTime SaleDate
);