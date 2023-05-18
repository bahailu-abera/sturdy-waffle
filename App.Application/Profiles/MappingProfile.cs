using AutoMapper;
using App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Application.Features.Tasks.DTOs;
using App.Application.Features.Checklists.DTOs;

namespace App.Application.Profiles;

 public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<TaskEntity, TaskDto>().ReverseMap();
        CreateMap<TaskEntity, CreateTaskDto>().ReverseMap();
        
        CreateMap<Checklist, ChecklistDto>().ReverseMap();
        CreateMap<Checklist, CreateChecklistDto>().ReverseMap();
    }
}