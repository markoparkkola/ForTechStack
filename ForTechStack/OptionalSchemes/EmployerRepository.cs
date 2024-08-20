
public class EmployerRepository
{
    // Because nullability is not easily handled with Entity Framework, I'll
    // store entities here like they were in real database; with nullable End.
    record EmployerEntity(Guid Id, string Name, DateTime Begin, DateTime? End)
    {
        // Conversion function can be written here if it is trivial
        public Employer ToEmployer()
        {
            // Return correct type of employer
            return End.HasValue
                ? new NotAnEmployerAnyMore(Id, Name, Begin, End.Value)
                : new Employer(Id, Name, Begin);
        }
    }

    private readonly List<EmployerEntity> Database = new List<EmployerEntity>();

    public EmployerRepository()
    {
        Database.Add(new EmployerEntity(Guid.NewGuid(), "Teppo", new DateTime(2020, 1, 1), null));
        Database.Add(new EmployerEntity(Guid.NewGuid(), "Seppo", new DateTime(2020, 1, 1), new DateTime(2021, 1, 1)));
    }

    public IReadOnlyList<Employer> GetAllEmployers() => Database.Select(x => x.ToEmployer()).ToList();
    public IReadOnlyList<Employer> GetCurrentEmployers() => Database.Where(x => x.End == null).Select(x => x.ToEmployer()).ToList();
}
