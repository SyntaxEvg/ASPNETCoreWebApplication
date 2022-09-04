﻿namespace EmployeeService.Models.Requests
{
    public class AuthenticationResponse
    {

        public AuthenticationStatus Status { get; set; }
        public SessionDto Session { get; set; }

        public string Message { get; set; } = "";
    }
}
