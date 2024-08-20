
using DDD.Shared.Accounts;
using DDD.Data;
using DDD.Shared.Dimensions;
using DDD.Reporting;
using DDD.Common;
using ForTechStack.Accounts;
using Microsoft.EntityFrameworkCore;

var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
builder.UseInMemoryDatabase("inmem");
var context = new ApplicationDbContext(builder.Options);

Examples.FillContext(context);

var accountService = new AccountsService(new AccountsRepository(context));
var accountTree = await accountService.GetAccountTreeAsync();

var dimensionService = new DimensionService();
var dimensionTree = await dimensionService.GetAsync();

// Just to display how account tree saves lives.
var salesAccount = accountTree.FindAccount(x => x.Number, 3110);
Console.WriteLine(salesAccount!.Name);

var reportingService = new ReportingService(new ReportValueRepository(context));
var documentValues = reportingService.GetReportValuesAsync(new DocumentKey(Guid.Empty, DocumentType.Report), accountTree, dimensionTree);

// just to show how this would work
// we pass dimension tree here also because we might need to recalculate dimensional values

//IBudgetService budgetService;
//budgetService.AddAsync(new DocumentKey(Guid.Empty), null!, dimensionTree);

Console.ReadKey();

