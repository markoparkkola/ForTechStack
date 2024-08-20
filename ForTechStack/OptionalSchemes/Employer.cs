public record Employer(Guid Id, string Name, DateTime Begin);

public record NotAnEmployerAnyMore(Guid Id, string Name, DateTime Begin, DateTime End)
    : Employer(Id, Name, Begin);

