using MediatR;
using Microsoft.EntityFrameworkCore;
using Practical25.Database;
using Practical25.Models;

namespace Practical25.Mediator
{
    public class GetAllEmployeesQuery:IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesQueryHanlder : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
        {
            private readonly ApplicationDBContext _context;
            public GetAllEmployeesQueryHanlder(ApplicationDBContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {
                var employees = await _context.Employees.ToListAsync();
                return employees;
            }
        }
    }
}
