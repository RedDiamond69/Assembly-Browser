﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer.Declarations
{
    public class NamespaceDeclaration
    {
        private readonly List<TypeDeclaration> _typeDeclarations;
        private readonly string _name;

        public string Name => _name;
        public List<TypeDeclaration> TypeDeclarations => _typeDeclarations;

        public void AddType(TypeDeclaration typeDeclaration) => _typeDeclarations.Add(typeDeclaration);

        public NamespaceDeclaration(string name)
        {
            _name = name;
            _typeDeclarations = new List<TypeDeclaration>();
        }
    }
}
