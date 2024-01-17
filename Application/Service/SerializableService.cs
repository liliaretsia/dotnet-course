using System;
using System.Reflection;
using System.Text;
using HotelBookingConsoleProject.Application.Service.Dto;
using HotelBookingConsoleProject.Application.Service.Interfaces;
using Newtonsoft.Json;

namespace HotelBookingConsoleProject.Application.Service;

public class SerializableService : ISerializableService
{
    public string SerializeWithReflection(F obj)
    {
        var sb = new StringBuilder();
        foreach (var field in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
        {
            sb.Append($"{field.Name}={field.GetValue(obj)},");
        }
        return sb.ToString().TrimEnd(',');
    }
    
    public F DeserializeWithReflection(string data)
    {
        var f = new F();
        var fields = data.Split(',');

        foreach (var field in fields)
        {
            var parts = field.Split('=');
            var fieldInfo = f.GetType().GetField(parts[0], BindingFlags.Public | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(f, Convert.ChangeType(parts[1], fieldInfo.FieldType));
            }
        }

        return f;
    }
    
    public string SerializeWithJson(F obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public F DeserializeWithJson(string data)
    {
        return JsonConvert.DeserializeObject<F>(data);
    }
}
