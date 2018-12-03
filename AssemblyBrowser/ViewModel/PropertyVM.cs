using System;
using System.Collections.Generic;
using AssemblyAnalyzer.Declarations.Members;
using AssemblyAnalyzer.Declarations.Members.AсcessModifiers;

namespace AssemblyBrowser.ViewModel
{
    public class PropertyVM
    {
        private readonly PropertyDeclaration _propertyDeclaration;

        public string StringPresentation
        {
            get => GetPresentation();
            private set { }
        }

        private string GetPresentation()
        {
            string accessModifiers = GetAccessModifiers(_propertyDeclaration.AccessModifiers.SharpModifiers);
            string tName = _propertyDeclaration.TypeName;
            string name = _propertyDeclaration.Name;
            string accessors = GetAccessors();
            if (_propertyDeclaration.IsGenerical)
                tName += string.Format("<{0}>", GetAccessModifiers((List<string>)_propertyDeclaration.GenericalParams));
            return string.Format("{0} {1} {2} {3}", accessModifiers, tName, name, accessors).Trim();
        }

        private string GetAccessors()
        {
            string modifiersPresentation = "{ ";
            AccessorsModifiers accessorsModifiers = (AccessorsModifiers)_propertyDeclaration.AccessModifiers;
            if (_propertyDeclaration.CanBeRead)
                modifiersPresentation += string.Format("{0} get; ", GetAccessModifiers(accessorsModifiers.Getters)).TrimStart();
            if (_propertyDeclaration.CanBeWrite)
                modifiersPresentation += string.Format("{0} set; ", GetAccessModifiers(accessorsModifiers.Setters)).TrimStart();
            modifiersPresentation += "}";
            return modifiersPresentation;
        }

        private string GetAccessModifiers(List<string> accessModifiers)
        {
            string modifiersPresentation = String.Empty;
            foreach (string modifier in accessModifiers)
                modifiersPresentation += string.Format("{0} ", modifier);
            return modifiersPresentation.TrimEnd();
        }

        public PropertyVM(PropertyDeclaration property)
        {
            _propertyDeclaration = property;
        }
    }
}
