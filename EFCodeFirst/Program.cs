﻿using Microsoft.EntityFrameworkCore;
using EFCodeFirst;

using static System.Console;

using(Academy a= new())
{
    bool deleted = await a.Database.EnsureDeletedAsync();
    WriteLine($"Database deleted: {deleted}");

    bool created = await a.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {deleted}");

    WriteLine($"Sql script used to create database: ");
    WriteLine(a.Database.GenerateCreateScript());

    foreach(Student s in a.Students.Include(S => S.Courses))
    {
        WriteLine("{0} {1} attends the following {2} courses:", s.FirstName, s.LastName, s.Courses!.Count);

        foreach(Course c in s.Courses!)
        {
            WriteLine($"{c.Title}");
        }
    }
}