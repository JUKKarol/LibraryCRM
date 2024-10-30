using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.User.Commands.UnAssignUserRole;

public class UnAssignUserRoleCommand : IRequest
{
    public string Email { get; set; }
    public string Role { get; set; }
}