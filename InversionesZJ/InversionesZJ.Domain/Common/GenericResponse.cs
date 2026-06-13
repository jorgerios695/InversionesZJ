using System;
using System.Collections.Generic;
using System.Text;

#nullable disable 
namespace InversionesZJ.Domain.Common;

public class GenericResponse
{
    public string ResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    public bool Success { get; set; }
    public object ResponseObject { get; set; }
}
