#!/bin/bash
cd ~/source/repos

read -p "Enter project name: " projname
projname=$(echo "$projname" | tr -s ' ' ' ')

echo "Creating solutions for $projname"
mkdir "$projname"
cd "$projname"

projname=$(echo "$projname" | tr -s ' ' '.')
dotnet new sln -n $projname

dotnet new mvc -o $projname.Api
dotnet new classlib -o $projname.Application
dotnet new classlib -o $projname.Domain
dotnet new classlib -o $projname.Infrastructure
dotnet new classlib -o $projname.External
dotnet new nunit -o $projname.Tests

echo "Adding projects to solution"
dotnet sln add **/*.csproj

echo "Referencing projects"
dotnet add $projname.Api reference $projname.Application/$projname.Application.csproj
dotnet add $projname.Application reference $projname.Infrastructure/$projname.Infrastructure.csproj
dotnet add $projname.Application reference $projname.External/$projname.External.csproj
dotnet add $projname.Infrastructure reference $projname.Domain/$projname.Domain.csproj
dotnet add $projname.External reference $projname.Domain/$projname.Domain.csproj