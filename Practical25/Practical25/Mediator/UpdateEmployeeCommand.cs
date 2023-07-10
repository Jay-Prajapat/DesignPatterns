using MediatR;
using Practical25.Database;
using Practical25.Models;

namespace Practical25.Mediator
{
    public class UpdateEmployeeCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public DateTime JoinDate { get; set; }
        public Department DepartmentId { get; set; }
        public bool DeleteStatus { get; set; }

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private readonly ApplicationDBContext _context;
            public UpdateEmployeeCommandHandler(ApplicationDBContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == request.Id);
                if(employee != null) 
                {
                    employee.Name = request.Name;
                    employee.Salary = request.Salary;
                    employee.Email = request.Email;
                    employee.JoinDate = request.JoinDate;
                    employee.DepartmentId = request.DepartmentId;
                    employee.DeleteStatus = request.DeleteStatus;
                    await _context.SaveChangesAsync();
                    return employee.Id;
                }
                return default;
            }
        }
    }
}
