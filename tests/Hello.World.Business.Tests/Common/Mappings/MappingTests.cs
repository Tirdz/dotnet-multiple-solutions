﻿using AutoMapper;
using NUnit.Framework;
using System.Runtime.Serialization;
using Hello.World.DataAccess.Entities;
using Hello.World.Common.Dtos;
using Hello.World.DataAccess.DataContext;
using System.Reflection;

namespace Hello.World.Business.Tests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddMaps(Assembly.GetAssembly(typeof(AppDbContext))));

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(SampleEntity), typeof(SampleDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;
        return FormatterServices.GetUninitializedObject(type);
    }
}
