﻿using AssemblyAnalyzer.Declarations;
using AssemblyAnalyzer.Declarations.Members;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyBrowser.ViewModel
{
    public class TypeVM
    {
        private readonly TypeDeclaration _typeDeclaration;

        public string StringPresentation
        {
            get => GetPresentation();
            private set { }
        }

        public IEnumerable<object> Members
        {
            get
            {
                foreach (FieldDeclaration field in _typeDeclaration.FieldsDeclaration)
                    yield return new FieldVM(field);
                foreach (PropertyDeclaration property in _typeDeclaration.PropertyDeclarations)
                    yield return new PropertyVM(property);
                foreach (MethodDeclaration method in _typeDeclaration.MethodDeclarations)
                    yield return new MethodVM(method);
                foreach (EventDeclaration eventDeclaration in _typeDeclaration.EventDeclarations)
                    yield return new EventVM(eventDeclaration);
                foreach (TypeDeclaration type in _typeDeclaration.TypeDeclarations)
                    yield return new TypeVM(type);
            }
            private set { }
        }

        private string GetPresentation()
        {
            string presentation = String.Empty;
            string keyword = _typeDeclaration.IsInterface ? "interface" : "class";
            presentation = string.Format("{0} {1} {2}", GetAccessModifiers(_typeDeclaration.AccessModifiers.SharpModifiers), 
                keyword, _typeDeclaration.Name);
            if (_typeDeclaration.IsGenerical)
                presentation += string.Format("<{0}>", GetAccessModifiers(_typeDeclaration.GenericalParams));
            if (_typeDeclaration.BaseType != null)
                presentation += string.Format(" : {0} ", _typeDeclaration.BaseType.Split('.').Last());
            if (_typeDeclaration.ImplementedInterfaces.Count() > 0)
                foreach (string implementInterface in _typeDeclaration.ImplementedInterfaces)
                    presentation += string.Format("{0} ", implementInterface);
            return presentation;
        }

        private string GetAccessModifiers(List<string> accessModifiers)
        {
            string modifiersPresentation = String.Empty;
            foreach (string modifier in accessModifiers)
                modifiersPresentation += String.Format("{0} ", modifier);
            return modifiersPresentation.TrimEnd();
        }

        public TypeVM(TypeDeclaration typeDeclaration)
        {
            _typeDeclaration = typeDeclaration;
        }
    }
}
