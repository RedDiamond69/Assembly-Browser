using System;
using System.Collections.Generic;
using AssemblyAnalyzer.Declarations.Members;

namespace AssemblyBrowser.ViewModel
{
    public class MethodVM
    {
        private readonly MethodDeclaration _methodDeclaration;

        public string StringPresentation
        {
            get => GetPresentation();
            private set { }
        }

        private string GetPresentation()
        {
            string stringPresentation = String.Empty;
            stringPresentation = String.Format("{0} {1} {2}", 
                GetAccessModifiers(_methodDeclaration.AccessModifiers.SharpModifiers), 
                _methodDeclaration.RetTypeName, _methodDeclaration.Name);
            if (_methodDeclaration.IsGenerical)
                stringPresentation += String.Format("<{0}>", GetAccessModifiers(_methodDeclaration.GenericalParams));
            stringPresentation += String.Format("({0}) {1}", GetOptions(_methodDeclaration.Options), 
                _methodDeclaration.IsExtention ? "extension" : "");
            return stringPresentation;
        }

        private string GetAccessModifiers(List<string> accessModifiers)
        {
            string modifiersPresentation = String.Empty;
            foreach (string modifier in accessModifiers)
                modifiersPresentation += String.Format("{0} ", modifier);
            return modifiersPresentation.TrimEnd();
        }

        private string GetOptions(List<OptionDeclaration> options)
        {
            string optionPresentation = String.Empty;
            foreach (OptionDeclaration option in options)
            {
                string optionName = String.Empty;
                if (option.IsGenerical)
                    optionName = String.Format("{0}<{1}> {2}", option.TypeName, 
                        GetAccessModifiers(option.GenericalParams), option.Name);
                else
                    optionName = String.Format("{0} {1}", option.TypeName, option.Name);
                optionPresentation += String.Format("{0} {1}, ", GetAccessModifiers(option.AccessModifiers.SharpModifiers), 
                    optionName).TrimStart();
            }
            return optionPresentation.Length > 2 ? 
                optionPresentation.Substring(0, optionPresentation.Length - 2) : optionPresentation;
        }

        public MethodVM(MethodDeclaration methodDeclaration)
        {
            _methodDeclaration = methodDeclaration;
        }
    }
}
