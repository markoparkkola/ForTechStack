
public class EmployerService
{
    private EmployerRepository employerRepository = new EmployerRepository();

    public IReadOnlyList<Employer> GetAllEmployers() => employerRepository.GetAllEmployers();
    public IReadOnlyList<Employer> GetCurrentEmployers() => employerRepository.GetCurrentEmployers();
}
