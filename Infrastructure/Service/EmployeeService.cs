using System.Net;
using AutoMapper;
using Domain.Dtos.DepartmentBaseDto;
using Domain.Dtos.EmployeeBaseDto;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class EmployeeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<EmployeeBaseDto> GetEmployee()
    {
        return _context.Employees.Select(e=>new EmployeeBaseDto()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Gender = e.Gender,
            HireDate = e.HireDate,
            
        }).ToList();
    }
    
    public EmployeeBaseDto? GetEmployeeById(int id)
    {
        return _context.Employees.Select(e=>new EmployeeBaseDto()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Gender = e.Gender,
            HireDate = e.HireDate, 
        }).FirstOrDefault(p=>p.Id==id);
    }

   
    public async Task<Response<AddEmployeeDto>> UpdateEmployee(AddEmployeeDto model)
    {
        try
        {
            var find = await _context.Employees.FindAsync(model.Id);
            _mapper.Map(model, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var response = _mapper.Map<AddEmployeeDto>(find);
            return new Response<AddEmployeeDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<AddEmployeeDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    

    public async Task<Response<bool>> DeleteEmployee(int id)
    {
        try
        {
            var find =await _context.Employees.FindAsync(id);;
            _context.Employees.Remove(find);
            var result  = await _context.SaveChangesAsync();
            return new Response<bool>(result == 1);
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
