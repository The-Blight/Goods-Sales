using System;

namespace GoodsSales.Core.Model;

public record Person
{
    public required int Id { get; init; }
    public required string FirstName { get; init; }
    public string? Patronymic { get; init; }
    public required string LastName { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public required bool IsDeleted { get; init; }

    public override string ToString()
    {
        return Patronymic is null
            ? $"{Id} {FirstName} {LastName} {DateOfBirth} {IsDeleted}"
            : $"{Id} {FirstName} {Patronymic} {LastName} {DateOfBirth} {IsDeleted}";
    }
}