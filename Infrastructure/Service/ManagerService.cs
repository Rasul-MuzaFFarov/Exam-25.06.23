using System.Net;
using AutoMapper;
using Domain.Dtos.DepartmentBaseDto;
using Domain.Dtos.ManagerBaseDto;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class ManagerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ManagerService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<ManagerBaseDto> Getmanager()
    {
        return _context.Managers.Select(e=>new ManagerBaseDto()
        {
            DepartmentId = e.DepartmentId,
            EmployeeId = e.EmployeeId,
            FromDate = e.FromDate,
            ToDate = e.ToDate
            
        }).ToList();
    }
    
    public ManagerBaseDto? GetManagerById(int id)
    {
        return _context.Managers.Select(e=>new ManagerBaseDto()
        {
            DepartmentId = e.DepartmentId,
            EmployeeId = e.EmployeeId,
            FromDate = e.FromDate,
            ToDate = e.ToDate,
        }).FirstOrDefault(p=>p.DepartmentId==id);
    }

    
    public async Task<Response<AddManagerDto>> UpdateManager(AddManagerDto model)
    {
        try
        {
            var find = await _context.Managers.FindAsync(model.DepartmentId);
            _mapper.Map(model, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var response = _mapper.Map<AddManagerDto>(find);
            return new Response<AddManagerDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<AddManagerDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    

    public async Task<Response<bool>> DeleteManager(int id)
    {
        try
        {
            var find =await _context.Managers.FindAsync(id);;
            _context.Managers.Remove(find);
            var result  = await _context.SaveChangesAsync();
            return new Response<bool>(result == 1);
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}

