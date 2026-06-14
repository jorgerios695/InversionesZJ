using InversionesZJ.Application.DTO.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace InversionesZJ.Application.Features.Auth.Commands.Login
{
    public class LoginCommand :  IRequest<LoginResponse>
    {
       public LoginDto loginDto { get; set; }
    }
}
