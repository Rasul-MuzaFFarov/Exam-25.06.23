using System.Net;
using AutoMapper;
using Domain.Dtos.DepartmentBaseDto;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class DepartmentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public DepartmentService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<DepartmentBaseDto> GetDepartment()
    {
        return _context.Departments.Select(e=>new DepartmentBaseDto()
        {
            Id = e.Id,
            Name = e.Name,
            
        }).ToList();
    }
    
    public DepartmentBaseDto? GetDepartmentById(int id)
    {
        return _context.Departments.Select(e=>new DepartmentBaseDto()
        {
            Id = e.Id,
            Name = e.Name,
        }).FirstOrDefault(p=>p.Id==id);
    }

    public AddDepartmentDto AddDepartment(AddDepartmentDto model)
    {
        var department = new Department(model.Id, model.Name);
        _context.Departments.Add(department);
        _context.SaveChanges();
        model.Id = department.Id;
        return model;
    }
    public async Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto model)
    {
        try
        {
            var find = await _context.Departments.FindAsync(model.Id);
            _mapper.Map(model, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var response = _mapper.Map<AddDepartmentDto>(find);
            return new Response<AddDepartmentDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<AddDepartmentDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    

    public async Task<Response<bool>> DeleteDepartment(int id)
    {
        try
        {
            var find =await _context.Departments.FindAsync(id);;
            _context.Departments.Remove(find);
            var result  = await _context.SaveChangesAsync();
            return new Response<bool>(result == 1);
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}