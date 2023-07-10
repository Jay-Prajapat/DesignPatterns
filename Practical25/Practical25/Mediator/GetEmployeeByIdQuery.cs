using MediatR;
using Microsoft.EntityFrameworkCore;
using Practical25.Database;
using Practical25.Models;

namespace Practical25.Mediator
{
    public class GetEmployeeByIdQuery:IRequest<Employee?>
    {
        public int Id { get; set; }
        public class GetAllEmployeesQueryHanlder : IRequestHandler<GetEmployeeByIdQuery, Employee?>
        {
            private readonly ApplicationDBContext _context;
            public GetAllEmployeesQueryHanlder(ApplicationDBContext context)
            {
                _context = context;
            }

            public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id);
                return employee;
            }
        }
    }
}
